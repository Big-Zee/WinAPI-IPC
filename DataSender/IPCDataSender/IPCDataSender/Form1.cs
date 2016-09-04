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
using System.Runtime.InteropServices;
using System.Diagnostics;

[assembly: CLSCompliant(true)]
namespace IPCDataSender
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonSendMessage_Click(object sender, EventArgs e)
        {
            var ReceiverMainWindowTitle = "IPCDataReceiver";
            int ReceiverHandle = NativeMethods.FindWindow(ReceiverMainWindowTitle);
            int size = System.Runtime.InteropServices.Marshal.SizeOf(typeof(MessagePacket));
            if (ReceiverHandle != 0)
            {                
                var count=0;
                Stopwatch sw = new Stopwatch();
                sw.Start();                
                do
                {
                    NativeMethods.SendData(ReceiverHandle, "Count" + count);
                    count++;
                } while (sw.ElapsedMilliseconds <= 60000);
                Trace.WriteLine("Sent : " + count + " messages");
                var structsPerSec = (count/60);
                Trace.WriteLine("Sent Msgs - (structs) / second : " + structsPerSec);
            }
        }
    }
}
