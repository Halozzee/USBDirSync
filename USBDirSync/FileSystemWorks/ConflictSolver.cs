using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USBDirSync.FileSystemWorks.DataStructures;
using USBDirSync.FileSystemWorks.Enums;

namespace USBDirSync.FileSystemWorks
{
    public static class ConflictSolver
    {
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

        public static void PrioritizeConflictFileDataListAll(List<SyncData> SDList, SyncPriority SPToSet)
        {
            for (int i = 0; i < SDList.Count; i++)
            {
                SDList[i].SP = SPToSet;
            }
        }

        public static void PrioritizeConflictFileDataListSingle(List<SyncData> SDList, SyncPriority SPToSet)
        {
        }

        public static void AssignActionStateToSyncData(SyncData SD, SyncActionState SASToSet) 
        {
            SD.SAS = SASToSet;
        }

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
