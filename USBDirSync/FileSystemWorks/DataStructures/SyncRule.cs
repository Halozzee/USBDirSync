using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USBDirSync.FileSystemWorks.DataStructures
{
    public class SyncRule
    {
        public int Priority;
        public string CompareOperation;
        public string CompareOperationArgument;
        public string Action;
        public string ActionArgument;
    }
}
