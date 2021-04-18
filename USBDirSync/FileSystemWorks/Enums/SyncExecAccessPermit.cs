using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USBDirSync.FileSystemWorks.Enums
{
    /// <summary>
    /// Flag enum that represents a limiter for SynchronizationExecuter in writing/changing files in directories.
    /// </summary>
    [Flags]
    public enum SyncExecAccessPermit
    {
        None,
        AccessToSource,
        AccessToTarget,
        AccessToBoth = AccessToSource | AccessToTarget
    }
}
