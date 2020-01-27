
namespace _03.Mankind
{
    using System;
    using System.Linq;

    class Sudent : Human
    {
        private string facultyNumber; 

        public Student(string firstName, string lastName, string facultyNumner)
            :base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumner;
        }

        public string FacultyNumber
        {
            get => this.facultyNumber;

            private set
            {
                if (value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentException("Invalid faculty number!");
                }

                if (value.All(x=>char.IsLetterOrDigit(x)))
                {
                    throw new ArgumentException("Invalid faculty number!");
                }

                this.facultyNumber = value;
            }
        }
    }
}
