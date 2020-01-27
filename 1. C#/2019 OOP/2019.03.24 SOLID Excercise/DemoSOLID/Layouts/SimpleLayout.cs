
namespace DemoSOLID.Layouts
{
    using DemoSOLID.Layouts.Contracts;

    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
