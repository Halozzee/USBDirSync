using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USBDirSync.StorageWorks
{
    public class PresetData
    {
        public string SourceDirectoryPath;
        public string TargetDirectoryPath;
        public string StatementDataString;

        public PresetData(string SourceDirectoryPath, string TargetDirectoryPath, string StatementDataString)
        {
            this.SourceDirectoryPath = SourceDirectoryPath;
            this.TargetDirectoryPath = TargetDirectoryPath;
            this.StatementDataString = StatementDataString;
        }
    }
}