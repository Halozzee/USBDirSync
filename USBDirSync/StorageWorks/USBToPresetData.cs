using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USBDirSync.USBWorks;

namespace USBDirSync.StorageWorks
{
    /// <summary>
    /// Class that represents data of USB device linked to a specific preset.
    /// </summary>
    public class USBToPresetData
    {
        /// <summary>
        /// Data of device.
        /// </summary>
        public USBConnectedEventArgs DeviceData;
        /// <summary>
        /// Name of the preset that will be linked.
        /// </summary>
        public string PresetName;
    }
}
