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
    public static class FhsksIO
    {
        public static string GetCorespondingFhsksFilePath(string RootPath) 
        {
            return $@"FHSKS\\{RootPath.GetHashCode()}.fhsks";
        }

        public static bool CheckCorespondingFhsksFileExistance(string RootPath)
        {
            return File.Exists(GetCorespondingFhsksFilePath(RootPath));
        }

        public static void WriteDirectoryDataToFile(DirectoryData DD, string StorageFilePath) 
        {
            if (!Directory.Exists("FHSKS"))
                Directory.CreateDirectory("FHSKS");

            File.WriteAllText(StorageFilePath, JsonConvert.SerializeObject(DD));
        }

        public static DirectoryData ReadDirectoryDataFromFile(string StorageFilePath)
        {
            return JsonConvert.DeserializeObject<DirectoryData>(File.ReadAllText(StorageFilePath));            
        }

    }
}
