namespace P03_StudentSystem
{
    using System;
    using System.Collections.Generic;

    public class StudentSystem
    {
        private Student student;

        public StudentSystem()
        {
            this.Students = new Dictionary<string, Student>();
        }

        public Dictionary<string, Student> Students { get; private set; }

        public void Commands()
        {
            string[] commandParts = Console.ReadLine().Split();

            switch (commandParts[0])
            {
                case "Create":
                    Create(commandParts, commandParts[1]);
                    break;
                case "Show":
                    Show(commandParts[1]);
                    break;
                case "Exit":
                    Exit();
                    break;
            }
        }

        private void Show(string name)
        {
            if (this.Students.ContainsKey(name))
            {
                var student = this.Students[name];
                string view = $"{student.Name} is {student.Age} years old.";

                if (student.Grade >= 5.00)
                {
                    view += " Excellent student.";
                }
                else if (student.Grade < 5.00 && student.Grade >= 3.50)
                {
                    view += " Average student.";
                }
                else
                {
                    view += " Very nice person.";
                }

                Console.WriteLine(view);
            }
        }

        private static void Exit()
        {
            Environment.Exit(0);
        }

        private void Create(string[] commandParts, string name)
        {
            var age = int.Parse(commandParts[2]);
            var grade = double.Parse(commandParts[3]);

            if (this.Students.ContainsKey(name) == false)
            {
                var student = new Student(name, age, grade);
                Students[name] = student;
            }

            return;
        }
    }
}