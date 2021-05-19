using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USBDirSync.StorageWorks
{
    public static class USBToPresetIO
    {
        public static USBToPresetData ReadUSBToPresetDataFromFile(string PresetFilePath)
        {
            return JsonConvert.DeserializeObject<USBToPresetData>(File.ReadAllText(PresetFilePath));
        }

        public static void WriteUSBToPresetDataToFile(USBToPresetData PD, string PresetFilePath)
        {
            if (!Directory.Exists("USBToPreset"))
                Directory.CreateDirectory("USBToPreset");

            File.WriteAllText(PresetFilePath, JsonConvert.SerializeObject(PD));
        }
    }
}
