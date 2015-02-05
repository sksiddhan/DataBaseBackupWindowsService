using DataBaseBackupWindowsService.Log;
using System;
using System.Configuration;
using System.Diagnostics;
using System.ServiceProcess;
using System.Timers;

namespace DataBaseBackupWindowsService
{
    public partial class DataBaseBackupWindowsService : ServiceBase
    {
        private Timer _timer = null;

        public DataBaseBackupWindowsService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                XLogger.Debug("Service Start....");
                var startTime = ConfigurationManager.AppSettings["StartTime"];
                _timer = new Timer(Convert.ToInt64(startTime));
                _timer.Elapsed += TimerFired;
                {
                    _timer.AutoReset = true;
                    _timer.Enabled = true;
                    _timer.Start();
                    XLogger.Debug("Timer Started");
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("error in starting my Service", ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        protected override void OnStop()
        {
            XLogger.Debug("Service stop....");
            _timer.Stop();
            _timer.Dispose();
        }

        private void TimerFired(object sender, ElapsedEventArgs e)
        {
            var systime = DateTime.Now.ToString("t");
            //if (systime == "1:00 AM")
            {
                Backup.BackupDatabase();
            }
        }

    }
}
