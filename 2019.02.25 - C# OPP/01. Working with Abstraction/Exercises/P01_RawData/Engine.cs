namespace P01_RawData
{
    public class Engine
    {
        public Engine(int power, int speed)
        {
            this.Power = power;
            this.Speed = speed;
        }

        public int Speed { get; set; }

        public int Power { get; set; }
    }
}