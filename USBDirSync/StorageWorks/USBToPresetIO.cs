using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USBDirSync.StorageWorks
{
    /// <summary>
    /// Singleton class that performs Input/Output actions for USBToPreset files.
    /// </summary>
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

        /// <summary>
        /// Function that reads all Preset files from the directory.
        /// </summary>
        /// <returns>Array of filenames with relative path.</returns>
        public static string[] ReadUSBToPresetList()
        {
            if (Directory.Exists("USBToPreset"))
                return Directory.GetFiles("USBToPreset");
            else
                return null;
        }
    }
}
