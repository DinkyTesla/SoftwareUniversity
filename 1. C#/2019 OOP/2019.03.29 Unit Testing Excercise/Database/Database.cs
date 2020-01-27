
namespace DatabaseProblem
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Database
    {
        //Fields
        private const int Capacity = 16;

        private int[] еlementsArray;
        private int count;

        //Constructor
        public Database(params int[] givenInput)// params дава 0 или повече.
        {
            this.еlementsArray = new int[Capacity];

            if (givenInput.Length > Capacity)
            {
                throw new ArgumentException("The Database class cannot hold more than 16 elements.");
            }

            foreach (var element in givenInput)
            {
                this.Add(element);
            }
        }

        
        //Method for adding.
        public void Add(int givenElement)
        {
            if (this.count == Capacity)
            {
                throw new ArgumentException("The Database is currently holding 16 elements which is the maximum allowed capacity.");
            }

            this.еlementsArray[count] = givenElement;

            this.count++;
        }

        //Method for removing.
        public void Remove(int givenElement)
        {
            if (this.count == 0)
            {
                throw new ArgumentException("Cannot remove element because the Database is already empty.");
            }

            this.еlementsArray[count] = 0;

            this.count--;
        }

        //Method for fetching array.
        public int[] Fetch()
        {
            return this.еlementsArray;
        }

    }
}
