using System;


namespace _02.Lecture
{
    public class Program
    {
        public class Cat
        {
            public string Name { get; set; }

            public int Age { get; set; }

            public string Color { get; set; }
        }

        public static void Main(string[] args)
        {
            var firstCat = new
            {
                Name = "Pesho",
                Age = 6,
                Color = "Black",
                Image = "http://"
            };

            var secondCat = new
            {
                Name = "Ivan",
                Gender = "Male"
            };

            var thirdCat = new Cat();
            thirdCat.Color = "Black";

            var fourthCat = new Cat
            {
                Name = "Makarena"
            };
        }
    }
}
