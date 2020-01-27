
namespace DemoSOLID.Appenders
{
    using DemoSOLID.Appenders.Contracts;
    using DemoSOLID.Layouts.Contracts;
    using DemoSOLID.Loggers.Contracts;
    using DemoSOLID.Loggers.Enums;
    using System;
    using System.IO;

    public class FileAppender : Appender
    {
        private const string Path = @"..\..\..\log.txt";
        private ILogFile logFile;

        public FileAppender(ILayout layout, ILogFile logFile)
            :base(layout)
        {
            this.logFile = logFile;
        }

        public ReportLevel ReportLevel { get; set; }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (this.ReportLevel <= reportLevel)
            {
                string content = string.Format(this.Layout.Format, dateTime, reportLevel, message) + Environment.NewLine;
                File.AppendAllText(Path, content);
            }
        }
    }
}
