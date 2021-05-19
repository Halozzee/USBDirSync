using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USBDirSync.FileSystemWorks.Enums
{
    /// <summary>
    /// Conflict state that specifies if the file does or doesnt exist or its newer or older or if its up to date.
    /// </summary>
    [Flags]
    public enum SyncConflictState
    {
        DoesntExistInSource = 1,
        DoesntExistInTarget = 2,
        OlderInSource = 4,
        NewerInSource = 8,
        SmallerInSource = 16,
        BiggerInSource = 32,
        UpToDate = 64
    }
}
