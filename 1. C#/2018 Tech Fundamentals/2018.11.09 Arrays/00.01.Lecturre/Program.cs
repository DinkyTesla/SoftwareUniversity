using System;

namespace _00._01.Lecturre
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] numbers = new int[20];

            numbers[13] = 1000;
            numbers[19] = 7;
            numbers[7] = 500;

            //Масива не може да се променя веднъж създаден, освен ако нямаме достъп до сорс кода. Съответно трябва
            //да се създаде нов.
            int[] otherNumbers = new int[50];

            // tadaaa
            int firstNumber = numbers[10];
            int secondNumber = numbers[15];

            Console.WriteLine(numbers.Length); //Така се вади дължината на масива (броят на елементите).

            //С променлива дължина.
            int n = int.Parse(Console.ReadLine());

            int[] newNumbers = new int[n];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i; //на всяка клетка ще се запише числото за всяка клетка.
            }

        }
    }
}
