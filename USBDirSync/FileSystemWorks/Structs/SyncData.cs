using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USBDirSync.FileSystemWorks.Enums;

namespace USBDirSync.FileSystemWorks.Structs
{
    public struct SyncData
    {
        public FileData DataOfFile;
        public SyncConflictState SCS;

        public SyncData(FileData dataOfFile, SyncConflictState sCS)
        {
            DataOfFile = dataOfFile;
            SCS = sCS;
        }
    }
}
