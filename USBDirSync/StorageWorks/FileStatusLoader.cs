using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using USBDirSync.FileSystemWorks;
using USBDirSync.StorageWorks.Enums;

namespace USBDirSync.StorageWorks
{
    public static class FileStatusLoader
    {
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
    }
}
