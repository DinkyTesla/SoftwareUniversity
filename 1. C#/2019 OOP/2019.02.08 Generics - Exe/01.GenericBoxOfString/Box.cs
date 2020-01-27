
namespace _01.GenericBoxOfString
{
    public class Box<T>
    {
        private T someInput;

        //===Constructor===
        public Box(T someInput)
        {
            this.someInput = someInput;
        }
        //===Constructor===

        //===Override====
        public override string ToString()
        {
            return $"{someInput.GetType()}: {someInput}";
        }
        //===Override====
    }
}