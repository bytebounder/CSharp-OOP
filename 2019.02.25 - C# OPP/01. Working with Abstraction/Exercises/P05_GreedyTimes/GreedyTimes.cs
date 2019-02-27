namespace P05_GreedyTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GreedyTimes
    {
        static void Main(string[] args)
        {
            long maxBagCapacity = long.Parse(Console.ReadLine());
            string[] save = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bag = new Dictionary<string, Dictionary<string, long>>();
            long gold = 0;
            long gem = 0;
            long cash = 0;

            for (int i = 0; i < save.Length; i += 2)
            {
                string name = save[i];
                long amount = long.Parse(save[i + 1]);

                var item = Item(name);

                if (item == "")
                {
                    continue;
                }
                else if (maxBagCapacity < bag.Values.Select(x => x.Values.Sum()).Sum() + amount)
                {
                    continue;
                }

                if (GetValue(item, bag, amount))
                {
                    continue;
                }

                if (bag.ContainsKey(item) == false)
                {
                    bag[item] = new Dictionary<string, long>();
                }

                if (bag[item].ContainsKey(name) == false)
                {
                    bag[item][name] = 0;
                }

                bag[item][name] += amount;
                if (item == "Gold")
                {
                    gold += amount;
                }
                else if (item == "Gem")
                {
                    gem += amount;
                }
                else if (item == "Cash")
                {
                    cash += amount;
                }
            }

            Print(bag);
        }

        private static void Print(Dictionary<string, Dictionary<string, long>> bag)
        {
            foreach (var type in bag)
            {
                var totalAmount = type.Value.Values.Sum();

                Console.WriteLine($"<{type.Key}> ${totalAmount}");

                foreach (var items in type.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{items.Key} - {items.Value}");
                }
            }
        }

        private static string Item(string name)
        {
            string item = string.Empty;

            if (name.Length == 3)
            {
                item = "Cash";
            }
            else if (name.ToLower().EndsWith("gem"))
            {
                item = "Gem";
            }
            else if (name.ToLower() == "gold")
            {
                item = "Gold";
            }

            return item;
        }

        private static bool GetValue(string item, Dictionary<string, Dictionary<string, long>> bag, long amount)
        {
            switch (item)
            {
                case "Gem":
                    if (bag.ContainsKey(item) == false)
                    {
                        if (bag.ContainsKey("Gold"))
                        {
                            if (amount > bag["Gold"].Values.Sum())
                            {
                                return true;
                            }
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else if (bag[item].Values.Sum() + amount > bag["Gold"].Values.Sum())
                    {
                        return true;
                    }

                    break;
                case "Cash":
                    if (bag.ContainsKey(item) == false)
                    {
                        if (bag.ContainsKey("Gem"))
                        {
                            if (amount > bag["Gem"].Values.Sum())
                            {
                                return true;
                            }
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else if (bag[item].Values.Sum() + amount > bag["Gem"].Values.Sum())
                    {
                        return true;
                    }

                    break;
            }

            return false;
        }
    }
}