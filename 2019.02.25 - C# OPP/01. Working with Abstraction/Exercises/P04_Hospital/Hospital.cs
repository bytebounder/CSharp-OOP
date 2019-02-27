namespace P04_Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Hospital
    {
        public static void Main()
        {
            Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();
            Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();

            string command = Console.ReadLine();

            while (command != "Output")
            {
                var patientInfo = Departament(command, out var departament, out var doctorFullName, out var name);

                IsDoctorsContainsDoctor(doctors, doctorFullName);

                IsDepartmentsContainsDepartment(departments, departament);

                IsHavePlace(departments, departament, doctors, doctorFullName, name);

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] splitedCommand = command.Split();

                Print(splitedCommand, departments, doctors);

                command = Console.ReadLine();
            }
        }

        private static void Print(string[] command, Dictionary<string, List<List<string>>> departments, Dictionary<string, List<string>> doctors)
        {
            if (command.Length == 1)
            {
                Console.WriteLine(string.Join("\n", departments[command[0]].Where(x => x.Count > 0).SelectMany(x => x)));
            }
            else if (command.Length == 2 && int.TryParse(command[1], out int room))
            {
                Console.WriteLine(string.Join("\n", departments[command[0]][room - 1].OrderBy(x => x)));
            }
            else
            {
                Console.WriteLine(string.Join("\n", doctors[command[0] + command[1]].OrderBy(x => x)));
            }
        }

        private static void IsDoctorsContainsDoctor(Dictionary<string, List<string>> doctors, string doctorFullName)
        {
            if (doctors.ContainsKey(doctorFullName) == false)
            {
                doctors[doctorFullName] = new List<string>();
            }
        }

        private static void IsDepartmentsContainsDepartment(Dictionary<string, List<List<string>>> departments, string departament)
        {
            if (departments.ContainsKey(departament) == false)
            {
                departments[departament] = new List<List<string>>();

                for (int rooms = 0; rooms < 20; rooms++)
                {
                    departments[departament].Add(new List<string>());
                }
            }
        }

        private static string[] Departament(string command, out string departament, out string doctorFullName, out string name)
        {
            string[] patientInfo = command.Split();

            departament = patientInfo[0];
            doctorFullName = patientInfo[1] + patientInfo[2];
            name = patientInfo[3];
            return patientInfo;
        }

        private static void IsHavePlace(Dictionary<string, List<List<string>>> departments, string departament, Dictionary<string, List<string>> doctors, string doctorFullName,
            string name)
        {
            bool havePlace = departments[departament].SelectMany(x => x).Count() < 60;

            if (havePlace)
            {
                doctors[doctorFullName].Add(name);

                int rooms = 0;

                for (int bed = 0; bed < departments[departament].Count; bed++)
                {
                    if (departments[departament][bed].Count < 3)
                    {
                        rooms = bed;
                        break;
                    }
                }

                departments[departament][rooms].Add(name);
            }
        }
    }
}