
namespace _03.Mankind
{
    using System;
    using System.Text;

    class Human
    {
        private const int MinFirstNameLength = 4;
        private const int MinLastNameLength = 3;
        private string firstName;
        private string lastName;

        public string FirstName
        {
            get => this.firstName;
            private set
            {
                this.ValidateFirstLetterIsUpper(value, nameof(this.firstName));
                
                this.ValidateLength(value, MinFirstNameLength, nameof(this.firstName));

                this.firstName = value;
            }
        }

        public string LastName
        {
            get => this.lastName;
            private set
            {
                this.ValidateFirstLetterIsUpper(value, nameof(this.lastName));

                this.ValidateLength(value, MinLastNameLength, nameof(this.lastName));

                this.lastName = value;
            }
        }

        private void ValidateLength(string value, int validLength, string parameterName)
        {
            if (value.Length < validLength)
            {
                throw new ArgumentException($"Expected length at least {validLength} symbols! Argument: {parameterName}");
            }
        }

        private void ValidateFirstLetterIsUpper(string value, string parameterName)
        {
            if (!char.IsUpper(value[0]))
            {
                throw new ArgumentException($"Expected upper case letter! Argument: {parameterName}");
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"First Name: {this.firstName}");
            builder.AppendLine($"Last Name: {this.lastName}");
            builder.AppendLine($"Faculty number: {this.fac}");

            return builder.ToString();
        }

    }
}


	
	
