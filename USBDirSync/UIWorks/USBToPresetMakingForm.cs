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
using USBDirSync.USBWorks;

namespace USBDirSync.UIWorks
{
    public partial class USBToPresetMakingForm : Form
    {
        List<USBConnectedEventArgs> _uSBDevices;

        public USBToPresetMakingForm()
        {
            InitializeComponent();
        }

        private void USBToPresetMakingForm_Load(object sender, EventArgs e)
        {
            _uSBDevices = USBDevicesReader.GetConnectedStorageDevices();
            foreach (var item in _uSBDevices)
            {
                DevicesComboBox.Items.Add(item.USBDeviceName);
            }

            LoadPresetsComboBox();
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

        private void MakeLinkBtn_Click(object sender, EventArgs e)
        {
            USBToPresetData UPD = new USBToPresetData();
            UPD.DeviceData = new USBConnectedEventArgs();
            UPD.DeviceData.USBDeviceName = (string)DevicesComboBox.SelectedItem;
            UPD.DeviceData.USBDeviceID = _uSBDevices.Find(x => x.USBDeviceName == UPD.DeviceData.USBDeviceName).USBDeviceID;
            UPD.PresetName = (string)PresetsComboBox.SelectedItem;

            USBToPresetIO.WriteUSBToPresetDataToFile(UPD, "USBToPreset\\" + UPD.DeviceData.USBDeviceName + ".json");
        }
    }
}
