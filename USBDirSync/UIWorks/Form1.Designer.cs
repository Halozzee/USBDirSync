
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TestBtn = new System.Windows.Forms.Button();
            this.skipBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.ShareSourceBtn = new System.Windows.Forms.Button();
            this.copyBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.PresetsComboBox = new System.Windows.Forms.ComboBox();
            this.MakePresetBtn = new System.Windows.Forms.Button();
            this.MakeUSBSetupBtn = new System.Windows.Forms.Button();
            this.ConflictDataGridView = new System.Windows.Forms.DataGridView();
            this.SourceFileNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SyncDirectionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TargetFileNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShareTargetBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ConflictDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // TestBtn
            // 
            this.TestBtn.Location = new System.Drawing.Point(568, 169);
            this.TestBtn.Name = "TestBtn";
            this.TestBtn.Size = new System.Drawing.Size(83, 26);
            this.TestBtn.TabIndex = 2;
            this.TestBtn.Text = "Find conflicts";
            this.TestBtn.UseVisualStyleBackColor = true;
            this.TestBtn.Click += new System.EventHandler(this.TestBtn_Click);
            // 
            // skipBtn
            // 
            this.skipBtn.Location = new System.Drawing.Point(615, 13);
            this.skipBtn.Name = "skipBtn";
            this.skipBtn.Size = new System.Drawing.Size(75, 23);
            this.skipBtn.TabIndex = 4;
            this.skipBtn.Text = "Skip";
            this.skipBtn.UseVisualStyleBackColor = true;
            this.skipBtn.Click += new System.EventHandler(this.skipBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(615, 42);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteBtn.TabIndex = 5;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // ShareSourceBtn
            // 
            this.ShareSourceBtn.Location = new System.Drawing.Point(554, 71);
            this.ShareSourceBtn.Name = "ShareSourceBtn";
            this.ShareSourceBtn.Size = new System.Drawing.Size(89, 23);
            this.ShareSourceBtn.TabIndex = 6;
            this.ShareSourceBtn.Text = "Share Source";
            this.ShareSourceBtn.UseVisualStyleBackColor = true;
            this.ShareSourceBtn.Click += new System.EventHandler(this.ShareSourceBtn_Click);
            // 
            // copyBtn
            // 
            this.copyBtn.Location = new System.Drawing.Point(615, 100);
            this.copyBtn.Name = "copyBtn";
            this.copyBtn.Size = new System.Drawing.Size(75, 23);
            this.copyBtn.TabIndex = 7;
            this.copyBtn.Text = "Copy";
            this.copyBtn.UseVisualStyleBackColor = true;
            this.copyBtn.Click += new System.EventHandler(this.copyBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(657, 169);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 26);
            this.button1.TabIndex = 8;
            this.button1.Text = "Solve";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PresetsComboBox
            // 
            this.PresetsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PresetsComboBox.FormattingEnabled = true;
            this.PresetsComboBox.Items.AddRange(new object[] {
            "Empty"});
            this.PresetsComboBox.Location = new System.Drawing.Point(568, 235);
            this.PresetsComboBox.Name = "PresetsComboBox";
            this.PresetsComboBox.Size = new System.Drawing.Size(159, 21);
            this.PresetsComboBox.TabIndex = 9;
            this.PresetsComboBox.SelectedIndexChanged += new System.EventHandler(this.PresetsComboBox_SelectedIndexChanged);
            // 
            // MakePresetBtn
            // 
            this.MakePresetBtn.Location = new System.Drawing.Point(568, 336);
            this.MakePresetBtn.Name = "MakePresetBtn";
            this.MakePresetBtn.Size = new System.Drawing.Size(83, 38);
            this.MakePresetBtn.TabIndex = 10;
            this.MakePresetBtn.Text = "Make preset";
            this.MakePresetBtn.UseVisualStyleBackColor = true;
            this.MakePresetBtn.Click += new System.EventHandler(this.MakePresetBtn_Click);
            // 
            // MakeUSBSetupBtn
            // 
            this.MakeUSBSetupBtn.Location = new System.Drawing.Point(657, 336);
            this.MakeUSBSetupBtn.Name = "MakeUSBSetupBtn";
            this.MakeUSBSetupBtn.Size = new System.Drawing.Size(79, 38);
            this.MakeUSBSetupBtn.TabIndex = 12;
            this.MakeUSBSetupBtn.Text = "Make USB setup";
            this.MakeUSBSetupBtn.UseVisualStyleBackColor = true;
            this.MakeUSBSetupBtn.Click += new System.EventHandler(this.MakeUSBSetupBtn_Click);
            // 
            // ConflictDataGridView
            // 
            this.ConflictDataGridView.AllowUserToAddRows = false;
            this.ConflictDataGridView.AllowUserToDeleteRows = false;
            this.ConflictDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ConflictDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.ConflictDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ConflictDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SourceFileNameColumn,
            this.SyncDirectionColumn,
            this.TargetFileNameColumn});
            this.ConflictDataGridView.Location = new System.Drawing.Point(19, 42);
            this.ConflictDataGridView.MultiSelect = false;
            this.ConflictDataGridView.Name = "ConflictDataGridView";
            this.ConflictDataGridView.ReadOnly = true;
            this.ConflictDataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ConflictDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.ConflictDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ConflictDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ConflictDataGridView.Size = new System.Drawing.Size(520, 331);
            this.ConflictDataGridView.TabIndex = 13;
            this.ConflictDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SourceDirDataGridView_CellContentClick);
            // 
            // SourceFileNameColumn
            // 
            this.SourceFileNameColumn.HeaderText = "Source File Name";
            this.SourceFileNameColumn.Name = "SourceFileNameColumn";
            this.SourceFileNameColumn.ReadOnly = true;
            // 
            // SyncDirectionColumn
            // 
            this.SyncDirectionColumn.HeaderText = "Direction";
            this.SyncDirectionColumn.Name = "SyncDirectionColumn";
            this.SyncDirectionColumn.ReadOnly = true;
            // 
            // TargetFileNameColumn
            // 
            this.TargetFileNameColumn.HeaderText = "Target File Name";
            this.TargetFileNameColumn.Name = "TargetFileNameColumn";
            this.TargetFileNameColumn.ReadOnly = true;
            // 
            // ShareTargetBtn
            // 
            this.ShareTargetBtn.Location = new System.Drawing.Point(647, 71);
            this.ShareTargetBtn.Name = "ShareTargetBtn";
            this.ShareTargetBtn.Size = new System.Drawing.Size(89, 23);
            this.ShareTargetBtn.TabIndex = 14;
            this.ShareTargetBtn.Text = "Share Target";
            this.ShareTargetBtn.UseVisualStyleBackColor = true;
            this.ShareTargetBtn.Click += new System.EventHandler(this.ShareTargetBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 381);
            this.Controls.Add(this.ShareTargetBtn);
            this.Controls.Add(this.ConflictDataGridView);
            this.Controls.Add(this.MakeUSBSetupBtn);
            this.Controls.Add(this.MakePresetBtn);
            this.Controls.Add(this.PresetsComboBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.copyBtn);
            this.Controls.Add(this.ShareSourceBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.skipBtn);
            this.Controls.Add(this.TestBtn);
            this.Name = "Form1";
            this.Text = "USBDirSync";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ConflictDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button TestBtn;
        private System.Windows.Forms.Button skipBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button ShareSourceBtn;
        private System.Windows.Forms.Button copyBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox PresetsComboBox;
        private System.Windows.Forms.Button MakePresetBtn;
        private System.Windows.Forms.Button MakeUSBSetupBtn;
        private System.Windows.Forms.DataGridView ConflictDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn SourceFileNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyncDirectionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TargetFileNameColumn;
        private System.Windows.Forms.Button ShareTargetBtn;
    }
}

