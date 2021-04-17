using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USBDirSync.FileSystemWorks.Enums;

namespace USBDirSync.FileSystemWorks.DataStructures
{
    public class SyncData
    {
        public FileData FD;
        public SyncConflictState SCS;
        public SyncPriority SP;
        public SyncActionState SAS;

        public SyncData(FileData fD, SyncConflictState sCS)
        {
            FD = fD;
            SCS = sCS;
            SP = SyncPriority.None;
            SAS = SyncActionState.Share;
        }

        public SyncData(FileData fD, SyncConflictState sCS, SyncActionState sAS)
        {
            FD = fD;
            SCS = sCS;
            SP = SyncPriority.None;
            SAS = sAS;
        }

        public SyncData(FileData fD, SyncConflictState sCS, SyncPriority sP)
        {
            FD = fD;
            SCS = sCS;
            SP = sP;
            SAS = SyncActionState.Share;
        }

        public SyncData(FileData fD, SyncConflictState sCS, SyncPriority sP, SyncActionState sAS)
        {
            FD = fD;
            SCS = sCS;
            SP = sP;
            SAS = sAS;
        }
    }
}
