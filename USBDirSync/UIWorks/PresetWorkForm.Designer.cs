
namespace USBDirSync.UIWorks
{
    partial class PresetWorkForm
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
            this.PresetNamesListView = new System.Windows.Forms.ListView();
            this.PresetNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PresetNameTextBox = new System.Windows.Forms.TextBox();
            this.TargetPathTextBox = new System.Windows.Forms.TextBox();
            this.SourcePathTextBox = new System.Windows.Forms.TextBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.SelectSourcePathBtn = new System.Windows.Forms.Button();
            this.SelectTargetPathBtn = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.RulesListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileMaskTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PriorityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.CompareOperationComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CompareOperationArgumentComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ActionComboBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ActionArgumentComboBox = new System.Windows.Forms.ComboBox();
            this.SaveRuleBtn = new System.Windows.Forms.Button();
            this.DeleteRuleBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PriorityNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // PresetNamesListView
            // 
            this.PresetNamesListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PresetNamesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PresetNameColumn});
            this.PresetNamesListView.GridLines = true;
            this.PresetNamesListView.HideSelection = false;
            this.PresetNamesListView.Location = new System.Drawing.Point(11, 10);
            this.PresetNamesListView.MultiSelect = false;
            this.PresetNamesListView.Name = "PresetNamesListView";
            this.PresetNamesListView.Size = new System.Drawing.Size(258, 385);
            this.PresetNamesListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.PresetNamesListView.TabIndex = 0;
            this.PresetNamesListView.UseCompatibleStateImageBehavior = false;
            this.PresetNamesListView.View = System.Windows.Forms.View.Details;
            this.PresetNamesListView.SelectedIndexChanged += new System.EventHandler(this.PresetNamesListView_SelectedIndexChanged);
            // 
            // PresetNameColumn
            // 
            this.PresetNameColumn.Text = "Preset name";
            this.PresetNameColumn.Width = 256;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(293, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Preset name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(293, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Source path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(293, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Target path";
            // 
            // PresetNameTextBox
            // 
            this.PresetNameTextBox.Location = new System.Drawing.Point(293, 26);
            this.PresetNameTextBox.Name = "PresetNameTextBox";
            this.PresetNameTextBox.Size = new System.Drawing.Size(329, 20);
            this.PresetNameTextBox.TabIndex = 11;
            this.PresetNameTextBox.TextChanged += new System.EventHandler(this.PresetNameTextBox_TextChanged);
            // 
            // TargetPathTextBox
            // 
            this.TargetPathTextBox.Location = new System.Drawing.Point(293, 104);
            this.TargetPathTextBox.Name = "TargetPathTextBox";
            this.TargetPathTextBox.Size = new System.Drawing.Size(329, 20);
            this.TargetPathTextBox.TabIndex = 10;
            this.TargetPathTextBox.TextChanged += new System.EventHandler(this.TargetPathTextBox_TextChanged);
            // 
            // SourcePathTextBox
            // 
            this.SourcePathTextBox.Location = new System.Drawing.Point(293, 65);
            this.SourcePathTextBox.Name = "SourcePathTextBox";
            this.SourcePathTextBox.Size = new System.Drawing.Size(329, 20);
            this.SourcePathTextBox.TabIndex = 9;
            this.SourcePathTextBox.TextChanged += new System.EventHandler(this.SourcePathTextBox_TextChanged);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(390, 130);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(156, 27);
            this.SaveBtn.TabIndex = 15;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // SelectSourcePathBtn
            // 
            this.SelectSourcePathBtn.Location = new System.Drawing.Point(628, 62);
            this.SelectSourcePathBtn.Name = "SelectSourcePathBtn";
            this.SelectSourcePathBtn.Size = new System.Drawing.Size(78, 23);
            this.SelectSourcePathBtn.TabIndex = 16;
            this.SelectSourcePathBtn.Text = "Select";
            this.SelectSourcePathBtn.UseVisualStyleBackColor = true;
            this.SelectSourcePathBtn.Click += new System.EventHandler(this.SelectSourcePathBtn_Click);
            // 
            // SelectTargetPathBtn
            // 
            this.SelectTargetPathBtn.Location = new System.Drawing.Point(628, 101);
            this.SelectTargetPathBtn.Name = "SelectTargetPathBtn";
            this.SelectTargetPathBtn.Size = new System.Drawing.Size(78, 23);
            this.SelectTargetPathBtn.TabIndex = 17;
            this.SelectTargetPathBtn.Text = "Select";
            this.SelectTargetPathBtn.UseVisualStyleBackColor = true;
            this.SelectTargetPathBtn.Click += new System.EventHandler(this.SelectTargetPathBtn_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Location = new System.Drawing.Point(85, 401);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(106, 27);
            this.DeleteBtn.TabIndex = 18;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // RulesListView
            // 
            this.RulesListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RulesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.RulesListView.GridLines = true;
            this.RulesListView.HideSelection = false;
            this.RulesListView.Location = new System.Drawing.Point(275, 173);
            this.RulesListView.MultiSelect = false;
            this.RulesListView.Name = "RulesListView";
            this.RulesListView.Size = new System.Drawing.Size(103, 222);
            this.RulesListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.RulesListView.TabIndex = 19;
            this.RulesListView.UseCompatibleStateImageBehavior = false;
            this.RulesListView.View = System.Windows.Forms.View.Details;
            this.RulesListView.SelectedIndexChanged += new System.EventHandler(this.StatementListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Statements";
            this.columnHeader1.Width = 100;
            // 
            // FileMaskTextBox
            // 
            this.FileMaskTextBox.Location = new System.Drawing.Point(384, 214);
            this.FileMaskTextBox.Name = "FileMaskTextBox";
            this.FileMaskTextBox.Size = new System.Drawing.Size(254, 20);
            this.FileMaskTextBox.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(384, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Filemask";
            // 
            // PriorityNumericUpDown
            // 
            this.PriorityNumericUpDown.Location = new System.Drawing.Point(384, 264);
            this.PriorityNumericUpDown.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.PriorityNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PriorityNumericUpDown.Name = "PriorityNumericUpDown";
            this.PriorityNumericUpDown.Size = new System.Drawing.Size(42, 20);
            this.PriorityNumericUpDown.TabIndex = 22;
            this.PriorityNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(381, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Priority";
            // 
            // CompareOperationComboBox
            // 
            this.CompareOperationComboBox.FormattingEnabled = true;
            this.CompareOperationComboBox.Items.AddRange(new object[] {
            "EX",
            "LMT",
            "SZ"});
            this.CompareOperationComboBox.Location = new System.Drawing.Point(452, 263);
            this.CompareOperationComboBox.Name = "CompareOperationComboBox";
            this.CompareOperationComboBox.Size = new System.Drawing.Size(94, 21);
            this.CompareOperationComboBox.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(449, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Compare operation";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(565, 249);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Compare operation argument";
            // 
            // CompareOperationArgumentComboBox
            // 
            this.CompareOperationArgumentComboBox.FormattingEnabled = true;
            this.CompareOperationArgumentComboBox.Items.AddRange(new object[] {
            "S",
            "T",
            "S>T",
            "S<T"});
            this.CompareOperationArgumentComboBox.Location = new System.Drawing.Point(568, 264);
            this.CompareOperationArgumentComboBox.Name = "CompareOperationArgumentComboBox";
            this.CompareOperationArgumentComboBox.Size = new System.Drawing.Size(138, 21);
            this.CompareOperationArgumentComboBox.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(381, 294);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Action";
            // 
            // ActionComboBox
            // 
            this.ActionComboBox.FormattingEnabled = true;
            this.ActionComboBox.Items.AddRange(new object[] {
            "Shr",
            "Skp",
            "Dlt",
            "Cpy"});
            this.ActionComboBox.Location = new System.Drawing.Point(384, 309);
            this.ActionComboBox.Name = "ActionComboBox";
            this.ActionComboBox.Size = new System.Drawing.Size(94, 21);
            this.ActionComboBox.TabIndex = 28;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(497, 294);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Action argument";
            // 
            // ActionArgumentComboBox
            // 
            this.ActionArgumentComboBox.FormattingEnabled = true;
            this.ActionArgumentComboBox.Items.AddRange(new object[] {
            "",
            "S",
            "T"});
            this.ActionArgumentComboBox.Location = new System.Drawing.Point(500, 309);
            this.ActionArgumentComboBox.Name = "ActionArgumentComboBox";
            this.ActionArgumentComboBox.Size = new System.Drawing.Size(94, 21);
            this.ActionArgumentComboBox.TabIndex = 30;
            // 
            // SaveRuleBtn
            // 
            this.SaveRuleBtn.Location = new System.Drawing.Point(488, 368);
            this.SaveRuleBtn.Name = "SaveRuleBtn";
            this.SaveRuleBtn.Size = new System.Drawing.Size(106, 27);
            this.SaveRuleBtn.TabIndex = 32;
            this.SaveRuleBtn.Text = "Save rule";
            this.SaveRuleBtn.UseVisualStyleBackColor = true;
            this.SaveRuleBtn.Click += new System.EventHandler(this.SaveRuleBtn_Click);
            // 
            // DeleteRuleBtn
            // 
            this.DeleteRuleBtn.Location = new System.Drawing.Point(275, 401);
            this.DeleteRuleBtn.Name = "DeleteRuleBtn";
            this.DeleteRuleBtn.Size = new System.Drawing.Size(103, 27);
            this.DeleteRuleBtn.TabIndex = 33;
            this.DeleteRuleBtn.Text = "Delete";
            this.DeleteRuleBtn.UseVisualStyleBackColor = true;
            this.DeleteRuleBtn.Click += new System.EventHandler(this.DeleteRuleBtn_Click);
            // 
            // PresetWorkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 450);
            this.Controls.Add(this.DeleteRuleBtn);
            this.Controls.Add(this.SaveRuleBtn);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ActionArgumentComboBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ActionComboBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CompareOperationArgumentComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CompareOperationComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PriorityNumericUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FileMaskTextBox);
            this.Controls.Add(this.RulesListView);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.SelectTargetPathBtn);
            this.Controls.Add(this.SelectSourcePathBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PresetNameTextBox);
            this.Controls.Add(this.TargetPathTextBox);
            this.Controls.Add(this.SourcePathTextBox);
            this.Controls.Add(this.PresetNamesListView);
            this.Name = "PresetWorkForm";
            this.Text = "PresetWorkForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PresetWorkForm_FormClosed);
            this.Load += new System.EventHandler(this.PresetWorkForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PriorityNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView PresetNamesListView;
        private System.Windows.Forms.ColumnHeader PresetNameColumn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PresetNameTextBox;
        private System.Windows.Forms.TextBox TargetPathTextBox;
        private System.Windows.Forms.TextBox SourcePathTextBox;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button SelectSourcePathBtn;
        private System.Windows.Forms.Button SelectTargetPathBtn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.ListView RulesListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TextBox FileMaskTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown PriorityNumericUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CompareOperationComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CompareOperationArgumentComboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox ActionComboBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox ActionArgumentComboBox;
        private System.Windows.Forms.Button SaveRuleBtn;
        private System.Windows.Forms.Button DeleteRuleBtn;
    }
}