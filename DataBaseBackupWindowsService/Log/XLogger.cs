using log4net;
using log4net.Config;
using log4net.Core;

namespace DataBaseBackupWindowsService.Log
{
    class XLogger
    {
        public static readonly ILog Logger = LogManager.GetLogger("Services");

        static XLogger()
        {
            XmlConfigurator.Configure();
        }
        public static bool IsDebug()
        {
            bool sRes = false;
            if (Logger != null)
            {
                sRes = Logger.Logger.IsEnabledFor(Level.Debug);
            }
            return sRes;
        }
        public static void Debug(string IsMessage)
        {
            if (Logger != null)
            {
                Logger.Debug(IsMessage);
            }
        }
    }
}
