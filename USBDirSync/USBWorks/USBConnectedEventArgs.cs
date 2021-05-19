using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USBDirSync.USBWorks
{
    /// <summary>
    /// Arguments that were given from the event of connecting/reading connected USB devices.
    /// </summary>
    public class USBConnectedEventArgs : EventArgs
    {
        public string USBDeviceID;
        public string USBDeviceName;
    }
}