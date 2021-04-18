using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USBDirSync.FileSystemWorks.DataStructures;
using USBDirSync.FileSystemWorks.Enums;

namespace USBDirSync.FileSystemWorks
{
    /// <summary>
    /// Singleton class that performs execution of synchronization based on the Conflict Lists made by ConflictSolver singleton class.
    /// </summary>
    public static class SynchronizationExecuter
    {
        /// <summary>
        /// Flag enum that represents a limiter for SynchronizationExecuter in writing/changing files in directories.
        /// </summary>
        public static SyncExecAccessPermit accessOption;

        /// <summary>
        /// Function that performs synchronization actions based of SyncData parameters and specific SyncExecAccessPermit.
        /// </summary>
        /// <param name="ConflictList">The list of SyncData's which specifies how conflict of the specific file should be solved.</param>
        /// <param name="SourceData">The directory being synchronized.</param>
        /// <param name="TargetData">The comparing directory to be synchronized with.</param>
        public static void SynchronizeConflict(List<SyncData> ConflictList, DirectoryData SourceData, DirectoryData TargetData) 
        {
            accessOption = SyncExecAccessPermit.AccessToBoth;

            foreach (var item in ConflictList)
            {
                switch (item.SCS)
                {
                    case SyncConflictState.DoesntExistInSource:
                        if (accessOption.HasFlag(SyncExecAccessPermit.AccessToSource))
                            SolveNonExistantFileToOtherDirectory(SourceData, TargetData, item);
                        break;
                    case SyncConflictState.DoesntExistInTarget:
                        if (accessOption.HasFlag(SyncExecAccessPermit.AccessToTarget))
                            SolveNonExistantFileToOtherDirectory(TargetData, SourceData, item);
                        break;
                    case SyncConflictState.OlderInSource:
                    case SyncConflictState.NewerInSource:
                        SolveStatedPrioritizedConflict(SourceData, TargetData, item);
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Function that performs action of synchronization to a file which doesnt exist in one of the two directories based on SyncData parameters.
        /// </summary>
        /// <param name="SourceData">The directory being synchronized.</param>
        /// <param name="TargetData">The comparing directory to be synchronized with.</param>
        /// <param name="SD">Corresponding SyncData with parameters to decide what to do with the file.</param>
        private static void SolveNonExistantFileToOtherDirectory(DirectoryData SourceData, DirectoryData TargetData, SyncData SD)
        {
            switch (SD.SAS)
            {
                case SyncActionState.Skip:
                    return;
                case SyncActionState.Delete:
                    File.Delete(TargetData.FindFileGetLocalPath(SD.FD.RelativePath));
                    break;
                case SyncActionState.Share:
                    File.Copy(TargetData.FindFileGetLocalPath(SD.FD.RelativePath), SourceData.RootPath + "\\" + SD.FD.RelativePath);
                    break;
                case SyncActionState.Copy:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Function that Deletes the existing file in the destination and then Copies it from the Source directory.
        /// </summary>
        /// <param name="SourceFile">Path to a file being copied</param>
        /// <param name="TargetFile">Path to where the file should be copied.</param>
        private static void UpdateExistingFile(string SourceFile, string TargetFile) 
        {
            if (File.Exists(TargetFile))
                File.Delete(TargetFile);
            File.Copy(SourceFile, TargetFile);
        }

        /// <summary>
        /// Function that performs action of synchronization based on the corresponding SyncData which has to contain SyncActionState and SyncPriority.
        /// </summary>
        /// <param name="SourceData">The directory being synchronized.</param>
        /// <param name="TargetData">The comparing directory to be synchronized with.</param>
        /// <param name="SD">Corresponding SyncData with parameters to decide what to do with the file.</param>
        private static void SolveStatedPrioritizedConflict(DirectoryData SourceData, DirectoryData TargetData, SyncData SD) 
        {
            switch (SD.SAS)
            {
                case SyncActionState.Skip:
                    return;
                case SyncActionState.Delete:
                    if (accessOption.HasFlag(SyncExecAccessPermit.AccessToTarget))
                        File.Delete(TargetData.FindFileGetLocalPath(SD.FD.RelativePath));
                    if (accessOption.HasFlag(SyncExecAccessPermit.AccessToSource))
                        File.Delete(SourceData.FindFileGetLocalPath(SD.FD.RelativePath));
                    break;
                case SyncActionState.Share:
                    if (SD.SP != SyncPriority.None)
                    {
                        if (SD.SP == SyncPriority.Target && accessOption.HasFlag(SyncExecAccessPermit.AccessToSource))
                        {
                            UpdateExistingFile(TargetData.FindFileGetLocalPath(SD.FD.RelativePath), SourceData.FindFileGetLocalPath(SD.FD.RelativePath));
                        }
                        else if (SD.SP == SyncPriority.Source && accessOption.HasFlag(SyncExecAccessPermit.AccessToTarget))
                        {
                            UpdateExistingFile(SourceData.FindFileGetLocalPath(SD.FD.RelativePath), TargetData.FindFileGetLocalPath(SD.FD.RelativePath));
                        }
                    }
                    break;
                case SyncActionState.Copy:
                    break;
                default:
                    break;
            } 
        }
    }
}
