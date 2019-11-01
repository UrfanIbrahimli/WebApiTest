using ERP.WebApi.AppStart;
using NLog;

[assembly: System.Web.PreApplicationStartMethod(typeof(Startup), "Initialize")]
namespace ERP.WebApi.AppStart
{
    public class Startup
    {
        public static void Initialize()
        {
            var config = new NLog.Config.LoggingConfiguration();

            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "log.txt" };
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            NLog.LogManager.Configuration = config;
        }
    }
}