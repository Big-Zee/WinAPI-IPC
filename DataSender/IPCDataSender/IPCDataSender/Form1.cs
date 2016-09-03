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

[assembly: CLSCompliant(true)]
namespace IPCDataSender
{
    public partial class FormMain : Form
    {
        
        private static int counter = 0;

        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonSendMessage_Click(object sender, EventArgs e)
        {
            NativeMethods nativeMethods = new NativeMethods();
            var ReceiverMainWindowTitle = "IPCDataReceiver";
            int ReceiverHandle = nativeMethods.FindWindow(ReceiverMainWindowTitle);
            if (ReceiverHandle != 0)
            {
                
                for (int i = 0; i < 100; i++)
                {
                    nativeMethods.SendData(ReceiverHandle, "Count" + i);
                }
            }
            else
            {

            }
            counter++;
        }
    }
}
