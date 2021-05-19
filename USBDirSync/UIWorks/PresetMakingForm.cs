using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using USBDirSync.StorageWorks;

namespace USBDirSync.UIWorks
{
    public partial class PresetMakingForm : Form
    {
        public PresetMakingForm()
        {
            InitializeComponent();
        }

        private void MakeBtn_Click(object sender, EventArgs e)
        {
            PresetData PD = new PresetData(SourcePathTextBox.Text, TargetPathTextBox.Text, StatementDataStringTextBox.Text);

            PresetIO.WritePresetDataToFile(PD, "Presets\\" + PresetNameTextBox.Text + ".json");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
