namespace DataBaseBackupWindowsService.Test
{
    partial class TestForm
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
            this.btn_TakeBackup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_TakeBackup
            // 
            this.btn_TakeBackup.Location = new System.Drawing.Point(76, 26);
            this.btn_TakeBackup.Name = "btn_TakeBackup";
            this.btn_TakeBackup.Size = new System.Drawing.Size(118, 23);
            this.btn_TakeBackup.TabIndex = 0;
            this.btn_TakeBackup.Text = "Take Backup";
            this.btn_TakeBackup.UseVisualStyleBackColor = true;
            this.btn_TakeBackup.Click += new System.EventHandler(this.btn_TakeBackup_Click);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btn_TakeBackup);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_TakeBackup;
    }
}