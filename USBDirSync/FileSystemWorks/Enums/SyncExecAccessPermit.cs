using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USBDirSync.FileSystemWorks.Enums
{
    [Flags]
    public enum SyncExecAccessPermit
    {
        None,
        AccessToSource,
        AccessToTarget,
        AccessToBoth = AccessToSource | AccessToTarget
    }
}
