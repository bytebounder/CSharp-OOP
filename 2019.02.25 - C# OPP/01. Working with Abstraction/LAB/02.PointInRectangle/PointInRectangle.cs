namespace _02.PointInRectangle
{
    using System;
    using System.Linq;

    class PointInRectangle
    {
        static void Main(string[] args)
        {
            var coordinates = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var rectangle = Rectangle(coordinates);

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var point = Point();

                IsInsideOrOutside(rectangle, point);
            }
        }

        private static Point Point()
        {
            var points = Console.ReadLine().Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            var x = points[0];
            var y = points[1];
            var point = new Point(x, y);
            return point;
        }

        private static Rectangle Rectangle(int[] coordinates)
        {
            var topLeft = new Point(coordinates[0], coordinates[1]);
            var bottomRight = new Point(coordinates[2], coordinates[3]);
            var rectangle = new Rectangle(topLeft, bottomRight);
            return rectangle;
        }

        private static void IsInsideOrOutside(Rectangle rectangle, Point point)
        {
            if (rectangle.Contains(point))
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}