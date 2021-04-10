
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
            this.compareTwoFilesBtn = new System.Windows.Forms.Button();
            this.DetectTwoFilesExistance = new System.Windows.Forms.Button();
            this.TestBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // compareTwoFilesBtn
            // 
            this.compareTwoFilesBtn.Location = new System.Drawing.Point(19, 13);
            this.compareTwoFilesBtn.Name = "compareTwoFilesBtn";
            this.compareTwoFilesBtn.Size = new System.Drawing.Size(119, 26);
            this.compareTwoFilesBtn.TabIndex = 0;
            this.compareTwoFilesBtn.Text = "CompareTwoFiles";
            this.compareTwoFilesBtn.UseVisualStyleBackColor = true;
            // 
            // DetectTwoFilesExistance
            // 
            this.DetectTwoFilesExistance.Location = new System.Drawing.Point(144, 13);
            this.DetectTwoFilesExistance.Name = "DetectTwoFilesExistance";
            this.DetectTwoFilesExistance.Size = new System.Drawing.Size(138, 26);
            this.DetectTwoFilesExistance.TabIndex = 1;
            this.DetectTwoFilesExistance.Text = "DetectTwoFilesExistance";
            this.DetectTwoFilesExistance.UseVisualStyleBackColor = true;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 450);
            this.Controls.Add(this.TestBtn);
            this.Controls.Add(this.DetectTwoFilesExistance);
            this.Controls.Add(this.compareTwoFilesBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button compareTwoFilesBtn;
        private System.Windows.Forms.Button DetectTwoFilesExistance;
        private System.Windows.Forms.Button TestBtn;
    }
}

