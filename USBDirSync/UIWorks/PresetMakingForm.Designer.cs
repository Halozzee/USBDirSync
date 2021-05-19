
namespace USBDirSync.UIWorks
{
    partial class PresetMakingForm
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
            this.SourcePathTextBox = new System.Windows.Forms.TextBox();
            this.TargetPathTextBox = new System.Windows.Forms.TextBox();
            this.StatementDataStringTextBox = new System.Windows.Forms.TextBox();
            this.MakeBtn = new System.Windows.Forms.Button();
            this.PresetNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SourcePathTextBox
            // 
            this.SourcePathTextBox.Location = new System.Drawing.Point(12, 101);
            this.SourcePathTextBox.Name = "SourcePathTextBox";
            this.SourcePathTextBox.Size = new System.Drawing.Size(329, 20);
            this.SourcePathTextBox.TabIndex = 0;
            // 
            // TargetPathTextBox
            // 
            this.TargetPathTextBox.Location = new System.Drawing.Point(12, 140);
            this.TargetPathTextBox.Name = "TargetPathTextBox";
            this.TargetPathTextBox.Size = new System.Drawing.Size(329, 20);
            this.TargetPathTextBox.TabIndex = 1;
            // 
            // StatementDataStringTextBox
            // 
            this.StatementDataStringTextBox.Location = new System.Drawing.Point(14, 206);
            this.StatementDataStringTextBox.Multiline = true;
            this.StatementDataStringTextBox.Name = "StatementDataStringTextBox";
            this.StatementDataStringTextBox.Size = new System.Drawing.Size(327, 198);
            this.StatementDataStringTextBox.TabIndex = 2;
            // 
            // MakeBtn
            // 
            this.MakeBtn.Location = new System.Drawing.Point(128, 415);
            this.MakeBtn.Name = "MakeBtn";
            this.MakeBtn.Size = new System.Drawing.Size(105, 30);
            this.MakeBtn.TabIndex = 3;
            this.MakeBtn.Text = "Make";
            this.MakeBtn.UseVisualStyleBackColor = true;
            this.MakeBtn.Click += new System.EventHandler(this.MakeBtn_Click);
            // 
            // PresetNameTextBox
            // 
            this.PresetNameTextBox.Location = new System.Drawing.Point(12, 46);
            this.PresetNameTextBox.Name = "PresetNameTextBox";
            this.PresetNameTextBox.Size = new System.Drawing.Size(329, 20);
            this.PresetNameTextBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Rules";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Target path";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Source path";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Preset name";
            // 
            // PresetMakingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PresetNameTextBox);
            this.Controls.Add(this.MakeBtn);
            this.Controls.Add(this.StatementDataStringTextBox);
            this.Controls.Add(this.TargetPathTextBox);
            this.Controls.Add(this.SourcePathTextBox);
            this.Name = "PresetMakingForm";
            this.Text = "PresetMakingForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SourcePathTextBox;
        private System.Windows.Forms.TextBox TargetPathTextBox;
        private System.Windows.Forms.TextBox StatementDataStringTextBox;
        private System.Windows.Forms.Button MakeBtn;
        private System.Windows.Forms.TextBox PresetNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}