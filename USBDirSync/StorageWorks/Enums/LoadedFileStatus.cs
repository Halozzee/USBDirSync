using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USBDirSync.StorageWorks.Enums
{
    /// <summary>
    /// Enum that represents if the File was or was not changed from the last Fhsks record made. 
    /// Used for correcting DirectoryData after the list of LoadedFileStatus was formed by re-reading current data, so the data will be up to date.
    /// </summary>
    public enum LoadedFileStatus
    {
        DoesntExist,
        Modified,
        NotTouched
    }
}
