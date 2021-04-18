using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USBDirSync.FileSystemWorks.Enums;

namespace USBDirSync.FileSystemWorks.DataStructures
{
    /// <summary>
    /// Class that represents the data of the synchronization priorities and actions that has to be applied to the corresponding File.
    /// </summary>
    public class SyncData
    {
        /// <summary>
        /// FileData of the file corresponding to that SyncData.
        /// </summary>
        public FileData FD;
        /// <summary>
        /// Conflict state that specifies if the file does or doesnt exist or its newer or older or if its up to date.
        /// </summary>
        public SyncConflictState SCS;
        /// <summary>
        /// Priority that says what version (source one or the target one) of the corresponding file should be an exemplar.
        /// For example, when sharing file, if the Source priority is set and file is older in Source than in Target, no matter what
        /// the Source version of the file will be shared.
        /// </summary>
        public SyncPriority SP;
        /// <summary>
        /// The action that will be applied to the corresponding file. 
        /// (Skip file processing/Delete file/Share file to the other directory/Make the copy of the file with a simular name)
        /// </summary>
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
