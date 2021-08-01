
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
            this.label4.Location = new System.Drawing.Point(328, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Preset name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(328, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Source path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(328, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Target path";
            // 
            // PresetNameTextBox
            // 
            this.PresetNameTextBox.Location = new System.Drawing.Point(328, 79);
            this.PresetNameTextBox.Name = "PresetNameTextBox";
            this.PresetNameTextBox.Size = new System.Drawing.Size(329, 20);
            this.PresetNameTextBox.TabIndex = 11;
            // 
            // TargetPathTextBox
            // 
            this.TargetPathTextBox.Location = new System.Drawing.Point(328, 157);
            this.TargetPathTextBox.Name = "TargetPathTextBox";
            this.TargetPathTextBox.Size = new System.Drawing.Size(329, 20);
            this.TargetPathTextBox.TabIndex = 10;
            // 
            // SourcePathTextBox
            // 
            this.SourcePathTextBox.Location = new System.Drawing.Point(328, 118);
            this.SourcePathTextBox.Name = "SourcePathTextBox";
            this.SourcePathTextBox.Size = new System.Drawing.Size(329, 20);
            this.SourcePathTextBox.TabIndex = 9;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(440, 183);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(106, 27);
            this.SaveBtn.TabIndex = 15;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // SelectSourcePathBtn
            // 
            this.SelectSourcePathBtn.Location = new System.Drawing.Point(663, 115);
            this.SelectSourcePathBtn.Name = "SelectSourcePathBtn";
            this.SelectSourcePathBtn.Size = new System.Drawing.Size(78, 23);
            this.SelectSourcePathBtn.TabIndex = 16;
            this.SelectSourcePathBtn.Text = "Select";
            this.SelectSourcePathBtn.UseVisualStyleBackColor = true;
            this.SelectSourcePathBtn.Click += new System.EventHandler(this.SelectSourcePathBtn_Click);
            // 
            // SelectTargetPathBtn
            // 
            this.SelectTargetPathBtn.Location = new System.Drawing.Point(663, 154);
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
            // PresetWorkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 450);
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
            this.Load += new System.EventHandler(this.PresetWorkForm_Load);
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
    }
}