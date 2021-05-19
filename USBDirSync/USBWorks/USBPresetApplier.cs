using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USBDirSync.StorageWorks;

namespace USBDirSync.USBWorks
{
    public static class USBPresetApplier
    {
        public static event EventHandler<PresetAppliedEventArgs> PresetApplied;

        private static void OnPresetApplied(PresetAppliedEventArgs e)
        {
            EventHandler<PresetAppliedEventArgs> handler = PresetApplied;
            handler?.Invoke("PresetApplied", e);
        }
        public static void Initialize() 
        {
            USBConnectionNotifier.USBConnectedInvoker += USBConnectionNotifier_OnDeviceConnected;
        }

        private static void USBConnectionNotifier_OnDeviceConnected(object sender, USBConnectedEventArgs e)
        {
            if (Directory.Exists("USBToPreset")) 
            {
                if (File.Exists("USBToPreset\\"+ e.USBDeviceName + ".json"))
                {
                    USBToPresetData UDP = USBToPresetIO.ReadUSBToPresetDataFromFile("USBToPreset\\" + e.USBDeviceName + ".json");
                    PresetAppliedEventArgs PAEA = new PresetAppliedEventArgs();
                    PAEA.AppliedPresetName = UDP.PresetName;
                    OnPresetApplied(PAEA);
                }
            }
        }
    }
}