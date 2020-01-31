using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.__Student_Academy_EXE
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> studentsGrades = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (studentsGrades.ContainsKey(name) == false)
                {
                    studentsGrades[name] = new List<double>();
                }
                studentsGrades[name].Add(grade);
            }

            Dictionary<string, List<double>> filteredStudentGrades = studentsGrades
                .Where(x => x.Value.Average() >= 4.50)
                .OrderByDescending(x => x.Value.Average())
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in filteredStudentGrades)
            {
                string name = kvp.Key;
                List<double> grades = kvp.Value;

                Console.WriteLine($"{name} -> {grades.Average():f2}");
            }
        }
    }
}
