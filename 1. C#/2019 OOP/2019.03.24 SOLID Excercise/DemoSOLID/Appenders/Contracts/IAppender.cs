
namespace DemoSOLID.Appenders.Contracts
{
    using DemoSOLID.Loggers.Enums;

    public interface IAppender
    {
        void Append(string dateTime, ReportLevel reportLevel, string message);

        ReportLevel ReportLevel { get; set; }
    }
}
