using DemoSOLID.Appenders.Contracts;
using DemoSOLID.Layouts.Contracts;
using DemoSOLID.Loggers;
using System;

namespace DemoSOLID.Appenders
{
    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout)
        {
            string typeAsLower = type.ToLower();

            switch (typeAsLower)
            {
                case "consoleappender":
                    return new ConsoleAppender(layout);
                case "fileappender":
                    return new FileAppender(layout, new LogFile());

                default:
                    throw new ArgumentException("Invalid appender type!");
            }
        }
    }
}
