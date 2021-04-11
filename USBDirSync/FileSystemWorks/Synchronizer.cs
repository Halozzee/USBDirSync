using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USBDirSync.FileSystemWorks.Enums;
using USBDirSync.FileSystemWorks.Structs;

namespace USBDirSync.FileSystemWorks
{
    public static class Synchronizer
    {
        public static List<SyncData> FormSynchronizationFileDataList(DirectoryData SourceData, DirectoryData TargetData) 
        {
            List<SyncData> result = new List<SyncData>();

            foreach (var item in SourceData.Files)
            {
                if (TargetData.CheckFileExistanceByRelativePath(item.RelativePath))
                {
                    result.Add(new SyncData(item, CompareFileDateTimeToState(item, TargetData.FindFileGetFileData(item.RelativePath))));
                }
                else
                {
                    result.Add(new SyncData(item, SyncConflictState.DoesntExist));
                }
            }

            return result;
        }

        private static SyncConflictState CompareFileDateTimeToState(FileData SourceData, FileData TargetData) 
        {
            if (TargetData.LastModifiedTime == SourceData.LastModifiedTime)
                return SyncConflictState.UpToDate;
            else if (TargetData.LastModifiedTime < SourceData.LastModifiedTime)
                return SyncConflictState.Newer;
            else
                return SyncConflictState.Older;
        }
    }
}
