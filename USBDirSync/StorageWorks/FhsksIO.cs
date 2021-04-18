using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using USBDirSync.FileSystemWorks;
using USBDirSync.FileSystemWorks.DataStructures;

namespace USBDirSync.StorageWorks
{
    /// <summary>
    /// Singleton class that performs Input/Output actions for Fhsks files.
    /// </summary>
    public static class FhsksIO
    {
        /// <summary>
        /// Function that gets the relative path to a corresponding Fhsks file based on the directory path.
        /// </summary>
        /// <param name="RootPath">Directory path of the synchronizable directory.</param>
        /// <returns>Relative path to a corresponding Fhsks file.</returns>
        public static string GetCorrespondingFhsksFilePath(string RootPath) 
        {
            return $@"FHSKS\\{RootPath.GetHashCode()}.fhsks";
        }

        /// <summary>
        /// Function that check if corresponding Fhsks file based on the directory path does exist.
        /// </summary>
        /// <param name="RootPath">Directory path of the synchronizable directory.</param>
        /// <returns>True - file does exist. False - file doesnt exist.</returns>
        public static bool CheckCorrespondingFhsksFileExistance(string RootPath)
        {
            return File.Exists(GetCorrespondingFhsksFilePath(RootPath));
        }

        /// <summary>
        /// Function that serialize DirectoryData object to a Fhsks file.
        /// </summary>
        /// <param name="DD">DirectoryData object to be serialized.</param>
        /// <param name="StorageFilePath">Path the serialized data to be written to.</param>
        public static void WriteDirectoryDataToFile(DirectoryData DD, string StorageFilePath) 
        {
            if (!Directory.Exists("FHSKS"))
                Directory.CreateDirectory("FHSKS");

            File.WriteAllText(StorageFilePath, JsonConvert.SerializeObject(DD));
        }

        /// <summary>
        /// Function that deserialize DirectoryData object from a Fhsks file.
        /// </summary>
        /// <param name="StorageFilePath">Path to the serialized data</param>
        /// <returns>DirectoryData object that was deserialized.</returns>
        public static DirectoryData ReadDirectoryDataFromFile(string StorageFilePath)
        {
            return JsonConvert.DeserializeObject<DirectoryData>(File.ReadAllText(StorageFilePath));            
        }

    }
}
