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
        public static PresetData ReadDirectoryDataFromFile(string StorageFilePath)
        {
            return JsonConvert.DeserializeObject<PresetData>(File.ReadAllText(StorageFilePath));
        }

        public static void WriteDirectoryDataToFile(PresetData PD, string StorageFilePath)
        {
            if (!Directory.Exists("Presets"))
                Directory.CreateDirectory("Presets");

            File.WriteAllText(StorageFilePath, JsonConvert.SerializeObject(PD));
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
