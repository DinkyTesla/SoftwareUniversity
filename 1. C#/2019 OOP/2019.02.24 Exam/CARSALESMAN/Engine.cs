
namespace _32.CarSalesman
{
    using System.Text;

    public class Engine
    {
        private const string DefaultValueString = "n/a";
        private const int DefaultValueInt = -1;

        public Engine(string model, int power, int displacement, string efficiency)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement)
            : this(model, power, displacement, DefaultValueString)
        {
        }

        public Engine(string model, int power, string efficiency)
            : this(model, power, DefaultValueInt, efficiency)
        {
        }

        public Engine(string model, int power)
            : this(model, power, DefaultValueInt, DefaultValueString)
        {
        }

        public string Model { get; set; }

        public int Power { get; set; }

        public int Displacement { get; set; }

        public string Efficiency { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"  {this.Model}:");
            result.AppendLine($"    Power: {this.Power}");
            if (this.Displacement == -1)
            {
                result.AppendLine($"    Displacement: n/a");
            }
            else
            {
                result.AppendLine($"    Displacement: {this.Displacement}");
            }
            result.Append($"    Efficiency: {this.Efficiency}");

            return result.ToString();
        }
    }
}
