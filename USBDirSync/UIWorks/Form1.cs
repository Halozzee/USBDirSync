using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using USBDirSync.FileSystemWorks;
using USBDirSync.FileSystemWorks.DataStructures;
using USBDirSync.StorageWorks;

namespace USBDirSync
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void TestBtn_Click(object sender, EventArgs e)
        {
            DirectoryData dd1 = new DirectoryData(@"1");
            DirectoryData dd2 = new DirectoryData(@"2");

            var ans = ConflictSolver.FormConflictFileDataList(dd1, dd2);
            ConflictSolver.PrioritizeConflictFileDataListAll(ans, FileSystemWorks.Enums.SyncPriority.Target);
            SynchronizationExecuter.SynchronizeConflict(ans, dd1, dd2);
        }
    }
}
