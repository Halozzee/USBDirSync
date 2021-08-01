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
        List<SyncData> CurrentSession;
        PresetData CurrentPD;
        DirectoryData dd1;
        DirectoryData dd2;

        public Form1()
        {
            InitializeComponent();
            LoadPresetsComboBox();
            USBConnectionNotifier.Initialize();
            USBPresetApplier.Initialize();
            USBPresetApplier.PresetApplied += USBPresetApplier_OnPresetApplied;
        }

        private void USBPresetApplier_OnPresetApplied(object sender, PresetAppliedEventArgs e)
        {
            int index = PresetsComboBox.Items.IndexOf(e.AppliedPresetName);

            if (index == -1)
                return;

            PresetsComboBox.Invoke(((MethodInvoker)delegate
            {
                PresetsComboBox.SelectedIndex = index;
            }));
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

        private void TestBtn_Click(object sender, EventArgs e)
        {
            FindConflicts(CurrentPD, false);

            FillTheTable();
        }

        private void FindConflicts(PresetData PD, bool ClassifyByPresetDataRules)
        {
            dd1 = new DirectoryData(PD.SourceDirectoryPath);
            dd2 = new DirectoryData(PD.TargetDirectoryPath);

            CurrentSession = ConflictSolver.FormConflictFileDataList(dd1, dd2);

            if(ClassifyByPresetDataRules)
                SyncClassifier.ClassifySyncDatas(CurrentSession, PD.StatementDataString);
        }

        private void FillTheTable() 
        {
            ConflictDataGridView.Rows.Clear();

            int rowCounter = 0;
            foreach (var item in CurrentSession)
            {
                string syncSign = "?";

                if (item.SAS == SyncActionState.Share)
                {
                    switch (item.SD)
                    {
                        case SyncDirection.Source:
                            syncSign = ">>";
                            break;
                        case SyncDirection.Target:
                            syncSign = "<<";
                            break;
                        default:
                            break;
                    }
                }

                if (item.SAS == SyncActionState.Delete)
                    syncSign = "X";

                if (item.SAS == SyncActionState.Skip)
                    syncSign = "_";

                if (item.SCS.HasFlag(SyncConflictState.BiggerInSource) || item.SCS.HasFlag(SyncConflictState.NewerInSource)
                    || item.SCS.HasFlag(SyncConflictState.OlderInSource) || item.SCS.HasFlag(SyncConflictState.SmallerInSource))
                {
                    string SourceConflictInfo, TargetConflictInfo;
                    GetInfoStringAboutConflict(item, out SourceConflictInfo, out TargetConflictInfo);

                    ConflictDataGridView.Rows.Add(item.FD.RelativePath + SourceConflictInfo, syncSign, item.FD.RelativePath + TargetConflictInfo);
                    ApplyColorToRow(rowCounter, Color.Yellow, Color.Yellow, Color.Yellow);
                }
                else if (item.SCS.HasFlag(SyncConflictState.DoesntExistInSource))
                {
                    ConflictDataGridView.Rows.Add("", syncSign, item.FD.RelativePath);
                    ApplyColorToRow(rowCounter, Color.Red, Color.Red, Color.Green);
                }
                else if (item.SCS.HasFlag(SyncConflictState.DoesntExistInTarget))
                {
                    ConflictDataGridView.Rows.Add(item.FD.RelativePath, syncSign, "");
                    ApplyColorToRow(rowCounter, Color.Green, Color.Red, Color.Red);
                }
                else if (item.SCS.HasFlag(SyncConflictState.UpToDate))
                {
                    ConflictDataGridView.Rows.Add(item.FD.RelativePath, "=", item.FD.RelativePath);
                    ApplyColorToRow(rowCounter, Color.Green, Color.Green, Color.Green);
                }
                rowCounter++;
            }
        }

        private static void GetInfoStringAboutConflict(SyncData item, out string SourceConflictInfo, out string TargetConflictInfo)
        {
            SourceConflictInfo = " (";
            TargetConflictInfo = " (";

            if (item.SCS.HasFlag(SyncConflictState.BiggerInSource))
            {
                SourceConflictInfo += "Bigger";
                TargetConflictInfo += "Smaller";
            }
            else if (item.SCS.HasFlag(SyncConflictState.SmallerInSource))
            {
                SourceConflictInfo += "Smaller";
                TargetConflictInfo += "Bigger";
            }

            if (item.SCS.HasFlag(SyncConflictState.OlderInSource))
            {
                SourceConflictInfo += ", Older";
                TargetConflictInfo += ", Newer";
            }
            else if (item.SCS.HasFlag(SyncConflictState.NewerInSource))
            {
                SourceConflictInfo += ", Newer";
                TargetConflictInfo += ", Older";
            }

            SourceConflictInfo += ")";
            TargetConflictInfo += ")";
        }

        private void ApplyColorToRow(int RowIndex, params Color[] Colors)
        {
            for (int i = 0; i < Colors.Length; i++)
            {
                ConflictDataGridView.Rows[RowIndex].Cells[i].Style.BackColor = Colors[i];
            }
        }

        private void skipBtn_Click(object sender, EventArgs e)
        {
            SetTableItemSASValueTo(SyncActionState.Skip, SyncDirection.None);
        }

        private void ShareSourceBtn_Click(object sender, EventArgs e)
        {
            SetTableItemSASValueTo(SyncActionState.Share, SyncDirection.Source);
        }

        private void ShareTargetBtn_Click(object sender, EventArgs e)
        {
            SetTableItemSASValueTo(SyncActionState.Share, SyncDirection.Target);
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            SetTableItemSASValueTo(SyncActionState.Delete, SyncDirection.None);
        }

        private void copyBtn_Click(object sender, EventArgs e)
        {
            SetTableItemSASValueTo(SyncActionState.Copy, SyncDirection.None);
        }

        private void SetTableItemSASValueTo(SyncActionState SAS, SyncDirection SD) 
        {
            var selectedRows = ConflictDataGridView.SelectedRows;

            for (int i = 0; i < selectedRows.Count; i++)
            {
                switch (SAS)
                {
                    case SyncActionState.Skip:
                        ConflictDataGridView[1, selectedRows[i].Index].Value = "_";
                        break;
                    case SyncActionState.Delete:
                        ConflictDataGridView[1, selectedRows[i].Index].Value = "X";
                        break;
                    case SyncActionState.Share:
                        if (SD == SyncDirection.Source)
                        {
                            ConflictDataGridView[1, selectedRows[i].Index].Value = ">>";
                            CurrentSession[selectedRows[i].Index].SD = SD;
                        }
                        else if (SD == SyncDirection.Target)
                        {
                            ConflictDataGridView[1, selectedRows[i].Index].Value = "<<";
                            CurrentSession[selectedRows[i].Index].SD = SD;
                        }
                        break;
                    case SyncActionState.Copy:
                        break;
                    default:
                        break;
                }
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
            PresetWorkForm PWF = new PresetWorkForm();

            if (PWF.ShowDialog() == DialogResult.OK)
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

        private void button2_Click(object sender, EventArgs e)
        {
            PresetWorkForm pwf = new PresetWorkForm();
            pwf.Show();
        }

        private void SourceDirDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
