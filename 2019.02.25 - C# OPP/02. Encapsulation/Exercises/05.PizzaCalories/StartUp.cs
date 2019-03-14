namespace _05.PizzaCalories
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                string[] pizzaArgs = Console.ReadLine().Split();

                string pizzaName = pizzaArgs[1];

                string[] doughArgs = Console.ReadLine().Split();

                string doughFlourType = doughArgs[1];
                string doughBackingTechnique = doughArgs[2];
                double weight = double.Parse(doughArgs[3]);

                Dough dough = new Dough(doughFlourType, doughBackingTechnique, weight);

                Pizza pizza = new Pizza(pizzaName, dough);

                string inputLine = Console.ReadLine();

                while (inputLine != "END")
                {
                    string[] toppingArgs = inputLine.Split();

                    string toppingType = toppingArgs[1];
                    double weightTopping = double.Parse(toppingArgs[2]);

                    Topping topping = new Topping(toppingType, weightTopping);

                    pizza.AddTopping(topping);

                    inputLine = Console.ReadLine();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.GetTotalCalories().ToString("f2")} Calories.");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}