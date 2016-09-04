using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataToSend;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Collections.Concurrent;

namespace IPCDataReceiver
{
    public partial class IPCDataReceiver : Form
    {

        /// <summary>
        /// 
        /// </summary>
        System.Timers.Timer twoSecondsTimer = new System.Timers.Timer();

        /// <summary>
        /// 
        /// </summary>
        private BlockingCollection<MessagePacket> collecitionOfMsgs = new BlockingCollection<MessagePacket>();
        
        /// <summary>
        /// 
        /// </summary>
        private int MsgsReceivedCounter = 0;

        /// <summary>
        /// Windows Message - CopyData
        /// </summary>
        private const Int32 WM_COPYDATA = 0x4A;

        /// <summary>
        /// The COPYDATASTRUCT describes the data that is passed.
        /// The message is routed via the receiving process's window handle.
        /// The first field, dwData, may contain anything the sender wishes; it is the equivalent of System.Object sender in an EventHandler.
        /// The count of bytes is given in cbData.
        /// And the data itself is pointed to by lpData.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            public IntPtr lpData;
        }        

        public IPCDataReceiver()
        {
            InitializeComponent();
            StartQueueAndTimer();
        }        

        private void StartQueueAndTimer()
        {
            StartMessagesProcessorThread();
            StartTwoSecondsTimer();
        }

        private void StartTwoSecondsTimer()
        {
            twoSecondsTimer = new System.Timers.Timer(20000);
            twoSecondsTimer.Elapsed += twoSecondsTimer_Elapsed;
            twoSecondsTimer.AutoReset = true;
            twoSecondsTimer.Start();            
        }

        private void twoSecondsTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Trace.WriteLine("Received Messages : " + MsgsReceivedCounter);
        }

        /// <summary>
        /// Override WndProc to watch for messages. Monitoring for incoming messages to appMainWindow
        /// Here we can filter messages and catch what we want.
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_COPYDATA)
            {
                var msg = (COPYDATASTRUCT)Marshal.PtrToStructure(m.LParam, typeof(COPYDATASTRUCT));
                var pData = (MessagePacket)Marshal.PtrToStructure(msg.lpData, typeof(MessagePacket));
                AddToQueue(pData);
                /*
                var MessageTitle = pData.MessageTitle;
                var MessageDescription = pData.MessageDescription;
                var ErrorId = pData.ErrorId;
                var ModuleId = pData.ModuleId;
                var ValueBefore = pData.ValueBefore;
                var ValueAfter = pData.ValueAfter;*/
            }
            //Process rest of messages normally.
            base.WndProc(ref m);
        }        

        private void StartMessagesProcessorThread()
        {
            Task.Factory.StartNew(() =>
            {
                foreach (var singleMessage in collecitionOfMsgs.GetConsumingEnumerable())
                {
                    MsgsReceivedCounter++;
                }
            }).ContinueWith(s => { collecitionOfMsgs.Dispose();});
        }

        private void AddToQueue(MessagePacket msgPacket)
        {
            if (!collecitionOfMsgs.IsAddingCompleted)
            {
                collecitionOfMsgs.Add(msgPacket);
            }
        }

        private void StopQueueThread()
        {
            collecitionOfMsgs.CompleteAdding();
        }

        private void StopAndDisposeTwoSecondsTimer()
        {
            twoSecondsTimer.Stop();
            twoSecondsTimer.Dispose();
        }

        private void IPCDataReceiver_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopQueueThread();
            StopAndDisposeTwoSecondsTimer();
        }
    }
}
