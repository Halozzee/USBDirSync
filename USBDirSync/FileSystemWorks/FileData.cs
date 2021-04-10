using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USBDirSync.FileSystemWorks
{
    public class FileData
    {
        public string RelativePath;
        public string Hash;
        public DateTime LastModifiedTime;

        public FileData(string RelativePath, string Hash, DateTime LastModifiedTime)
        {
            this.RelativePath = RelativePath;
            this.Hash = Hash;
            this.LastModifiedTime = LastModifiedTime;
        }
    }
}
