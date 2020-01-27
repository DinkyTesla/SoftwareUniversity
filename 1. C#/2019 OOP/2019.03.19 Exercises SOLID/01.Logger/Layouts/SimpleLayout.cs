
namespace _01.Logger.Layouts
{
    using _01.Logger.Layouts.Contracts;

    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
