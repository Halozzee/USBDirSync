using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using USBDirSync.StorageWorks;
using USBDirSync.StorageWorks.Enums;

namespace USBDirSync.FileSystemWorks
{
    public class DirectoryData
    {
        public string RootPath;
        public List<FileData> Files = new List<FileData>();
        private MD5 _md5;

        public DirectoryData(string RootPath)
        {
            if (RootPath[RootPath.Length - 1] != '/' || RootPath[RootPath.Length - 1] != '\\')
            {
                if (RootPath.Contains('/'))
                    RootPath += '/';
                else if (RootPath.Contains('\\'))
                    RootPath += '\\';
            }

            this.RootPath = RootPath;

            if (FhsksIO.CheckCorespondingFhsksFileExistance(RootPath))
            {
                ReadFhsksAndGetLatestFileData();
            }
            else
                BruteReadFiles();
        }

        private void ReadFhsksAndGetLatestFileData() 
        {
            string FhsksFilePath = FhsksIO.GetCorespondingFhsksFilePath(RootPath);
            DirectoryData currentDD = FhsksIO.ReadDirectoryDataFromFile(FhsksFilePath);

            List<LoadedFileStatus> statusList = FileStatusLoader.CheckFileStatusesOfDirectoryData(currentDD);
            FileStatusLoader.RemoveNotExistingFiles(statusList, currentDD);
            FileStatusLoader.UpdateModifiedFilesData(statusList, currentDD);

            this.Files = currentDD.Files;
        }

        private void BruteReadFiles()
        {
            this._md5 = MD5.Create();
            
            string[] allfiles = Directory.GetFiles(this.RootPath, "*", SearchOption.AllDirectories);

            foreach (var item in allfiles)
            {
                FileInfo FI = new FileInfo(item);
                Files.Add(new FileData(GetRelativePathFromLocal(item), CalculateFileHash(item), FI.LastWriteTime));
            }

            this._md5 = null;
        }

        private string CalculateFileHash(string FileName) 
        {
            using (var stream = File.OpenRead(FileName))
            {
                return BitConverter.ToString(_md5.ComputeHash(stream)).Replace("-", "").ToLowerInvariant();
            }
        }

        private string GetRelativePathFromLocal(string LocalPath) 
        {
            return LocalPath.Replace(RootPath, "");
        }

        private string GetLocalPathFromRelative(string RelativePath)
        {
            return RootPath + RelativePath;
        }

        public string FindFileGetLocalPath(string RelativePath) 
        {
            FileData found = Files.Find(x => x.RelativePath == RelativePath);

            if (found != null)
                return GetLocalPathFromRelative(found.RelativePath);
            else
                throw new ArgumentNullException("This file does not exist in this directory!");
        }

        public string FindFileGetFileHash(string RelativePath)
        {
            FileData found = Files.Find(x => x.RelativePath == RelativePath);

            if (found != null)
                return found.Hash;
            else
                throw new ArgumentNullException("This file does not exist in this directory!");
        }

        public FileData FindFileGetFileData(string RelativePath)
        {
            FileData found = Files.Find(x => x.RelativePath == RelativePath);

            if(found != null)
                return found;
            else
                throw new ArgumentNullException("This file does not exist in this directory!");
        }

        public bool CheckFileExistanceByRelativePath(string RelativePath) 
        {
            return Files.FindIndex(x => x.RelativePath == RelativePath) != - 1;
        }
    }
}
