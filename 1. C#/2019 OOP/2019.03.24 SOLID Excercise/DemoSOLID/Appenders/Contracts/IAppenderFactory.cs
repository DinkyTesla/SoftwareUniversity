using DemoSOLID.Layouts.Contracts;

namespace DemoSOLID.Appenders.Contracts
{
    public interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout);
    }
}
