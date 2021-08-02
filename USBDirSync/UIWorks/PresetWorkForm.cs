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

namespace USBDirSync.UIWorks
{
    public partial class PresetWorkForm : Form
    {
        bool _editingExistingPreset;
        bool _editingExistingRule;

        string _oldPresetName = "";

        PresetData _currentPD;
        List<SyncRule> _currentPDSyncRules = new List<SyncRule>();

        public PresetWorkForm()
        {
            InitializeComponent();
        }

        private void PresetNamesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PresetNamesListView.SelectedIndices.Count > 0)
            {
                _currentPD = PresetIO.ReadPresetDataFromFile("Presets\\" + (string)PresetNamesListView.SelectedItems[0].Text + ".json");

                PresetNameTextBox.Text = (string)PresetNamesListView.SelectedItems[0].Text;
                SourcePathTextBox.Text = _currentPD.SourceDirectoryPath;
                TargetPathTextBox.Text = _currentPD.TargetDirectoryPath;

                _editingExistingPreset = true;
                _oldPresetName = PresetNameTextBox.Text;

                LoadStatementsList(_currentPD.StatementDataString);
            }
            else
            {
                _oldPresetName = "";
                PresetNameTextBox.Text = "";
                SourcePathTextBox.Text = "";
                TargetPathTextBox.Text = "";

                _currentPD = null;
                _editingExistingPreset = false;

                ClearStatementRuleData();
            }
            SetChangesMadeFlag(false);
        }

        private void LoadStatementsList(string StatementDataString) 
        {
            RulesListView.Items.Clear();

            List<string> statements = SyncClassifier.ExtractStatements(StatementDataString);
            var currentPDStatementDatas = SyncClassifier.ExtractStatementsDataFromStatementStringList(statements);

            foreach (var item in currentPDStatementDatas)
            {
                foreach (var rule in item.SyncRules)
                {
                    _currentPDSyncRules.Add(rule);
                    RulesListView.Items.Add(item.FileMask);
                }
            }
        }

        private void LoadStatementRuleData(string FileMask, SyncRule SR) 
        {
            FileMaskTextBox.Text = FileMask;
            PriorityNumericUpDown.Value = SR.Priority;
            CompareOperationComboBox.Text = SR.CompareOperation;
            CompareOperationArgumentComboBox.Text = SR.CompareOperationArgument;
            ActionComboBox.Text = SR.Action;
            ActionArgumentComboBox.Text = SR.ActionArgument;
        }

        private void ClearStatementRuleData()
        {
            FileMaskTextBox.Text = "";
            PriorityNumericUpDown.Value = 1;
            CompareOperationComboBox.Text = "";
            CompareOperationArgumentComboBox.Text = "";
            ActionComboBox.Text = "";
            ActionArgumentComboBox.Text = "";
        }

        private void SelectSourcePathBtn_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                SourcePathTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void SelectTargetPathBtn_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                TargetPathTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void PresetWorkForm_Load(object sender, EventArgs e)
        {
            string[] presentsList = PresetIO.ReadPresetsList();
            if (presentsList != null && presentsList.Length > 0)
            {
                for (int i = 0; i < presentsList.Length; i++)
                {
                    string clearedFileName = presentsList[i].Replace("Presets\\", "").Replace(".json", "");
                    PresetNamesListView.Items.Add(clearedFileName);
                }
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (IsThereSameNamePreset(PresetNameTextBox.Text))
            {
                MessageBox.Show("This name is busy!");
                PresetNameTextBox.Text = (string)PresetNamesListView.SelectedItems[0].Text;
                return;
            }

            SetChangesMadeFlag(false);

            if (_editingExistingPreset)
            {
                UpdatePresetNameOnAllUSBToPreset("Presets\\" + (string)PresetNamesListView.SelectedItems[0].Text + ".json", "Presets\\" + PresetNameTextBox.Text + ".json");
                File.Delete("Presets\\" + (string)PresetNamesListView.SelectedItems[0].Text + ".json");
                PresetData PD = new PresetData(SourcePathTextBox.Text, TargetPathTextBox.Text, GetStatementDataStringFromRules());
                PresetIO.WritePresetDataToFile(PD, "Presets\\" + PresetNameTextBox.Text + ".json");
                PresetNamesListView.Items[PresetNamesListView.SelectedIndices[0]].Text = PresetNameTextBox.Text;
            }
            else
            {
                PresetData PD = new PresetData(SourcePathTextBox.Text, TargetPathTextBox.Text, GetStatementDataStringFromRules());
                PresetIO.WritePresetDataToFile(PD, "Presets\\" + PresetNameTextBox.Text + ".json");
                PresetNamesListView.Items.Add(PresetNameTextBox.Text);
            }
        }

        private string GetStatementDataStringFromRules() 
        {
            //! *.txt #31#LMT:(S>T)->Shr(S)

            Dictionary<string, List<SyncRule>> FilemaskToRules = new Dictionary<string, List<SyncRule>>();

            for (int i = 0; i < RulesListView.Items.Count; i++)
            {
                if (FilemaskToRules.ContainsKey(RulesListView.Items[i].Text))
                {
                    FilemaskToRules[RulesListView.Items[i].Text].Add(_currentPDSyncRules[i]);
                }
                else
                {
                    FilemaskToRules.Add(RulesListView.Items[i].Text, new List<SyncRule>());
                    FilemaskToRules[RulesListView.Items[i].Text].Add(_currentPDSyncRules[i]);
                }
            }

            string result = "";

            foreach (var item in FilemaskToRules)
            {
                string bufferResult = "! " + item.Key + " ";

                int cntr = 0;
                foreach (var rule in item.Value)
                {
                    cntr++;
                    bufferResult += $"#{rule.Priority}#{rule.CompareOperation}:({rule.CompareOperationArgument})->{rule.Action}({rule.ActionArgument})";
                    if (item.Value.Count > cntr)
                        bufferResult += " ";
                }

                result += bufferResult + "\r\n";
            }

            return result;
        }

        private bool IsThereSameNamePreset(string NameToCheck) 
        {
            for (int i = 0; i < PresetNamesListView.Items.Count; i++)
            {
                if (PresetNamesListView.Items[i].Text == NameToCheck && _oldPresetName != NameToCheck)
                    return true;
            }
            return false;
        }

        private void UpdatePresetNameOnAllUSBToPreset(string OldName, string NewName) 
        {
            foreach (var item in USBToPresetIO.ReadUSBToPresetList())
            {
                USBToPresetData UTPD = USBToPresetIO.ReadUSBToPresetDataFromFile(item);
                if (UTPD.PresetName == OldName)
                {
                    File.Delete(item);
                    UTPD.PresetName = NewName;
                    USBToPresetIO.WriteUSBToPresetDataToFile(UTPD, item);
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (_editingExistingPreset)
            {
                File.Delete("Presets\\" + (string)PresetNamesListView.SelectedItems[0].Text + ".json");
                UpdatePresetNameOnAllUSBToPreset("Presets\\" + (string)PresetNamesListView.SelectedItems[0].Text + ".json", "Empty");
                PresetNamesListView.Items.RemoveAt(PresetNamesListView.SelectedIndices[0]);
            }
        }

        private void StatementListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RulesListView.SelectedIndices.Count > 0)
            {
                _editingExistingRule = true;
                var SD = _currentPDSyncRules[RulesListView.SelectedIndices[0]];
                LoadStatementRuleData(RulesListView.SelectedItems[0].Text, SD);
            }
            else
            {
                _editingExistingRule = false;
                ClearStatementRuleData();
            }
        }

        private void SaveRuleBtn_Click(object sender, EventArgs e)
        {
            if (_editingExistingRule)
            {
                SyncRule SR = new SyncRule();

                RulesListView.Items[RulesListView.SelectedIndices[0]].Text = FileMaskTextBox.Text;
                SR.Priority = (int)PriorityNumericUpDown.Value;
                SR.CompareOperation = CompareOperationComboBox.Text;
                SR.CompareOperationArgument = CompareOperationArgumentComboBox.Text;
                SR.Action = ActionComboBox.Text;
                SR.ActionArgument = ActionArgumentComboBox.Text;

                _currentPDSyncRules[RulesListView.SelectedIndices[0]] = SR;
            }
            else
            {
                RulesListView.Items.Add(FileMaskTextBox.Text);

                SyncRule SR = new SyncRule();

                SR.Priority = (int)PriorityNumericUpDown.Value;
                SR.CompareOperation = CompareOperationComboBox.Text;
                SR.CompareOperationArgument = CompareOperationArgumentComboBox.Text;
                SR.Action = ActionComboBox.Text;
                SR.ActionArgument = ActionArgumentComboBox.Text;

                _currentPDSyncRules.Add(SR);
            }
            SetChangesMadeFlag();
        }

        private void SetChangesMadeFlag(bool flagStatus = true) 
        {
            if (flagStatus)
            {
                SaveBtn.Text = "Save (Changes made!)";
            }
            else
                SaveBtn.Text = "Save";
        }

        private void PresetNameTextBox_TextChanged(object sender, EventArgs e)
        {
            SetChangesMadeFlag();
        }

        private void SourcePathTextBox_TextChanged(object sender, EventArgs e)
        {
            SetChangesMadeFlag();
        }

        private void TargetPathTextBox_TextChanged(object sender, EventArgs e)
        {
            SetChangesMadeFlag();
        }

        private void DeleteRuleBtn_Click(object sender, EventArgs e)
        {
            if (RulesListView.SelectedIndices.Count > 0)
            {
                _currentPDSyncRules.RemoveAt(RulesListView.SelectedIndices[0]);
                RulesListView.Items.RemoveAt(RulesListView.SelectedIndices[0]);
            }
        }

        private void PresetWorkForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
