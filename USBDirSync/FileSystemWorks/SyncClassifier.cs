using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using USBDirSync.FileSystemWorks.DataStructures;
using USBDirSync.FileSystemWorks.Enums;

namespace USBDirSync.FileSystemWorks
{
    /* This is the important part of the program because it has to do everything with the Presents and Automation.
     * This class (SyncClassifier) is made for the purpose of making SyncAction state assignment automated based on the preferences passed as an argument.
     * Basically, the argument itself is a string that has to be parsed. Underneath this comment will be the explanation of how the string
     * should look like so it makes what its meant to be making. Just to clarify, the format was made before it was actually implemented. 
     * It means it might be error-prone.
     */

    /*============Format of the PCF (Preferences Classifier Format)============
     * 
     * The format is made for the file mask. So if you have the files corresponding to the mask and you have set
     * rules for it in PCS then it should be resolved like so:
     * 
     * ==Priorities==
     *  This means if several options exists at the same time the action that must be made have to be choosen by the priority.
     *  For example, if you have a compareaction of LMT sync (LMT:(S>T)) and turns out the LMT is the same, you can synchronize those files by
     *  the second option with lower priority for example EX:(S). It has to be with the lower priority so it will be computed after the LMT compareaction.
     * 
     *  FileMask #(1-32)#CompareAction          -- Priority of statement from 1 (The highest value) to 32 (the lowest value).
     *  
     *  Example: *.txt #31#LMT:(S>T)->Shr(T)    -- means any kind of action with priority 2.
     *  
     *  If the priority is not stated, its default value is 32 (the lowest value).
     *  
     * ==Actions==
     *  These represents the action that will be taken if the statement is choosen as the most priority one.
     *  
     *  Shr(S/T)                                -- Share files from Source/Target to Target/Source.
     *  Cpy(S/T)                                -- Copy files from Source/Target to Target/Source.
     *  Skp()                                   -- Skip files.
     *  Dlt()                                   -- Delete files.
     *  
     * ==Comparing operations==
     *  This operation is made for deciding which files should me taken from Source and which are from Target.
     *  
     *  These are the options that can be used to compare files:
     *      LMT                                 -- Last Modified Time.
     *      SZ                                  -- Length of the file.
     *      EX:(S/T)                            -- File existance in Source/Target.
     *  
     *  So it should be written like so:
     *      LMT:(S>T)->Shr(S)                   -- this means if the Source file is newer than the Target version then file will be shared to Target.
     *      SZ:(S<T)->Skp()                     -- this means if the Source file is older than the Target version then file will be skipped in processing.
     *      
     * ==File masks==
     *  File masks are needed so the program can apply rules to those files which are stated. For example resolve conflicts only for .gif files
     *  or only for .png format. All that will be handled by regex so, you can use regex knowledge to make it more advanced.
     *  
     *  File mask should me written like this:
     *      {FileNameMask}.{FileExtensionMask}
     *      
     * ==Examples of the recordings that has to be resolved==
     * 
     *  ! - defines where statement begins.
     * 
     *  If you need to get newest .txt files to Target directory from Source you write that:
     *      !*.txt LMT:(S>T)->Shr(S)            -- Share files which are selected by the Last Modified Time (newer in Source) from Source to Target
     *      !*.txt EX:(S)->Shr(S)               -- Share files which are exist in Source from Source to Target.
     *  
     *  If you need to switch between several statements that overrides each other just use priorities:
     *          This OVERRIDES 2.
     *      1 - ! *.txt #31#LMT:(S>T)->Shr(S)   -- Share files which are selected by the Last Modified Time (newer in Source) from Source to Target.
     *  
     *          This is OVERRIDED BY 1.
     *      2 - ! *.txt #32#LMT:(S>T)->Shr(T)   -- Share files which are selected by the Last Modified Time (newer in Source) from Source to Target. 
     *  
     *      And if you need to do 1st instead of 2nd just change 32 to 31 and vise versa.
     *      
     *      Important thing is that 
     *      ! *.txt LMT:(S<T)->Shr(T) DOES NOT OVERRIDE BOTH 1 AND 2.
     *      
     *  !!!Important!!!
     *      After all the masks, in the end of the file may be stated what to do with those files which havent passed the masks.
     *      
     *      For example:
     *          !ForLeft EX:(S)->Shr(S)
     *          !ForLeft EX:(T)->Shr(T)
     *      
     *      ForLeft marks for the files that wasnt applied to masks.
     */

    /// <summary>
    /// Singleton class that performs tasks of automated assignment SyncActionState based of passed preset paratemers.
    /// </summary>
    public static class SyncClassifier
    {
        public static List<string> ExtractStatements(string FileContent)
        {
            string[] statements = FileContent.Split(new string[] { "!" }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < statements.Length; i++)
            {
                statements[i] = statements[i].Replace("\r\n", "");
            }

            return statements.ToList();
        }

