
namespace _32.CarSalesman
{
    using System.Text;

    public class Car
    {

        private const string DefaultValueString = "n/a";
        private const int DefaultValueInt = -1;

        public Car(string model, Engine engine, double weight, string color)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }

        public Car(string model, Engine engine, double weight)
            : this(model, engine, weight, DefaultValueString)
        {
        }

        public Car(string model, Engine engine, string color)
            : this(model, engine, DefaultValueInt, color)
        {
        }

        public Car(string model, Engine engine)
            : this(model, engine, DefaultValueInt, DefaultValueString)
        {
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public double Weight { get; set; }

        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"{this.Model}:");
            result.AppendLine($"{this.Engine}");
            if (this.Weight == -1)
            {
                result.AppendLine($"    Weight: n/a");
            }
            else
            {
                result.AppendLine($"    Weight: {this.Weight}");
            }
            result.Append($"  Color: {this.Color}");

            return result.ToString();
        }
    }
}
