using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USBDirSync.USBWorks
{
    public class USBConnectedEventArgs : EventArgs
    {
        public string USBDeviceID;
        public string USBDeviceName;
    }
}