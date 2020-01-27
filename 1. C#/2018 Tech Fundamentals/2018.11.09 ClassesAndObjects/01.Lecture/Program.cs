using System;

namespace _01.Lecture
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var firstCat = new
            {
                Name = "Pesho",
                Age = 6,
                Color = "Black"
            };

            string firstCatName = "Pesho";
            int firstCatAge = 6;
            string firstCatColor = "Black";

            var secondCat = new
            {
                Name = "Ivan",
                Age = 3,
                Color = "Orange"
            };

            string secondCatName = "Ivan";
            int secondCatAge = 3;
            string secondCatColor = "Orange";
        }
    }
}
