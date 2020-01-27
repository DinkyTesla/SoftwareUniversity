
namespace _01.Logger.Appenders
{
    using _01.Logger.Appenders.Contracts;
    using _01.Logger.Layouts.Contracts;
    using System.IO;
    using System;

    public class FileAppender : IAppender
    {
        private const string Path = @"..\..\..\log.txt";
        private ILayout layout;

        public FileAppender(ILayout layout)
        {
            this.layout = layout;
        }

        public void Append(string dateTime, string reportLevel, string message)
        {
            string content = string.Format(this.layout.Format, dateTime, reportLevel, message)
                + Environment.NewLine;

               File.AppendAllText(Path, content);
        }
    }
}
