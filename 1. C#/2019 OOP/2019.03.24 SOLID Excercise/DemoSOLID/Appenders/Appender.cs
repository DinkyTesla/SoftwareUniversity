using DemoSOLID.Appenders.Contracts;
using DemoSOLID.Layouts.Contracts;
using DemoSOLID.Loggers.Enums;
using System;

namespace DemoSOLID.Appenders
{
    public abstract class Appender : IAppender
    {

        protected Appender(ILayout layout)
        {
            this.Layout = layout;
        }

        protected ILayout Layout { get; }

        public ReportLevel ReportLevel { get; set; }

        public abstract void Append(string dateTime, ReportLevel reportLevel, string message);
    }
}
