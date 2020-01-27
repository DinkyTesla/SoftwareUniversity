
namespace DemoSOLID
{
    using DemoSOLID.Appenders;
    using DemoSOLID.Appenders.Contracts;
    using DemoSOLID.Core;
    using DemoSOLID.Core.Contracts;
    using DemoSOLID.Layouts;
    using DemoSOLID.Layouts.Contracts;
    using DemoSOLID.Loggers;
    using DemoSOLID.Loggers.Contracts;
    using DemoSOLID.Loggers.Enums;
    using System;

    public class Startup
    {
        public static void Main()
        {
            var simpleLayout = new SimpleLayout();
            var consoleAppender = new ConsoleAppender(simpleLayout);
            consoleAppender.ReportLevel = ReportLevel.Error;

            var logger = new Logger(consoleAppender);

            logger.Info("3/31/2015 5:33:07 PM", "Everything seems fine");
            logger.Warning("3/31/2015 5:33:07 PM", "Warning: ping is too high - disconnect imminent");
            logger.Error("3/31/2015 5:33:07 PM", "Error parsing request");
            logger.Critical("3/31/2015 5:33:07 PM", "No connection string found in App.config");
            logger.Fatal("3/31/2015 5:33:07 PM", "mscorlib.dll does not respond");

        }
    }
}
