namespace _04.HotelReservation
{
    public class PriceCalculator
    {
        public static decimal CalculatePrice(decimal pricePerDay, int days, Season season, Discount discount)
        {
            int multiplier = (int)season;
            decimal discountMultiplier = (decimal)discount / 100;

            decimal priceBeforeDiscount = days * pricePerDay * multiplier;
            decimal discountedAmount = priceBeforeDiscount * discountMultiplier;
            decimal finalPrice = priceBeforeDiscount - discountedAmount;

            return finalPrice;
        }
    }
}