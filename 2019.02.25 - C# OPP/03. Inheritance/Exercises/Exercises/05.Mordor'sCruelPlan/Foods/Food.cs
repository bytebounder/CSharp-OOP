namespace _05.Mordor_sCruelPlan.Foods
{
    public abstract class Food
    {
        public Food(int hapiness)
        {
            this.Happiness = hapiness;
        }

        public int Happiness { get; private set; }
    }
}