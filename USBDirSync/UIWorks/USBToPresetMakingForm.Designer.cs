
namespace USBDirSync.UIWorks
{
    partial class USBToPresetMakingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DevicesComboBox = new System.Windows.Forms.ComboBox();
            this.PresetsComboBox = new System.Windows.Forms.ComboBox();
            this.MakeLinkBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DevicesComboBox
            // 
            this.DevicesComboBox.FormattingEnabled = true;
            this.DevicesComboBox.Location = new System.Drawing.Point(12, 12);
            this.DevicesComboBox.Name = "DevicesComboBox";
            this.DevicesComboBox.Size = new System.Drawing.Size(153, 21);
            this.DevicesComboBox.TabIndex = 0;
            // 
            // PresetsComboBox
            // 
            this.PresetsComboBox.FormattingEnabled = true;
            this.PresetsComboBox.Location = new System.Drawing.Point(299, 12);
            this.PresetsComboBox.Name = "PresetsComboBox";
            this.PresetsComboBox.Size = new System.Drawing.Size(153, 21);
            this.PresetsComboBox.TabIndex = 1;
            // 
            // MakeLinkBtn
            // 
            this.MakeLinkBtn.Location = new System.Drawing.Point(194, 11);
            this.MakeLinkBtn.Name = "MakeLinkBtn";
            this.MakeLinkBtn.Size = new System.Drawing.Size(81, 21);
            this.MakeLinkBtn.TabIndex = 2;
            this.MakeLinkBtn.Text = "Link";
            this.MakeLinkBtn.UseVisualStyleBackColor = true;
            this.MakeLinkBtn.Click += new System.EventHandler(this.MakeLinkBtn_Click);
            // 
            // USBToPresetMakingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 500);
            this.Controls.Add(this.MakeLinkBtn);
            this.Controls.Add(this.PresetsComboBox);
            this.Controls.Add(this.DevicesComboBox);
            this.Name = "USBToPresetMakingForm";
            this.Text = "USBToPresetMakingForm";
            this.Load += new System.EventHandler(this.USBToPresetMakingForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox DevicesComboBox;
        private System.Windows.Forms.ComboBox PresetsComboBox;
        private System.Windows.Forms.Button MakeLinkBtn;
    }
}