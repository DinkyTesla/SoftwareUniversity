
namespace DemoSOLID.Appenders
{
    using DemoSOLID.Appenders.Contracts;
    using DemoSOLID.Layouts.Contracts;
    using DemoSOLID.Loggers.Enums;
    using System;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            :base(layout)
        {
        }

        public ReportLevel ReportLevel { get; set; }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (this.ReportLevel <= reportLevel)
            {
                Console.WriteLine(string.Format(this.Layout.Format, dateTime, reportLevel, message));
            }
        }
    }
}
