namespace _03.Mankind
{
    using System;
    using System.Linq;

    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber) : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get => this.facultyNumber;
            private set
            {
                if (value.Any(s => !char.IsLetterOrDigit(s)) || value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentException("Invalid faculty number!");
                }

                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"Faculty number: {this.FacultyNumber}" + Environment.NewLine;
        }
    }
}