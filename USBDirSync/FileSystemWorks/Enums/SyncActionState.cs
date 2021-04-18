using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USBDirSync.FileSystemWorks.Enums
{
    /// <summary>
    /// The action that will be applied to the corresponding file. 
    /// (Skip file processing/Delete file/Share file to the other directory/Make the copy of the file with a simular name)
    /// </summary>
    public enum SyncActionState
    {
        Skip,
        Delete,
        Share,
        Copy
    }
}
