using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using USBDirSync.FileSystemWorks;
using USBDirSync.FileSystemWorks.DataStructures;
using USBDirSync.StorageWorks.Enums;

namespace USBDirSync.StorageWorks
{
    /// <summary>
    /// Singleton class that performs actions of checking and correcting the data of specific DirectoryData that has been read from Fhsks file corresponding
    /// to a real data that exist at the moment.
    /// </summary>
    public static class FileStatusLoader
    {
        /// <summary>
        /// Function that forms a list of statuses compared to a specific DirectoryData data passed. 
        /// </summary>
        /// <param name="currentDD">Specific DirectoryData to form a file statuses from.</param>
        /// <returns>LoadedFileStatus list which tells if the file datas read from Fhsks are correct or if its not tell whats wrong with it.</returns>
        public static List<LoadedFileStatus> CheckFileStatusesOfDirectoryData(DirectoryData currentDD)
        {
            List<LoadedFileStatus> result = new List<LoadedFileStatus>();

            foreach (var item in currentDD.Files)
            {
                string currentLocalPath = currentDD.FindFileGetLocalPath(item.RelativePath);
                if (File.Exists(currentLocalPath))
                {
                    FileInfo fi = new FileInfo(currentLocalPath);

                    if (fi.LastWriteTime != item.LastModifiedTime)
                        result.Add(LoadedFileStatus.Modified);
                    else
                        result.Add(LoadedFileStatus.NotTouched);
                }
                else
                    result.Add(LoadedFileStatus.DoesntExist);
            }

            return result;
        }

        /// <summary>
        /// Function that removes non-existant files from specified DirectoryData FileData list based on pre-computed LoadedFileStatus list.
        /// </summary>
        /// <param name="lfs">Pre-computed LoadedFileStatus list</param>
        /// <param name="currentDD">Specific DirectoryData to correct.</param>
        public static void RemoveNotExistingFiles(List<LoadedFileStatus> lfs, DirectoryData currentDD) 
        {
            for (int i = 0; i < currentDD.Files.Count; i++)
            {
                if (lfs[i] == LoadedFileStatus.DoesntExist) 
                {
                    lfs.RemoveAt(i);
                    currentDD.Files.RemoveAt(i);
                    i--;
                }
            }
        }

        /// <summary>
        /// Function that updates existant files data it of specified DirectoryData FileData list based on pre-computed LoadedFileStatus list by re-computing it.
        /// </summary>
        /// <param name="lfs">Pre-computed LoadedFileStatus list</param>
        /// <param name="currentDD">Specific DirectoryData to correct.</param>
        public static void UpdateModifiedFilesData(List<LoadedFileStatus> lfs, DirectoryData currentDD)
        {
            using (var md5 = MD5.Create())
            {
                for (int i = 0; i < currentDD.Files.Count; i++)
                {
                    if (lfs[i] == LoadedFileStatus.Modified)
                    {
                        FileData crnt = currentDD.Files[i];
                        FileInfo fi = new FileInfo(currentDD.FindFileGetLocalPath(crnt.RelativePath));
                        crnt.LastModifiedTime = fi.LastWriteTime;

                        using (var stream = File.OpenRead(currentDD.FindFileGetLocalPath(crnt.RelativePath)))
                        {
                            crnt.Hash = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLowerInvariant();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Function that checks for existant files that hasnt been detected by reading Fhsks file it because they are new.
        /// </summary>
        /// <param name="lfs">Pre-computed LoadedFileStatus list</param>
        /// <param name="currentDD">Specific DirectoryData to correct.</param>
        public static void AddNewFiles(List<LoadedFileStatus> lfs, DirectoryData currentDD) 
        {
            string[] files = Directory.GetFiles(currentDD.RootPath, "*", SearchOption.AllDirectories);

            for (int i = 0; i < files.Length; i++)
            {
                string buff = files[i].Replace(currentDD.RootPath, "");

                if (!currentDD.CheckFileExistanceByRelativePath(buff))
                {
                    currentDD.AddFileData(files[i]);
                    lfs.Add(LoadedFileStatus.NotTouched);
                }
            }
        }
    }
}
