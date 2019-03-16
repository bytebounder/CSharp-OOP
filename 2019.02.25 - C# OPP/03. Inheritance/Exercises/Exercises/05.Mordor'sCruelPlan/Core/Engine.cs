namespace _05.Mordor_sCruelPlan.Core
{
    using _05.Mordor_sCruelPlan.Factories;
    using _05.Mordor_sCruelPlan.Foods;
    using _05.Mordor_sCruelPlan.Moods;
    using System;

    public class Engine
    {
        private FoodFactory foodFactory;
        private MoodFactory moodFactory;

        public Engine()
        {
            this.foodFactory = new FoodFactory();
            this.moodFactory = new MoodFactory();
        }

        public void Run()
        {
            int points = 0;

            string[] input = Console.ReadLine().Split();

            for (int i = 0; i < input.Length; i++)
            {
                string type = input[i];

                Food currentFood = foodFactory.CreateFood(type);

                points += currentFood.Happiness;
            }


            Mood mood;

            if (points < -5)
            {
                mood = moodFactory.CreateMood("Angry");
            }
            else if (points >= -5 && points < 0)
            {
                mood = moodFactory.CreateMood("Sad");
            }
            else if (points >= 1 && points < 15)
            {
                mood = moodFactory.CreateMood("Happy");
            }
            else
            {
                mood = moodFactory.CreateMood("JavaScript");
            }

            Console.WriteLine(points);
            Console.WriteLine(mood.Name);
        }
    }
}