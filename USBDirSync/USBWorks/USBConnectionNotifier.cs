using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace USBDirSync.USBWorks
{
    public static class USBConnectionNotifier
    {
        public static event EventHandler<USBConnectedEventArgs> USBConnectedInvoker;

        private static void OnUSBConnected(USBConnectedEventArgs e)
        {
            EventHandler<USBConnectedEventArgs> handler = USBConnectedInvoker;
            handler?.Invoke("USBNotifierProvided", e);
        }

        public static void Initialize() 
        {
            ManagementEventWatcher watcher = new ManagementEventWatcher();
            WqlEventQuery query = new WqlEventQuery("SELECT * FROM __InstanceCreationEvent WITHIN 2 WHERE TargetInstance ISA 'Win32_USBHub'");
            watcher.EventArrived += new EventArrivedEventHandler(DeviceInsertedEvent);
            watcher.Query = query;
            watcher.Start();

            WqlEventQuery removeQuery = new WqlEventQuery("SELECT * FROM __InstanceDeletionEvent WITHIN 2 WHERE TargetInstance ISA 'Win32_USBHub'");
            ManagementEventWatcher removeWatcher = new ManagementEventWatcher(removeQuery);
            removeWatcher.EventArrived += new EventArrivedEventHandler(DeviceRemovedEvent);
            removeWatcher.Start();
        }

        private static void DeviceInsertedEvent(object sender, EventArrivedEventArgs e)
        {
            ManagementBaseObject instance = (ManagementBaseObject)e.NewEvent["TargetInstance"];

            USBConnectedEventArgs uSBConnectedEventArgs = new USBConnectedEventArgs();

            foreach (var property in instance.Properties)
            {
                Console.WriteLine(property.Name + " = " + property.Value);

                if (property.Name == "DeviceID")
                {
                    uSBConnectedEventArgs.USBDeviceID = (string)property.Value;
                    break;
                }
            }

            using (var mos = new ManagementObjectSearcher(@"Select * From Win32_PnPEntity"))
            {
                string[] IdSections = uSBConnectedEventArgs.USBDeviceID.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);
                string LastIdSection = IdSections[IdSections.Length - 1];

                using (ManagementObjectCollection collection = mos.Get())
                {
                    foreach (var device in collection)
                    {
                        var id = device.GetPropertyValue("DeviceId").ToString();

                        if (!id.StartsWith("USBSTOR", StringComparison.OrdinalIgnoreCase))
                            continue;

                        var name = device.GetPropertyValue("Name").ToString();

                        if (id.Contains(LastIdSection) && id.Contains("&0"))
                        {
                            uSBConnectedEventArgs.USBDeviceID = id;
                            uSBConnectedEventArgs.USBDeviceName = name;
                            break;
                        }
                    }
                }
            }

            OnUSBConnected(uSBConnectedEventArgs);
        }

        private static void DeviceRemovedEvent(object sender, EventArrivedEventArgs e)
        {
            //ManagementBaseObject instance = (ManagementBaseObject)e.NewEvent["TargetInstance"];
            //foreach (var property in instance.Properties)
            //{
            //    Console.WriteLine(property.Name + " = " + property.Value);
            //}
        }
    }
}