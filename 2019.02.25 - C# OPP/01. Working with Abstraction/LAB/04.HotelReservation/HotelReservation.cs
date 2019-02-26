namespace _04.HotelReservation
{
    using System;

    public class HotelReservation
    {
        public static void Main(string[] args)
        {
            var reservationInfo = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            decimal pricePerDay = decimal.Parse(reservationInfo[0]);
            int numberOfDays = int.Parse(reservationInfo[1]);
            Season season = new Season();
            switch (reservationInfo[2])
            {
                case "Summer":
                    season = Season.Summer;
                    break;
                case "Winter":
                    season = Season.Winter;
                    break;
                case "Spring":
                    season = Season.Spring;
                    break;
                case "Autumn":
                    season = Season.Autumn;
                    break;
            }

            Discount discount = new Discount();
            if (reservationInfo.Length == 4)
            {
                switch (reservationInfo[3])
                {
                    case "None":
                        discount = Discount.None;
                        break;
                    case "SecondVisit":
                        discount = Discount.SecondVisit;
                        break;
                    case "VIP":
                        discount = Discount.VIP;
                        break;
                }
            }
            else
            {
                discount = Discount.None;
            }

            Console.WriteLine($"{PriceCalculator.CalculatePrice(pricePerDay, numberOfDays, season, discount):F2}");
        }
    }
}