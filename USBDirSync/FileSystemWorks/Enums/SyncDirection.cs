using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USBDirSync.FileSystemWorks.Enums
{
    /// <summary>
    /// Priority that says what version (source one or the target one) of the corresponding file should be an exemplar.
    /// For example, when sharing file, if the Source priority is set and file is older in Source than in Target, no matter what
    /// the Source version of the file will be shared.
    /// </summary>
    public enum SyncDirection
    {
        None,
        Source,
        Target
    }
}
