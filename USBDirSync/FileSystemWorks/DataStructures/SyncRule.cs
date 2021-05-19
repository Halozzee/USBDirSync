using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USBDirSync.FileSystemWorks.DataStructures
{
    /// <summary>
    /// Rule class made for automatic classification.
    /// </summary>
    public class SyncRule
    {
        /// <summary>
        /// Priority of the rule.
        /// </summary>
        public int Priority;
        /// <summary>
        /// Operation that will be used to use the rule (EX/LMT/SZ).
        /// </summary>
        public string CompareOperation;
        /// <summary>
        /// Argument that used to be working with CompareOperation (EX:(S/T), LMT:(S>/<T), SZ:(S>/<T)).
        /// </summary>
        public string CompareOperationArgument;
        /// <summary>
        /// Action that will be applied if the CompareOperation will fire (Shr, Skp, Dlt, Cpy).  
        /// </summary>
        public string Action;
        /// <summary>
        /// Argument that will be used with action Shr(S/T), Skp(), Dlt(), Cpy(S/T).
        /// </summary>
        public string ActionArgument;
    }
}
