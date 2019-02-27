namespace P01_RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RawData
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>();

            var input = int.Parse(Console.ReadLine());

            for (int i = 0; i < input; i++)
            {
                var commands = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                var model = Model(commands);

                var engine = Engine(commands);

                var cargo = Cargo(commands);

                var tires = Tires(commands);

                var car = new Car(model, engine, cargo, tires);

                cars.Add(car);
            }

            string type = Console.ReadLine();

            Type(type, cars);
        }

        private static void Type(string type, List<Car> cars)
        {
            if (type == "fragile")
            {
                foreach (var car in cars.Where(x => x.Cargo.Type == type))
                {
                    bool pressure = car.Tires.Select(x => x.Pressure < 1).FirstOrDefault();
                    if (pressure)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
            else if (type == "flamable")
            {
                foreach (var car in cars.Where(x => x.Cargo.Type == type))
                {
                    bool pressure = car.Engine.Power > 250;
                    if (pressure)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
        }

        private static Tire[] Tires(string[] commands)
        {
            Tire1(commands, out var tire1Pressure, out var tire1Age);
            Tire2(commands, out var tire2Pressure, out var tire2Age);
            Tire3(commands, out var tire3Pressure, out var tire3Age);
            Tire4(commands, out var tire4Pressure, out var tire4Age);

            var tires = new Tire[4]
            {
                new Tire(tire1Pressure, tire1Age),
                new Tire(tire2Pressure, tire2Age),
                new Tire(tire3Pressure, tire3Age),
                new Tire(tire4Pressure, tire4Age),
            };

            return tires;
        }

        private static void Tire4(string[] commands, out double tire4Pressure, out int tire4Age)
        {
            tire4Pressure = double.Parse(commands[11]);
            tire4Age = int.Parse(commands[12]);
        }

        private static void Tire3(string[] commands, out double tire3Pressure, out int tire3Age)
        {
            tire3Pressure = double.Parse(commands[9]);
            tire3Age = int.Parse(commands[10]);
        }

        private static void Tire2(string[] commands, out double tire2Pressure, out int tire2Age)
        {
            tire2Pressure = double.Parse(commands[7]);
            tire2Age = int.Parse(commands[8]);
        }

        private static void Tire1(string[] commands, out double tire1Pressure, out int tire1Age)
        {
            tire1Pressure = double.Parse(commands[5]);
            tire1Age = int.Parse(commands[6]);
        }

        private static Cargo Cargo(string[] commands)
        {
            int cargoWeight = int.Parse(commands[3]);
            string cargoType = commands[4];
            Cargo cargo = new Cargo(cargoWeight, cargoType);

            return cargo;
        }

        private static Engine Engine(string[] commands)
        {
            int engineSpeed = int.Parse(commands[1]);
            int enginePower = int.Parse(commands[2]);
            Engine engine = new Engine(enginePower, engineSpeed);

            return engine;
        }

        private static string Model(string[] commands)
        {
            string model = commands[0];
            return model;
        }
    }
}