
namespace _01.Logger.Appenders
{
    using _01.Logger.Appenders.Contracts;
    using _01.Logger.Layouts;
    using _01.Logger.Layouts.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ConsoleAppender : IAppender
    {
        private ILayout layout;

        public ConsoleAppender(ILayout layout)
        {
            this.layout = layout;
        }

        public void Append(string dateTime, string reportLevel, string message)
        {
            Console.WriteLine(string.Format(this.layout.Format, dateTime, reportLevel, message));
        }
    }
}
