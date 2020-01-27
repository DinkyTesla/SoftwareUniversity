
namespace _01.ClassBox
{
    using System.Text;

    public class Box
    {
        //public double Length { get; private set; }
        //public double Width { get; private set; }
        //public double Height { get; private set; }

        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.length = length;
            this.width = width;
            this.height = height;
        }

        //public bool DataIsValid()
        //{
        //    if (length >= 0
        //        && width >= 0
        //        && height >= 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        throw new System.Exception("The Input Data Is Invalid, Bitch!");
        //    }
        //}

        public double CalculateSurfaceArea()
        {
            return 2 * (this.length * this.width) + this.CalculateLateralArea();
        }

        public double CalculateLateralArea()
        {
            return 2 * ((this.length + this.width) * this.height);
        }

        public double Volume()
        {
            return this.length * this.width * this.height;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Surface Area - {this.CalculateSurfaceArea():F2}");
            result.AppendLine($"Lateral Surface Area - {this.CalculateLateralArea():F2}");
            result.Append($"Volume - {this.Volume():F2}");

            return result.ToString();
        }
    }
}
