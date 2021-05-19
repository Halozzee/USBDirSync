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
using USBDirSync.UIWorks;
using USBDirSync.USBWorks;

namespace USBDirSync
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadPresetsComboBox();
            USBConnectionNotifier.Initialize();
        }

        private void LoadPresetsComboBox()
        {
            PresetsComboBox.Items.Clear();
            PresetsComboBox.Items.Add("Empty");
            string[] presentsList = PresetIO.ReadPresetsList();
            if (presentsList != null && presentsList.Length > 0)
                PresetsComboBox.Items.AddRange(presentsList);
            PresetsComboBox.SelectedIndex = 0;
        }

        List<SyncData> CurrentSession;
        PresetData CurrentPD;
        DirectoryData dd1;
        DirectoryData dd2;

        private void TestBtn_Click(object sender, EventArgs e)
        {
            dd1 = new DirectoryData(CurrentPD.SourceDirectoryPath);
            dd2 = new DirectoryData(CurrentPD.TargetDirectoryPath);

            CurrentSession = ConflictSolver.FormConflictFileDataList(dd1, dd2);

            SyncClassifier.ClassifySyncDatas(CurrentSession, CurrentPD.StatementDataString);

            FillTheTable();
        }

        private void FillTheTable() 
        {
            dataGridView1.Rows.Clear();
            foreach (var item in CurrentSession)
            {
                dataGridView1.Rows.Add(item.SAS.ToString(), item.SD.ToString(), item.SCS.ToString(), item.FD.RelativePath);
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
            SyncExecuter.accessOption = SyncShareAllowanceNonExistnant.ShareToBoth;
            SyncExecuter.SynchronizeConflict(CurrentSession, dd1, dd2);
        }

        private void PresetsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(((string)PresetsComboBox.SelectedItem) != "Empty")
                CurrentPD = PresetIO.ReadPresetDataFromFile((string)PresetsComboBox.SelectedItem);
        }

        private void MakePresetBtn_Click(object sender, EventArgs e)
        {
            PresetMakingForm pmf = new PresetMakingForm();

            if (pmf.ShowDialog() == DialogResult.OK)
            {
                LoadPresetsComboBox();
            }
        }

        private void DeletePresetBtn_Click(object sender, EventArgs e)
        {
            if (((string)PresetsComboBox.SelectedItem) != "Empty")
            {
                File.Delete((string)PresetsComboBox.SelectedItem);
                PresetsComboBox.Items.Remove(PresetsComboBox.SelectedItem);
                PresetsComboBox.SelectedIndex = 0;
            }
        }

        private void MakeUSBSetupBtn_Click(object sender, EventArgs e)
        {
            USBToPresetMakingForm UPMF = new USBToPresetMakingForm();

            UPMF.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
