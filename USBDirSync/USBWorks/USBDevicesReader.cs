using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using USBDirSync.USBWorks;

namespace USBDirSync.USBWorks
{
    public class USBDevicesReader
    {
        public static List<USBConnectedEventArgs> GetConnectedStorageDevices() 
        {
            List<USBConnectedEventArgs> connectedDevices = new List<USBConnectedEventArgs>();
            using (var mos = new ManagementObjectSearcher(@"Select * From Win32_PnPEntity"))
            {
                using (ManagementObjectCollection collection = mos.Get())
                {
                    foreach (var device in collection)
                    {
                        var id = device.GetPropertyValue("DeviceId").ToString();

                        if (!id.StartsWith("USBSTOR", StringComparison.OrdinalIgnoreCase))
                            continue;

                        var name = device.GetPropertyValue("Name").ToString();

                        if (id.Contains("&0"))
                        {
                            USBConnectedEventArgs uSBConnectedEventArgs = new USBConnectedEventArgs();

                            uSBConnectedEventArgs.USBDeviceID = id;
                            uSBConnectedEventArgs.USBDeviceName = name;

                            connectedDevices.Add(uSBConnectedEventArgs);
                        }
                    }
                }
            }
            return connectedDevices;
        }
    }
}
