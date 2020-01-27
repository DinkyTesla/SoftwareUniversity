
namespace _01.Logger.Files
{
    public interface IFile
    {
        int Size { get; }

        void Write(string content);
    }
}
