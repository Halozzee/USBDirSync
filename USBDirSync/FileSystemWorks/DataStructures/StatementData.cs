using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USBDirSync.FileSystemWorks.DataStructures
{
    public class StatementData
    {
        public string FileMask;
        public List<SyncRule> SyncRules = new List<SyncRule>();

        public StatementData(string StatementString)
        {
            string[] splittedStatement = StatementString.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            FileMask = splittedStatement[0];

            for (int i = 1; i < splittedStatement.Length; i++)
            {
                SyncRules.Add(ExctractSyncRule(splittedStatement[i]));
            }

            CheckCorrectnessOfTheStatementData();

            SyncRules = SyncRules.OrderBy(o => o.Priority).ToList();
        }

        private void CheckRepeatingPriorities() 
        {
            HashSet<int> priorHS = new HashSet<int>();

            foreach (var item in SyncRules)
            {
                if (priorHS.Contains(item.Priority))
                    throw new ArgumentException("Two identical priorities! Check your statement rules!");
                else
                    priorHS.Add(item.Priority);
            }
        }

        private void CheckCorrectnessOfTheStatementData() 
        {
            for (int i = 0; i < SyncRules.Count; i++)
            {
                if (SyncRules[i].Priority > 32 || SyncRules[i].Priority < 1)
                {
                    throw new ArgumentOutOfRangeException("Priority[i]", $"Wrong priority range! Current: {SyncRules[i].Priority}. (1 <= Priority[i] <= 32)");
                }

                if(SyncRules[i].CompareOperation == "" || SyncRules[i].CompareOperation == " " || SyncRules[i].CompareOperationArgument == "" 
                    || SyncRules[i].CompareOperationArgument == " " || SyncRules[i].Action == "" || SyncRules[i].Action == " ")
                    throw new ArgumentException("Wrong parsing StatementString format!", "StatementString");

                if(SyncRules[i].Action != "Skp" && SyncRules[i].Action != "Dlt")
                    if(SyncRules[i].ActionArgument == "" || SyncRules[i].ActionArgument == " ")
                        throw new ArgumentException("Wrong parsing StatementString format!", "StatementString");
            }

            CheckRepeatingPriorities();
        }

        private SyncRule ExctractSyncRule(string splittedStatement)
        {
            SyncRule newRule = new SyncRule();

            string[] buffArr = splittedStatement.Split(new string[] { "#" }, StringSplitOptions.RemoveEmptyEntries);
            string[] splittedStatementCompareOperation;

            if (buffArr.Length > 1)
            {
                newRule.Priority = Convert.ToInt32(buffArr[0]);
                splittedStatementCompareOperation = buffArr[1].Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
            }
            else 
            {
                newRule.Priority = 32;
                splittedStatementCompareOperation = splittedStatement.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
            }

            int COargumentPositionStart = splittedStatementCompareOperation[0].IndexOf('(');

            string buff = splittedStatementCompareOperation[0].Substring(COargumentPositionStart,
                splittedStatementCompareOperation[0].IndexOf(')') - COargumentPositionStart + 1);

            buff = buff.Remove(0, 1);
            buff = buff.Remove(buff.Length - 1, 1);

            newRule.CompareOperationArgument = buff;

            newRule.CompareOperation = splittedStatementCompareOperation[0].Remove(COargumentPositionStart - 1,
                splittedStatementCompareOperation[0].IndexOf(')') - COargumentPositionStart + 2);

            int AargumentPositionStart = splittedStatementCompareOperation[1].IndexOf('(');

            buff = splittedStatementCompareOperation[1].Substring(AargumentPositionStart,
                splittedStatementCompareOperation[1].IndexOf(')') - AargumentPositionStart + 1);

            buff = buff.Remove(0, 1);
            buff = buff.Remove(buff.Length - 1, 1);

            newRule.ActionArgument = buff;

            newRule.Action = splittedStatementCompareOperation[1].Remove(AargumentPositionStart,
                splittedStatementCompareOperation[1].IndexOf(')') - AargumentPositionStart + 1);

            return newRule;
        }
    }
}
