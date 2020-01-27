namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class Tests
    {
        [Test]
        public void Constructor_ShouldSetPropperValues()
        {
            Phone phone = new Phone("Nokia", "3310");
            string make = phone.Make;
            string expectedMake = "Nokia";
            string model = phone.Model;
            string expectedModel = "3310";
            int expectedCount = 0;
            int count = phone.Count;

            Assert.AreEqual(expectedMake, make);
            Assert.AreEqual(expectedModel, model);
            Assert.AreEqual(expectedCount, count);
        }

        [Test]
        public void Make_GetterWorksCorrectly()
        {
            Phone phone = new Phone("Nokia", "3310");
            string make = phone.Make;
            string expectedMake = "Nokia";

            Assert.AreEqual(expectedMake, make);
        }

        [Test]
        public void Make_SetterThrowsArgumentException_NullMake()
        {
            Assert.Throws<ArgumentException>(() => new Phone("", "3310"),
                "Make does not set correctly!");
        }

        [Test]
        public void Model_GetterWorksCorrectly()
        {
            Phone phone = new Phone("Nokia", "3310");
            string model = phone.Model;
            string expectedModel = "3310";

            Assert.AreEqual(expectedModel, model);
        }

        [Test]
        public void Model_SetterThrowsArgumentException_NullModel()
        {
            Assert.Throws<ArgumentException>(() => new Phone("Nokia", ""),
                "Model does not set correctly!");
        }

        [Test]
        public void AddContactAndCall_WorksCorrectly_ValidData()
        {
            Phone phone = new Phone("Nokia", "3310");

            string validName = "Pesho";
            string validPhoneNumber = "0878877988";
            string stringToEvaluate = $"Calling {validName} - {validPhoneNumber}...";

            phone.AddContact(validName, validPhoneNumber);
            string validNameAdded = phone.Call("Pesho").ToString();

            Assert.AreEqual(stringToEvaluate, validNameAdded);
        }

        [Test]
        public void AddContactAndCall_ThrowsInvalidOperationException_InvalidName()
        {
            Phone phone = new Phone("Nokia", "3310");

            string validName = "Pesho";
            string validPhoneNumber = "0878877988";

            phone.AddContact(validName, validPhoneNumber);
            string invalidName = "Gosho";

            Assert.Throws<InvalidOperationException>(() => phone.Call(invalidName)
            , "Call Function Misbehaves!");
        }

        [Test]
        public void Phonebook_AddCountIsOk()
        {
            Phone phone = new Phone("Nokia", "3310");

            string validName = "Pesho";
            string secondValidName = "Gosho";
            string validPhoneNumber = "0878877988";
            string secondValidPhoneNumber = "0878877989";
            phone.AddContact(validName, validPhoneNumber);
            phone.AddContact(secondValidName, secondValidPhoneNumber);

            int phonebookExpectedCount = 2;
            int phonebookCount = phone.Count;

            Assert.AreEqual(phonebookExpectedCount, phonebookCount);
        }
    }
}
//Ctor set propper values
//Make_IsOK
//Make Throws ArgumentException for null
//Model is OK
//Model Throws ArgumentException for null
//AddContact is ok
//AddContact Throws InvalidOperationException for contains name
//Phonebook count is ok
//Call is ok
//Call throws InvalidOperationException for wrong name