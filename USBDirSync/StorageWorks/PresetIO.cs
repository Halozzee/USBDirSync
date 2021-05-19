using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USBDirSync.StorageWorks
{
    public static class PresetIO
    {
        public static PresetData ReadPresetDataFromFile(string PresetFilePath)
        {
            return JsonConvert.DeserializeObject<PresetData>(File.ReadAllText(PresetFilePath));
        }

        public static void WritePresetDataToFile(PresetData PD, string PresetFilePath)
        {
            if (!Directory.Exists("Presets"))
                Directory.CreateDirectory("Presets");

            File.WriteAllText(PresetFilePath, JsonConvert.SerializeObject(PD));
        }

        public static string[] ReadPresetsList() 
        {
            if (Directory.Exists("Presets"))
                return Directory.GetFiles("Presets");
            else
                return null;
        }
    }
}
