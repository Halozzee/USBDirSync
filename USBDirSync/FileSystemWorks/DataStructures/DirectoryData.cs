using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using USBDirSync.StorageWorks;
using USBDirSync.StorageWorks.Enums;

namespace USBDirSync.FileSystemWorks.DataStructures
{
    /// <summary>
    /// Class that represents the data of the synchronizable directory itself.
    /// </summary>
    public class DirectoryData
    {
        /// <summary>
        /// The path to the directory itself.
        /// </summary>
        public string RootPath;
        /// <summary>
        /// Collection of FileData representing Files that contained in that directory.
        /// </summary>
        public List<FileData> Files = new List<FileData>();
        /// <summary>
        /// The instance of MD5 hash algorithm hash taker.
        /// </summary>
        private MD5 _md5;

        public DirectoryData() { }

        public DirectoryData(string RootPath)
        {
            RootPath = MakePathEndSlash(RootPath);

            this.RootPath = RootPath;

            if (FhsksIO.CheckCorrespondingFhsksFileExistance(RootPath))
            {
                ReadFhsksAndGetLatestFileData();
            }
            else
                BruteReadFiles();

            SaveHashes();
        }

        /// <summary>
        /// Function that corrects the last symbol of the path by placing the corresponding slash \ or / depending of which was used in the path
        /// all along.
        /// </summary>
        /// <param name="Path">The path that has to be checked and fixed.</param>
        /// <returns>The result of checking with correction if they were made.</returns>
        private static string MakePathEndSlash(string Path)
        {
            if (Path[Path.Length - 1] != '/' || Path[Path.Length - 1] != '\\')
            {
                if (Path.Contains('/'))
                    Path += '/';
                else if (Path.Contains('\\'))
                    Path += '\\';
            }

            return Path;
        }

        /// <summary>
        /// Function that makes the DirectoryData being read from corresponding Fhsks files with checking 
        /// that the read data is correct at the moment it being read. If the data wasnt correct it would update the files
        /// and re-calculate hashes if its needed with reading new files.
        /// </summary>
        private void ReadFhsksAndGetLatestFileData() 
        {
            string FhsksFilePath = FhsksIO.GetCorrespondingFhsksFilePath(RootPath);
            DirectoryData currentFhsksDD = FhsksIO.ReadDirectoryDataFromFile(FhsksFilePath);

            List<LoadedFileStatus> statusList = FileStatusLoader.CheckFileStatusesOfDirectoryData(currentFhsksDD);
            FileStatusLoader.RemoveNotExistingFiles(statusList, currentFhsksDD);
            FileStatusLoader.UpdateModifiedFilesData(statusList, currentFhsksDD);
            FileStatusLoader.AddNewFiles(statusList, currentFhsksDD);

            this.Files = currentFhsksDD.Files;
        }

        /// <summary>
        /// Function that makes the FileData of the contained files as it is (no Fhsks actions).
        /// </summary>
        private void BruteReadFiles()
        {      
            string[] allfiles = Directory.GetFiles(this.RootPath, "*", SearchOption.AllDirectories);

            foreach (var item in allfiles)
            {
                AddFileData(item);
            }
        }

        /// <summary>
        /// Function that adds FileData to List of FileData's from specified file by its path.
        /// </summary>
        /// <param name="FilePath">The path to a specified file that has to be added.</param>
        public void AddFileData(string FilePath) 
        {
            FileInfo FI = new FileInfo(FilePath);
            Files.Add(new FileData(GetRelativePathFromLocal(FilePath), CalculateFileHash(FilePath), FI.LastWriteTime, FI.Length));
        }

        /// <summary>
        /// Function that calculated MD5 hash of the specified file.
        /// </summary>
        /// <param name="FileName">The path to a specified file which MD5 hash has to be calculated.</param>
        /// <returns></returns>
        private string CalculateFileHash(string FileName) 
        {
            if(_md5 == null)
                _md5 = MD5.Create();

            using (var stream = File.OpenRead(FileName))
            {
                return BitConverter.ToString(_md5.ComputeHash(stream)).Replace("-", "").ToLowerInvariant();
            }
        }

        /// <summary>
        /// Function that gets the relative file path from the local path of the corresponding file.
        /// </summary>
        /// <param name="LocalPath">Local path of the corresponding file.</param>
        /// <returns></returns>
        private string GetRelativePathFromLocal(string LocalPath) 
        {
            return LocalPath.Replace(RootPath, "");
        }

        /// <summary>
        /// Function that gets the local file path from the relative path of the corresponding file.
        /// </summary>
        /// <param name="RelativePath">Relative path of the corresponding file.</param>
        /// <returns></returns>
        private string GetLocalPathFromRelative(string RelativePath)
        {
            return RootPath + RelativePath;
        }

        /// <summary>
        /// Function that looks for a file in List of FileDatas.
        /// </summary>
        /// <param name="RelativePath">Relative path of the corresponding file.</param>
        /// <returns>Local path of the corresponding file if its exist in the FileData list. Exception if file is not found.</returns>
        public string FindFileGetLocalPath(string RelativePath) 
        {
            FileData found = Files.Find(x => x.RelativePath == RelativePath);

            if (found != null)
                return GetLocalPathFromRelative(found.RelativePath);
            else
                throw new ArgumentNullException("This file does not exist in this directory!");
        }

        /// <summary>
        /// Function that looks for a file in List of FileDatas.
        /// </summary>
        /// <param name="RelativePath">Relative path of the corresponding file.</param>
        /// <returns>MD5 hash of the corresponding file if its exist in the FileData list. Exception if file is not found.</returns>
        public string FindFileGetFileHash(string RelativePath)
        {
            FileData found = Files.Find(x => x.RelativePath == RelativePath);

            if (found != null)
                return found.Hash;
            else
                throw new ArgumentNullException("This file does not exist in this directory!");
        }

        /// <summary>
        /// Function that looks for a file in List of FileDatas.
        /// </summary>
        /// <param name="RelativePath">Relative path of the corresponding file.</param>
        /// <returns>FileData of the corresponding file if its exist in the FileData list. Exception if file is not found.</returns>
        public FileData FindFileGetFileData(string RelativePath)
        {
            FileData found = Files.Find(x => x.RelativePath == RelativePath);

            if(found != null)
                return found;
            else
                throw new ArgumentNullException("This file does not exist in this directory!");
        }

        /// <summary>
        /// Function that looks for a file in List of FileDatas.
        /// </summary>
        /// <param name="RelativePath">Relative path of the corresponding file.</param>
        /// <returns>True - file does exist in the list of FileData's. False - file doesnt exist in the list of FileData's</returns>
        public bool CheckFileExistanceByRelativePath(string RelativePath) 
        {
            return Files.FindIndex(x => x.RelativePath == RelativePath) != - 1;
        }

        public void SaveHashes() 
        {
           FhsksIO.WriteDirectoryDataToFile(this, FhsksIO.GetCorrespondingFhsksFilePath(this.RootPath));
        }
    }
}