        public static List<StatementData> ExtractStatementsDataFromStatementStringList(List<string> StatementStringList) 
        {
            List<StatementData> statementDatas = new List<StatementData>();

            foreach (var item in StatementStringList)
            {
                statementDatas.Add(new StatementData(item));
            }

            return statementDatas;
        }

        public static void ClassifySyncDatas(List<SyncData> syncs, string StatementDataString) 
        {
            List<string> statements = ExtractStatements(StatementDataString);
            List<StatementData> statementDatas = ExtractStatementsDataFromStatementStringList(statements);

            ClassifyByRules(statementDatas, syncs);
        }

        private static void AssignSyncActionAndSyncDirection(SyncData syncData, SyncRule syncRule) 
        {
            if (syncRule.CompareOperation == "EX")
            {
                AssignActionByEXRule(syncData, syncRule);
            }
            else if (syncRule.CompareOperation == "LMT")
            {
                AssignActionByLMTRule(syncData, syncRule);
            }
            else if (syncRule.CompareOperation == "SZ")
            {
                AssignActionBySZRule(syncData, syncRule);
            }
        }

        private static void AssignActionByLMTRule(SyncData syncData, SyncRule syncRule)
        {
            if (syncData.SCS.HasFlag(SyncConflictState.NewerInSource))
            {
                if (syncRule.CompareOperationArgument.Contains(">"))
                {
                    if (syncRule.Action == "Dlt")
                    {
                        syncData.SAS = SyncActionState.Delete;
                        syncData.WasTriggeredBySyncRule = true;
                    }
                    else if (syncRule.Action == "Skp")
                    {
                        syncData.SAS = SyncActionState.Skip;
                        syncData.WasTriggeredBySyncRule = true;
                    }
                    else if (syncRule.Action == "Shr")
                    {
                        syncData.SAS = SyncActionState.Share;
                        syncData.SD = SyncDirection.Source;
                        syncData.WasTriggeredBySyncRule = true;
                    }
                    else if (syncRule.Action == "Cpy")
                    {
                        syncData.SAS = SyncActionState.Copy;
                        syncData.SD = SyncDirection.Source;
                        syncData.WasTriggeredBySyncRule = true;
                    }
                }
            }
            else if (syncData.SCS.HasFlag(SyncConflictState.OlderInSource))
            {
                if (syncRule.CompareOperationArgument.Contains("<"))
                {
                    if (syncRule.Action == "Dlt")
                    {
                        syncData.SAS = SyncActionState.Delete;
                        syncData.WasTriggeredBySyncRule = true;
                    }
                    else if (syncRule.Action == "Skp")
                    {
                        syncData.SAS = SyncActionState.Skip;
                        syncData.WasTriggeredBySyncRule = true;
                    }
                    else if (syncRule.Action == "Shr")
                    {
                        syncData.SAS = SyncActionState.Share;
                        syncData.SD = SyncDirection.Target;
                        syncData.WasTriggeredBySyncRule = true;
                    }
                    else if (syncRule.Action == "Cpy")
                    {
                        syncData.SAS = SyncActionState.Copy;
                        syncData.SD = SyncDirection.Target;
                        syncData.WasTriggeredBySyncRule = true;
                    }
                }
            }
        }

        private static void AssignActionBySZRule(SyncData syncData, SyncRule syncRule)
        {
            if (syncData.SCS.HasFlag(SyncConflictState.BiggerInSource))
            {
                if (syncRule.CompareOperationArgument.Contains(">"))
                {
                    if (syncRule.Action == "Dlt")
                    {
                        syncData.SAS = SyncActionState.Delete;
                        syncData.WasTriggeredBySyncRule = true;
                    }
                    else if (syncRule.Action == "Skp")
                    {
                        syncData.SAS = SyncActionState.Skip;
                        syncData.WasTriggeredBySyncRule = true;
                    }
                    else if (syncRule.Action == "Shr")
                    {
                        syncData.SAS = SyncActionState.Share;
                        syncData.SD = SyncDirection.Source;
                        syncData.WasTriggeredBySyncRule = true;
                    }
                    else if (syncRule.Action == "Cpy")
                    {
                        syncData.SAS = SyncActionState.Copy;
                        syncData.SD = SyncDirection.Source;
                        syncData.WasTriggeredBySyncRule = true;
                    }
                }
            }
            else if (syncData.SCS.HasFlag(SyncConflictState.SmallerInSource))
            {
                if (syncRule.CompareOperationArgument.Contains("<"))
                {
                    if (syncRule.Action == "Dlt")
                    {
                        syncData.SAS = SyncActionState.Delete;
                        syncData.WasTriggeredBySyncRule = true;
                    }
                    else if (syncRule.Action == "Skp")
                    {
                        syncData.SAS = SyncActionState.Skip;
                        syncData.WasTriggeredBySyncRule = true;
                    }
                    else if (syncRule.Action == "Shr")
                    {
                        syncData.SAS = SyncActionState.Share;
                        syncData.SD = SyncDirection.Target;
                        syncData.WasTriggeredBySyncRule = true;
                    }
                    else if (syncRule.Action == "Cpy")
                    {
                        syncData.SAS = SyncActionState.Copy;
                        syncData.SD = SyncDirection.Target;
                        syncData.WasTriggeredBySyncRule = true;
                    }
                }
            }
        }

