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

namespace IPCDataReceiver
{
    public partial class IPCDataReceiver : Form
    {
        /// <summary>
        /// Windows Message - CopyData
        /// </summary>
        public const Int32 WM_COPYDATA = 0x4A;

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

        public Stopwatch MessagesStopWatch = new Stopwatch();
        public int MessagesReceivedCount = 1;
        public long sum = 0;
        public double avarage = 0.0;

        public IPCDataReceiver()
        {
            InitializeComponent();
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
                if (MessagesStopWatch.IsRunning)
                {
                    MessagesStopWatch.Stop();
                    Trace.WriteLine("Ticks taken : " + MessagesStopWatch.ElapsedTicks + " - [Ticks]");
                    sum = sum + MessagesStopWatch.ElapsedTicks;
                    avarage = sum / MessagesReceivedCount;
                    MessagesStopWatch.Reset();
                    Trace.WriteLine("Ticks stats - avarage ticks : " + avarage);
                    MessagesReceivedCount++;
                    UpdateLabelAvarage(avarage);
                }
                var msg = (COPYDATASTRUCT)Marshal.PtrToStructure(m.LParam, typeof(COPYDATASTRUCT));
                var pData = (MessagePacket)Marshal.PtrToStructure(msg.lpData, typeof(MessagePacket));
                var MessageTitle = pData.MessageTitle;
                var MessageDescription = pData.MessageDescription;
                var ErrorId = pData.ErrorId;
                var ModuleId = pData.ModuleId;
                var ValueBefore = pData.ValueBefore;
                var ValueAfter = pData.ValueAfter;
                if (!MessagesStopWatch.IsRunning)
                {
                    MessagesStopWatch.Start();
                }
            }
            //Process rest of messages normally.
            base.WndProc(ref m);
        }

        private void UpdateLabelAvarage(double avarageTicks)
        {
            labelTicksAvarage.Text = avarageTicks.ToString();
        }
    }
}
