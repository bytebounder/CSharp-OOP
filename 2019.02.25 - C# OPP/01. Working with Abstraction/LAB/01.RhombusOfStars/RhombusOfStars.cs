namespace _01.RhombusOfStars
{
    using System;

    class RhombusOfStars
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            UpperPart(size);
            LowerPart(size);
        }

        private static void LowerPart(int size)
        {
            for (int starCount = size - 1; starCount >= 1; starCount--)
            {
                PrintRow(size, starCount);
            }
        }

        private static void UpperPart(int size)
        {
            for (int starCount = 1; starCount <= size; starCount++)
            {
                PrintRow(size, starCount);
            }
        }

        private static void PrintRow(int figureSize, int starCount)
        {
            for (int i = 0; i < figureSize - starCount; i++)
            {
                Console.Write(" ");
            }

            for (int col = 1; col < starCount; col++)
            {
                Console.Write("* ");
            }

            Console.WriteLine("*");
        }
    }
}