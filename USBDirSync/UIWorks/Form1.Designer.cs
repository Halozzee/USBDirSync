
namespace USBDirSync
{
    partial class Form1
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
            this.TestBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SyncActionStateCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SyncPriorityCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SyncConflictStateCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileRelPathCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skipBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.shareBtn = new System.Windows.Forms.Button();
            this.copyBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.PresetsComboBox = new System.Windows.Forms.ComboBox();
            this.MakePresetBtn = new System.Windows.Forms.Button();
            this.DeletePresetBtn = new System.Windows.Forms.Button();
            this.MakeUSBSetupBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // TestBtn
            // 
            this.TestBtn.Location = new System.Drawing.Point(594, 13);
            this.TestBtn.Name = "TestBtn";
            this.TestBtn.Size = new System.Drawing.Size(119, 26);
            this.TestBtn.TabIndex = 2;
            this.TestBtn.Text = "TestBtn";
            this.TestBtn.UseVisualStyleBackColor = true;
            this.TestBtn.Click += new System.EventHandler(this.TestBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SyncActionStateCol,
            this.SyncPriorityCol,
            this.SyncConflictStateCol,
            this.FileRelPathCol});
            this.dataGridView1.Location = new System.Drawing.Point(19, 78);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(543, 331);
            this.dataGridView1.TabIndex = 3;
            // 
            // SyncActionStateCol
            // 
            this.SyncActionStateCol.HeaderText = "SyncActionState";
            this.SyncActionStateCol.Name = "SyncActionStateCol";
            // 
            // SyncPriorityCol
            // 
            this.SyncPriorityCol.HeaderText = "SyncPriority";
            this.SyncPriorityCol.Name = "SyncPriorityCol";
            // 
            // SyncConflictStateCol
            // 
            this.SyncConflictStateCol.HeaderText = "SyncConflictState";
            this.SyncConflictStateCol.Name = "SyncConflictStateCol";
            // 
            // FileRelPathCol
            // 
            this.FileRelPathCol.HeaderText = "File Rel Path";
            this.FileRelPathCol.Name = "FileRelPathCol";
            // 
            // skipBtn
            // 
            this.skipBtn.Location = new System.Drawing.Point(626, 78);
            this.skipBtn.Name = "skipBtn";
            this.skipBtn.Size = new System.Drawing.Size(75, 23);
            this.skipBtn.TabIndex = 4;
            this.skipBtn.Text = "Skip";
            this.skipBtn.UseVisualStyleBackColor = true;
            this.skipBtn.Click += new System.EventHandler(this.skipBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(626, 107);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteBtn.TabIndex = 5;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // shareBtn
            // 
            this.shareBtn.Location = new System.Drawing.Point(626, 136);
            this.shareBtn.Name = "shareBtn";
            this.shareBtn.Size = new System.Drawing.Size(75, 23);
            this.shareBtn.TabIndex = 6;
            this.shareBtn.Text = "Share";
            this.shareBtn.UseVisualStyleBackColor = true;
            this.shareBtn.Click += new System.EventHandler(this.shareBtn_Click);
            // 
            // copyBtn
            // 
            this.copyBtn.Location = new System.Drawing.Point(626, 165);
            this.copyBtn.Name = "copyBtn";
            this.copyBtn.Size = new System.Drawing.Size(75, 23);
            this.copyBtn.TabIndex = 7;
            this.copyBtn.Text = "Copy";
            this.copyBtn.UseVisualStyleBackColor = true;
            this.copyBtn.Click += new System.EventHandler(this.copyBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(626, 215);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Go";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PresetsComboBox
            // 
            this.PresetsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PresetsComboBox.FormattingEnabled = true;
            this.PresetsComboBox.Items.AddRange(new object[] {
            "Empty"});
            this.PresetsComboBox.Location = new System.Drawing.Point(568, 299);
            this.PresetsComboBox.Name = "PresetsComboBox";
            this.PresetsComboBox.Size = new System.Drawing.Size(159, 21);
            this.PresetsComboBox.TabIndex = 9;
            this.PresetsComboBox.SelectedIndexChanged += new System.EventHandler(this.PresetsComboBox_SelectedIndexChanged);
            // 
            // MakePresetBtn
            // 
            this.MakePresetBtn.Location = new System.Drawing.Point(568, 400);
            this.MakePresetBtn.Name = "MakePresetBtn";
            this.MakePresetBtn.Size = new System.Drawing.Size(83, 38);
            this.MakePresetBtn.TabIndex = 10;
            this.MakePresetBtn.Text = "Make preset";
            this.MakePresetBtn.UseVisualStyleBackColor = true;
            this.MakePresetBtn.Click += new System.EventHandler(this.MakePresetBtn_Click);
            // 
            // DeletePresetBtn
            // 
            this.DeletePresetBtn.Location = new System.Drawing.Point(604, 326);
            this.DeletePresetBtn.Name = "DeletePresetBtn";
            this.DeletePresetBtn.Size = new System.Drawing.Size(86, 22);
            this.DeletePresetBtn.TabIndex = 11;
            this.DeletePresetBtn.Text = "Delete preset";
            this.DeletePresetBtn.UseVisualStyleBackColor = true;
            this.DeletePresetBtn.Click += new System.EventHandler(this.DeletePresetBtn_Click);
            // 
            // MakeUSBSetupBtn
            // 
            this.MakeUSBSetupBtn.Location = new System.Drawing.Point(657, 400);
            this.MakeUSBSetupBtn.Name = "MakeUSBSetupBtn";
            this.MakeUSBSetupBtn.Size = new System.Drawing.Size(79, 38);
            this.MakeUSBSetupBtn.TabIndex = 12;
            this.MakeUSBSetupBtn.Text = "Make USB setup";
            this.MakeUSBSetupBtn.UseVisualStyleBackColor = true;
            this.MakeUSBSetupBtn.Click += new System.EventHandler(this.MakeUSBSetupBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 450);
            this.Controls.Add(this.MakeUSBSetupBtn);
            this.Controls.Add(this.DeletePresetBtn);
            this.Controls.Add(this.MakePresetBtn);
            this.Controls.Add(this.PresetsComboBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.copyBtn);
            this.Controls.Add(this.shareBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.skipBtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.TestBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button TestBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyncActionStateCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyncPriorityCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyncConflictStateCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileRelPathCol;
        private System.Windows.Forms.Button skipBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button shareBtn;
        private System.Windows.Forms.Button copyBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox PresetsComboBox;
        private System.Windows.Forms.Button MakePresetBtn;
        private System.Windows.Forms.Button DeletePresetBtn;
        private System.Windows.Forms.Button MakeUSBSetupBtn;
    }
}

