using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USBDirSync.FileSystemWorks.Enums
{
    /// <summary>
    /// Flag enum that represents a limiter for SynchronizationExecuter in writing files in directories in which file doesnt exist
    /// from those in which that file does exist.
    /// </summary>
    [Flags]
    public enum SyncShareAllowanceNonExistnant
    {
        None = 1,
        ShareToSource = 2,
        ShareToTarget = 4,
        ShareToBoth = ShareToSource | ShareToTarget
    }
}
