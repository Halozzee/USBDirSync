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
    public static class SynchronizationExecuter
    {
        public static SyncExecAccessPermit accessOption;
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
                        SolveTimedPrioritizedConflict(SourceData, TargetData, item);
                        break;
                    default:
                        break;
                }
            }
        }

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

        private static void UpdateExistingFile(string SourceFile, string TargetFile) 
        {
            if (File.Exists(TargetFile))
                File.Delete(TargetFile);
            File.Copy(SourceFile, TargetFile);
        }

        private static void SolveTimedPrioritizedConflict(DirectoryData SourceData, DirectoryData TargetData, SyncData SD) 
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
