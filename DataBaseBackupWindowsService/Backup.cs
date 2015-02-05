using DataBaseBackupWindowsService.Log;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace DataBaseBackupWindowsService
{
   public static class Backup
    {
        /// <summary>
        /// 
        /// </summary>
        public static void BackupDatabase()
        {
            try
            {
                XLogger.Debug("Start Service");
                XLogger.Debug("--------------");

                // read connectionstring from config file
                var connectionString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;

                // read backup folder from config file 
                var backupFolder = ConfigurationManager.AppSettings["BackupFolder"];
                var backupFolderDirectoryCreated = CreateBackupFileStoredDirectory(backupFolder);
                if (backupFolderDirectoryCreated)
                {
                    var sqlConStrBuilder = new SqlConnectionStringBuilder(connectionString);
                    var dataBaseName = sqlConStrBuilder.InitialCatalog;
                    // set backupfilename (you will get something like: "C:/temp/MyDatabase-2013-12-07.bak")
                    var backupFileName = String.Format("{0}{1}-{2}.bak",
                        backupFolder, sqlConStrBuilder.InitialCatalog,
                        DateTime.Now.ToString("yyyy-MM-dd"));

                    using (var connection = new SqlConnection(sqlConStrBuilder.ConnectionString))
                    {
                        var query = String.Format("BACKUP DATABASE {0} TO DISK='{1}'",
                            sqlConStrBuilder.InitialCatalog, backupFileName);

                        using (var command = new SqlCommand(query, connection))
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                        }

                        
                    }
                    XLogger.Debug(dataBaseName + " BackUp Successfully");
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="backupFolder"></param>
        /// <returns></returns>
        private static bool CreateBackupFileStoredDirectory(string backupFolder)
        {
            try
            {
                if (!Directory.Exists(backupFolder))
                {
                    Directory.CreateDirectory(backupFolder);
                    return true;
                }
                return true;
            }
            catch
            {
                XLogger.Debug("Error to create backup folder");
                return false;
            }
        }

    }
}
