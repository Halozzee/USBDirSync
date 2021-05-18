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
    public static class SyncExecuter
    {
        /// <summary>
        /// Flag enum that represents a limiter for SynchronizationExecuter in writing files in directories in which file doesnt exist
        /// from those in which that file does exist.
        /// </summary>
        public static SyncShareAllowanceNonExistnant accessOption;

        /// <summary>
        /// Function that performs synchronization actions based of SyncData parameters and specific SyncExecAccessPermit.
        /// </summary>
        /// <param name="ConflictList">The list of SyncData's which specifies how conflict of the specific file should be solved.</param>
        /// <param name="SourceData">The directory being synchronized.</param>
        /// <param name="TargetData">The comparing directory to be synchronized with.</param>
        public static void SynchronizeConflict(List<SyncData> ConflictList, DirectoryData SourceData, DirectoryData TargetData) 
        {
            foreach (var item in ConflictList)
            {
                if (item.SCS.HasFlag(SyncConflictState.DoesntExistInSource))
                {
                    if (accessOption.HasFlag(SyncShareAllowanceNonExistnant.ShareToSource))
                        SolveNonExistantFileToOtherDirectory(SourceData, TargetData, item);
                }
                else if (item.SCS.HasFlag(SyncConflictState.DoesntExistInTarget))
                {
                    if (accessOption.HasFlag(SyncShareAllowanceNonExistnant.ShareToTarget))
                        SolveNonExistantFileToOtherDirectory(TargetData, SourceData, item);
                }
                else if(item.SCS.HasFlag(SyncConflictState.OlderInSource) || item.SCS.HasFlag(SyncConflictState.NewerInSource) ||
                    item.SCS.HasFlag(SyncConflictState.BiggerInSource) || item.SCS.HasFlag(SyncConflictState.OlderInSource))
                    SolveStatedPrioritizedConflict(SourceData, TargetData, item);
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
        /// Function that performs action of synchronization based on the corresponding SyncData which has to contain SyncActionState and SyncDirection.
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
                        File.Delete(TargetData.FindFileGetLocalPath(SD.FD.RelativePath));
                        File.Delete(SourceData.FindFileGetLocalPath(SD.FD.RelativePath));
                    break;
                case SyncActionState.Share:
                    if (SD.SD != SyncDirection.None)
                    {
                        if (SD.SD == SyncDirection.Target)
                        {
                            UpdateExistingFile(TargetData.FindFileGetLocalPath(SD.FD.RelativePath), SourceData.FindFileGetLocalPath(SD.FD.RelativePath));
                        }
                        else if (SD.SD == SyncDirection.Source)
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
