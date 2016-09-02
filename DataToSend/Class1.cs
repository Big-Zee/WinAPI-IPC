using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

[assembly: CLSCompliant(true)]
namespace DataToSend
{
        /// <summary>
        /// The data may be of any agreed-upon form.
        /// The Pack parameter to the structure gives the padding between fields.
        /// Here Pack = 1 is used because the original data was created in a 32-bit C++ DLL and no padding was used.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]        
        public struct MessagePacket
        {
            /// <summary>The string is included inline in the data.</summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]                        
            private string messageTitle;
            
            /// <summary>
            /// MessageTitle - string message title to send.
            /// </summary>
            public string MessageTitle
            {
                get { return messageTitle; }
                set { messageTitle = value; }
            }

            /// <summary>
            /// Message description string with fixed length. Description should be longer than title.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]            
            private string messageDescription;

            /// <summary>
            /// MessageDescription - string message description that was sent.
            /// </summary>
            public string MessageDescription
            {
                get { return messageDescription; }
                set { messageDescription = value; }
            }

            /// <summary>Field for ErrorId if any. If all is ok - ErrorId = 0</summary>
            public int ErrorId { get; set; }

            /// <summary>ModuleId - Id of module from each answer is comming from</summary>
            public int ModuleId { get; set; }
            /// <summary>Values befor that was present in the system</summary>
            public double ValueBefore { get; set; }
            /// <summary>Value after insertion that was inserted into system</summary>
            public double ValueAfter { get; set; }
        }
}
