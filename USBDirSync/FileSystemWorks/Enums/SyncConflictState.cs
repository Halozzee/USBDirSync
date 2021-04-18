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
    public enum SyncConflictState
    {
        DoesntExistInSource,
        DoesntExistInTarget,
        OlderInSource,
        NewerInSource,
        UpToDate
    }
}
