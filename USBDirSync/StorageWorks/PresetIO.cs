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
    /// Singleton class that performs Input/Output actions for Preset files.
    /// </summary>
    public static class PresetIO
    {
        /// <summary>
        /// Function that reads PresetData from file.
        /// </summary>
        /// <param name="PresetFilePath">Path PresetData will be read from.</param>
        /// <returns>PresetData that has been read.</returns>
        public static PresetData ReadPresetDataFromFile(string PresetFilePath)
        {
            return JsonConvert.DeserializeObject<PresetData>(File.ReadAllText(PresetFilePath));
        }

        /// <summary>
        /// Function that reads PresetData to a file.
        /// </summary>
        /// <param name="PD">PresetData data will be read from.</param>
        /// <param name="PresetFilePath">Path the data will be written on.</param>
        public static void WritePresetDataToFile(PresetData PD, string PresetFilePath)
        {
            if (!Directory.Exists("Presets"))
                Directory.CreateDirectory("Presets");

            File.WriteAllText(PresetFilePath, JsonConvert.SerializeObject(PD));
        }

        /// <summary>
        /// Function that reads all Preset files from the directory.
        /// </summary>
        /// <returns>Array of filenames with relative path.</returns>
        public static string[] ReadPresetsList() 
        {
            if (Directory.Exists("Presets"))
                return Directory.GetFiles("Presets");
            else
                return null;
        }
    }
}
