using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USBDirSync.FileSystemWorks.DataStructures
{
    /// <summary>
    /// Class that represents the data of the synchronizable file itself.
    /// </summary>
    public class FileData
    {
        /// <summary>
        /// Relative to its root directory path of this file. 
        /// </summary>
        public string RelativePath;
        /// <summary>
        /// This file MD5 hash.
        /// </summary>
        public string Hash;
        /// <summary>
        /// DateTime of the last time this file was modified.
        /// </summary>
        public DateTime LastModifiedTime;

        public FileData(string RelativePath, string Hash, DateTime LastModifiedTime)
        {
            this.RelativePath = RelativePath;
            this.Hash = Hash;
            this.LastModifiedTime = LastModifiedTime;
        }
    }
}
