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
using USBDirSync.FileSystemWorks.Enums;
using USBDirSync.StorageWorks;

namespace USBDirSync
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<SyncData> CurrentSession;
        DirectoryData dd1;
        DirectoryData dd2;

        private void TestBtn_Click(object sender, EventArgs e)
        {
            dd1 = new DirectoryData(@"1");
            dd2 = new DirectoryData(@"2");

            CurrentSession = ConflictSolver.FormConflictFileDataList(dd1, dd2);

            FillTheTable();

            //ConflictSolver.PrioritizeConflictFileDataListAll(ans, FileSystemWorks.Enums.SyncPriority.Target);
            //SynchronizationExecuter.SynchronizeConflict(ans, dd1, dd2);
        }

        private void FillTheTable() 
        {
            foreach (var item in CurrentSession)
            {
                dataGridView1.Rows.Add(item.SAS.ToString(), item.SP.ToString(), item.SCS.ToString(), item.FD.RelativePath);
            }
        }

        private void skipBtn_Click(object sender, EventArgs e)
        {
            SetTableItemSASValueTo(SyncActionState.Skip);
        }

        private void shareBtn_Click(object sender, EventArgs e)
        {
            SetTableItemSASValueTo(SyncActionState.Share);
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            SetTableItemSASValueTo(SyncActionState.Delete);
        }

        private void copyBtn_Click(object sender, EventArgs e)
        {
            SetTableItemSASValueTo(SyncActionState.Copy);
        }

        private void SetTableItemSASValueTo(SyncActionState SAS) 
        {
            var selectedRows = dataGridView1.SelectedRows;

            for (int i = 0; i < selectedRows.Count; i++)
            {
                dataGridView1[0, selectedRows[i].Index].Value = SAS.ToString();
                CurrentSession[selectedRows[i].Index].SAS = SAS;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SynchronizationExecuter.accessOption = SyncExecAccessPermit.AccessToBoth;
            SynchronizationExecuter.SynchronizeConflict(CurrentSession, dd1, dd2);
        }
    }
}
