namespace StudentSystemCatalog
{
    using Commands;
    using Data;
    using Students;

    public class Engine
    {
        private CommandParser commandParser;
        private StudentSystem studentSystem;

        private IDataReader dataReader;
        private IDataWriter dataWriter;

        public Engine(
            CommandParser commandParser,
            StudentSystem studentSystem,
            IDataReader dataReader,
            IDataWriter dataWriter)
        {
            this.commandParser = commandParser;
            this.studentSystem = studentSystem;
            this.dataReader = dataReader;
            this.dataWriter = dataWriter;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    var data = this.dataReader.Read(); // Read input from console
                    var command = commandParser.Parse(data); // Split input from 1 to several parts => 1. Name ; 2. Arguments

                    if (command.Name == "Create")
                    {
                        var name = command.Arguments[0];
                        var age = int.Parse(command.Arguments[1]);
                        var grade = double.Parse(command.Arguments[2]);

                        studentSystem.Add(name, age, grade); // Add Student
                    }
                    else if (command.Name == "Show")
                    {
                        var name = command.Arguments[0];

                        var student = studentSystem.Get(name); // Get the student with this name from all students

                        this.dataWriter.Write(student); // Print in console current Student with his age 
                    }
                    else if (command.Name == "Exit")
                    {
                        break;
                    }
                }
                catch
                {
                    continue;
                }
            }
        }
    }
}