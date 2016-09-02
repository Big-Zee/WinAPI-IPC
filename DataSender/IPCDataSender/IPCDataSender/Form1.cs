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

namespace IPCDataSender
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// FindWindow winAPI method
        /// </summary>
        /// <param name="lpClassName"></param>
        /// <param name="lpWindowName"></param>
        /// <returns></returns>
        [DllImport("User32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern int FindWindow(String lpClassName, String lpWindowName);
        private static int counter = 0;

        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonSendMessage_Click(object sender, EventArgs e)
        {
            var ReceiverMainWindowTitle = "IPCDataReceiver";
            int ReceiverHandle = FindWindow(null, ReceiverMainWindowTitle);
            if (ReceiverHandle != 0)
            {
                MessageHelper msgHelp = new MessageHelper();
                for (int i = 0; i < 100; i++)
                {
                    msgHelp.SendData(ReceiverHandle, "Count" + i);
                }
            }
            else
            {

            }
            counter++;
        }
    }
}
