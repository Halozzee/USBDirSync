using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USBDirSync.StorageWorks
{
    /// <summary>
    /// Class that represents Preset data.
    /// </summary>
    public class PresetData
    {
        /// <summary>
        /// Full path to a Source Directory.
        /// </summary>
        public string SourceDirectoryPath;
        /// <summary>
        /// Full path to a Target Directory.
        /// </summary>
        public string TargetDirectoryPath;
        /// <summary>
        /// StatementDataString that will be parsed into rules.
        /// </summary>
        public string StatementDataString;

        public PresetData(string SourceDirectoryPath, string TargetDirectoryPath, string StatementDataString)
        {
            this.SourceDirectoryPath = SourceDirectoryPath;
            this.TargetDirectoryPath = TargetDirectoryPath;
            this.StatementDataString = StatementDataString;
        }
    }
}