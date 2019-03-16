namespace _03.Mankind
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            var studentInfo = Console.ReadLine().Split();
            string studentFirstName = studentInfo[0];
            string studentLastName = studentInfo[1];
            string studentFacultyNumber = studentInfo[2];

            var workerInfo = Console.ReadLine().Split();
            string workerFirstName = workerInfo[0];
            string workerLastName = workerInfo[1];
            double workerWeekSalary = double.Parse(workerInfo[2]);
            double workerWorkingHours = double.Parse(workerInfo[3]);

            try
            {
                Student student = new Student(studentFirstName, studentLastName, studentFacultyNumber);
                Worker worker = new Worker(workerFirstName, workerLastName, workerWeekSalary, workerWorkingHours);

                Console.WriteLine(student);
                Console.WriteLine(worker);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}