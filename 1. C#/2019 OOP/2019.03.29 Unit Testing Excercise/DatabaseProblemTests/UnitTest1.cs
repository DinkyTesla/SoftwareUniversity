using NUnit.Framework;
using DatabaseProblem;
using System;

namespace Tests
{
    public class DatabaseTests
    {
        private const int DatabaseCapacity = 16;

        private Database database;

        [SetUp]
        public void Setup()
        {
            this.database = new Database();
        }

        [Test]
        public void AddMethodShouldThrowExceptionForFullDatabase()
        {
            for (int i = 0; i < 16; i++)
            {
                this.database.Add(45);
            }

            Assert.Throws<ArgumentException>(() => this.database.Add(458));
        }
    }
}