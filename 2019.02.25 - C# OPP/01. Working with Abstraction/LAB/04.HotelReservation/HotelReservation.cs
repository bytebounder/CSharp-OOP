namespace _04.HotelReservation
{
    using System;

    public class HotelReservation
    {
        public static void Main(string[] args)
        {
            var reservationInfo = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            decimal pricePerDay = decimal.Parse(reservationInfo[0]);
            int days = int.Parse(reservationInfo[1]);
            Season season = Enum.Parse<Season>(reservationInfo[2]);
            Discount discount = Discount.None;

            if (reservationInfo.Length == 4)
            {
                discount = Enum.Parse<Discount>(reservationInfo[3]);
            }

            Console.WriteLine($"{PriceCalculator.CalculatePrice(pricePerDay, days, season, discount):F2}");
        }
    }
}