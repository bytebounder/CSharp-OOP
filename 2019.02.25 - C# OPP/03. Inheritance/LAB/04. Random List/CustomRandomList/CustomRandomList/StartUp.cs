using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();

            list.Add("Manchester United vs Liverpool");
            list.Add("Manchester United vs Manchester City");
            list.Add("Manchester United vs Tottenham Hotspurt");
            list.Add("Manchester United vs Ajax");
            list.Add("Manchester United vs Porto");
            list.Add("Manchester United vs Barcelona");
            list.Add("Manchester United vs Juventus");

            Console.WriteLine(list.RemoveRandomString());
        }
    }
}