        private static void AssignActionByEXRule(SyncData syncData, SyncRule syncRule)
        {
            if (syncData.SCS.HasFlag(SyncConflictState.DoesntExistInTarget) && (syncRule.CompareOperationArgument == "T"))
            {
                //****
                syncData.SAS = SyncActionState.Skip;
                return;
            }
            if (syncData.SCS.HasFlag(SyncConflictState.DoesntExistInSource) && (syncRule.CompareOperationArgument == "S"))
            {
                //****
                syncData.SAS = SyncActionState.Skip;
                return;
            }

            if (syncRule.Action == "Dlt")
            {
                syncData.SAS = SyncActionState.Delete;
                syncData.WasTriggeredBySyncRule = true;
            }
            else if (syncRule.Action == "Skp")
            {
                syncData.SAS = SyncActionState.Skip;
                syncData.WasTriggeredBySyncRule = true;
            }
            else if (syncRule.Action == "Shr")
            {
                syncData.SAS = SyncActionState.Share;

                if (syncRule.ActionArgument == "S")
                    syncData.SD = SyncDirection.Source;
                else
                    syncData.SD = SyncDirection.Target;
                syncData.WasTriggeredBySyncRule = true;
            }
            else if (syncRule.Action == "Cpy")
            {
                syncData.SAS = SyncActionState.Copy;

                if (syncRule.ActionArgument == "S")
                    syncData.SD = SyncDirection.Source;
                else
                    syncData.SD = SyncDirection.Target;
                syncData.WasTriggeredBySyncRule = true;
            }
        }

        private static void RunRule(SyncRule syncRule, SyncData syncData) 
        {
            if (syncRule.CompareOperation == "EX")
            {
                AssignSyncActionAndSyncDirection(syncData, syncRule);
            }
            else if ((syncData.SCS.HasFlag(SyncConflictState.OlderInSource) || syncData.SCS.HasFlag(SyncConflictState.NewerInSource)) 
                && syncRule.CompareOperation == "LMT")
            {
                AssignSyncActionAndSyncDirection(syncData, syncRule);
            }
            else if ((syncData.SCS.HasFlag(SyncConflictState.SmallerInSource) || syncData.SCS.HasFlag(SyncConflictState.BiggerInSource)) 
                && syncRule.CompareOperation == "SZ")
            {
                AssignSyncActionAndSyncDirection(syncData, syncRule);
            }
            else
                syncData.SAS = SyncActionState.Skip;
        }

        private static bool FileFitsMask(string FileName, string FileMask)
        {
            Regex mask = new Regex(FileMask.Replace(".", "[.]").Replace("*", ".*").Replace("?", "."));
            return mask.IsMatch(FileName);
        }

        public static void ClassifyByRules(List<StatementData> statementDatas, List<SyncData> syncs) 
        {
            HashSet<string> usedFileMasks = new HashSet<string>();
            bool[] fileMaskPassed = new bool[syncs.Count];
            StatementData forLeftStatementData = statementDatas[statementDatas.Count - 1];

            if (forLeftStatementData.FileMask == "ForLeft")
                statementDatas.RemoveAt(statementDatas.Count - 1);
            else
                forLeftStatementData = null;

            for (int i = 0; i < syncs.Count; i++)
            {
                string[] splittedFilePath = syncs[i].FD.RelativePath.Split(new string[] { "//", "\\\\" }, StringSplitOptions.RemoveEmptyEntries);
                string fileName = splittedFilePath[splittedFilePath.Length - 1];

                for (int j = 0; j < statementDatas.Count; j++)
                {
                    if (syncs[i].WasTriggeredBySyncRule)
                        break;

                    if (FileFitsMask(fileName, statementDatas[j].FileMask))
                    {
                        fileMaskPassed[i] = true;
                        usedFileMasks.Add(statementDatas[j].FileMask);
                        for (int k = 0; k < statementDatas[j].SyncRules.Count; k++)
                        {
                            if (syncs[i].WasTriggeredBySyncRule)
                                break;

                            RunRule(statementDatas[j].SyncRules[k], syncs[i]);
                        }
                    }
                }
            }

            if (forLeftStatementData != null)
            {
                for (int i = 0; i < syncs.Count; i++)
                {
                    if (syncs[i].WasTriggeredBySyncRule /*<= Might be reworked =>*/ || fileMaskPassed[i])
                        continue;

                    for (int k = 0; k < forLeftStatementData.SyncRules.Count; k++)
                    {
                        if (syncs[i].WasTriggeredBySyncRule)
                            break;

                        RunRule(forLeftStatementData.SyncRules[k], syncs[i]);
                    }
                }
            }
        }
    }
}