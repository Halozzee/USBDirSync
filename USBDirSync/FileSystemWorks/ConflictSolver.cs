using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USBDirSync.FileSystemWorks.DataStructures;
using USBDirSync.FileSystemWorks.Enums;

namespace USBDirSync.FileSystemWorks
{
    /// <summary>
    /// Singleton class that performs actions of making conflict lists (defining what FileData's are not equal in hash and what are non-existant in the other 
    /// directory), prioritazing them (making SyncPriority for synchronization) and setting an action state for each of the FileData's.
    /// </summary>
    public static class ConflictSolver
    {
        /// <summary>
        /// Function that forms a SyncData list that represents the list of conflict statements which says if the file does exist in any of the directories or 
        /// if its old or if its up to date.
        /// </summary>
        /// <param name="SourceData">The directory being synchronized.</param>
        /// <param name="TargetData">The comparing directory to be synchronized with.</param>
        /// <returns>SyncData list that represents the list of conflict statements which says if the file does exist in any of the directories or 
        /// if its old or if its up to date.</returns>
        public static List<SyncData> FormConflictFileDataList(DirectoryData SourceData, DirectoryData TargetData)
        {
            List<SyncData> result = new List<SyncData>();

            foreach (var item in SourceData.Files)
            {
                if (TargetData.CheckFileExistanceByRelativePath(item.RelativePath))
                {
                    if (item.Hash == TargetData.FindFileGetFileHash(item.RelativePath))
                        continue;

                    SyncConflictState currentItemSCS = CompareFileDateTimeToState(item, TargetData.FindFileGetFileData(item.RelativePath));

                    if(currentItemSCS != SyncConflictState.UpToDate)
                        result.Add(new SyncData(item, currentItemSCS));
                }
                else
                {
                    result.Add(new SyncData(item, SyncConflictState.DoesntExistInTarget));
                }
            }

            List<FileData> FilesNonExistantInSource = TargetData.Files.FindAll(x => SourceData.Files.FindIndex(y => y.RelativePath == x.RelativePath) == -1);

            for (int i = 0; i < FilesNonExistantInSource.Count; i++)
            {
                result.Add(new SyncData(FilesNonExistantInSource[i], SyncConflictState.DoesntExistInSource));
            }

            return result;
        }

        /// <summary>
        /// Function that prioriteze all the SyncData for a specific SyncPriority.
        /// </summary>
        /// <param name="SDList">The list of the SyncData to be prioritized.</param>
        /// <param name="SPToSet">Specific SyncPriority to be set.</param>
        public static void PrioritizeConflictFileDataListAll(List<SyncData> SDList, SyncPriority SPToSet)
        {
            for (int i = 0; i < SDList.Count; i++)
            {
                SDList[i].SP = SPToSet;
            }
        }

        //public static void PrioritizeConflictFileDataListSingle(List<SyncData> SDList, SyncPriority SPToSet)
        //{
        //}

        /// <summary>
        /// Function that assigns specific SyncData to specific SyncActionState.
        /// </summary>
        /// <param name="SD">The list of the SyncData to be prioritized.</param>
        /// <param name="SASToSet">Specific SyncActionState that will be applied to this SyncData.</param>
        public static void AssignActionStateToSyncData(SyncData SD, SyncActionState SASToSet) 
        {
            SD.SAS = SASToSet;
        }

        /// <summary>
        /// Function that compared two FileData's to determine whether the Files are up to date or one of them is older than the other one.
        /// </summary>
        /// <param name="SourceData">First FileData representing the file.</param>
        /// <param name="TargetData">Second FileData representing the file.</param>
        /// <returns>SyncConflictState corresponding to their last modified time.</returns>
        private static SyncConflictState CompareFileDateTimeToState(FileData SourceData, FileData TargetData) 
        {
            if (TargetData.LastModifiedTime == SourceData.LastModifiedTime)
                return SyncConflictState.UpToDate;
            else if (TargetData.LastModifiedTime < SourceData.LastModifiedTime)
                return SyncConflictState.NewerInSource;
            else
                return SyncConflictState.OlderInSource;
        }
    }
}
