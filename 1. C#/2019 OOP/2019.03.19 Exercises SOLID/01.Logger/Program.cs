
namespace _01.Logger
{
    using _01.Logger.Appenders;
    using _01.Logger.Appenders.Contracts;
    using _01.Logger.Layouts;
    using _01.Logger.Layouts.Contracts;
    using _01.Logger.Loggers;
    using _01.Logger.Loggers.Contracts;

    public class Program
    {
        public static void Main()
        {
            var simpleLayout = new SimpleLayout();
            var consoleAppender = new ConsoleAppender(simpleLayout);

            var file = new LogFile();
            var fileAppender = new FileAppender(simpleLayout, file);

            var logger = new Logger(consoleAppender, fileAppender);
            logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");

        }
    }
}
