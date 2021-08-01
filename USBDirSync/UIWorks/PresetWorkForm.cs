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
using USBDirSync.StorageWorks;

namespace USBDirSync.UIWorks
{
    public partial class PresetWorkForm : Form
    {
        bool _editingExistingPreset;
        PresetData CurrentPD;

        public PresetWorkForm()
        {
            InitializeComponent();
        }

        private void PresetNamesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PresetNamesListView.SelectedIndices.Count > 0)
            {
                CurrentPD = PresetIO.ReadPresetDataFromFile("Presets\\" + (string)PresetNamesListView.SelectedItems[0].Text + ".json");

                PresetNameTextBox.Text = (string)PresetNamesListView.SelectedItems[0].Text;
                SourcePathTextBox.Text = CurrentPD.SourceDirectoryPath;
                TargetPathTextBox.Text = CurrentPD.TargetDirectoryPath;

                _editingExistingPreset = true;
            }
            else
            {
                PresetNameTextBox.Text = "";
                SourcePathTextBox.Text = "";
                TargetPathTextBox.Text = "";

                CurrentPD = null;
                _editingExistingPreset = false;
            }
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

            if (_editingExistingPreset)
            {
                UpdatePresetNameOnAllUSBToPreset("Presets\\" + (string)PresetNamesListView.SelectedItems[0].Text + ".json", "Presets\\" + PresetNameTextBox.Text + ".json");
                File.Delete("Presets\\" + (string)PresetNamesListView.SelectedItems[0].Text + ".json");
                PresetData PD = new PresetData(SourcePathTextBox.Text, TargetPathTextBox.Text, CurrentPD.StatementDataString);
                PresetIO.WritePresetDataToFile(PD, "Presets\\" + PresetNameTextBox.Text + ".json");
                PresetNamesListView.Items[PresetNamesListView.SelectedIndices[0]].Text = PresetNameTextBox.Text;
            }
            else
            {
                PresetData PD = new PresetData(SourcePathTextBox.Text, TargetPathTextBox.Text, "");
                PresetIO.WritePresetDataToFile(PD, "Presets\\" + PresetNameTextBox.Text + ".json");
                PresetNamesListView.Items.Add(PresetNameTextBox.Text);
            }
        }

        private bool IsThereSameNamePreset(string NameToCheck) 
        {
            for (int i = 0; i < PresetNamesListView.Items.Count; i++)
            {
                if (PresetNamesListView.Items[i].Text == NameToCheck)
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
    }
}
