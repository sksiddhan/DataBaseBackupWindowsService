using System;
using System.Windows.Forms;

namespace DataBaseBackupWindowsService.Test
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void btn_TakeBackup_Click(object sender, EventArgs e)
        {
            Backup.BackupDatabase();
        }
    }
}
