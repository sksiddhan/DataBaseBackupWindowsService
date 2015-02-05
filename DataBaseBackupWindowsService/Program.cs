using System.ServiceProcess;

namespace DataBaseBackupWindowsService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ////auto
            var servicesToRun = new ServiceBase[] 
            { 
                new DataBaseBackupWindowsService() 
            };
            ServiceBase.Run(servicesToRun);

            //manual
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new TestForm());
        }
    }
}
