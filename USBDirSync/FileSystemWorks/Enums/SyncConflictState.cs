﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USBDirSync.FileSystemWorks.Enums
{
    public enum SyncConflictState
    {
        DoesntExistInSource,
        DoesntExistInTarget,
        OlderInSource,
        NewerInSource,
        UpToDate
    }
}
