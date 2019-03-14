namespace _01.ClassBox
{
    using System;

    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.length = length;
            this.width = width;
            this.height = height;
        }

        private double CalculateSurfaceArea()
        {
            return 2 * (this.width * this.length) + CalculateLateralSurfaceArea();
        }

        private double CalculateLateralSurfaceArea()
        {
            return 2 * (this.length * this.height + this.width * this.height);
        }

        private double CalculateVolume()
        {
            return this.length * this.width * this.height;
        }

        public override string ToString()
        {
            return $"Surface Area - {CalculateSurfaceArea():F2}" + Environment.NewLine +
                   $"Lateral Surface Area - {CalculateLateralSurfaceArea():F2}" + Environment.NewLine +
                   $"Volume - {CalculateVolume():F2}";
        }
    }
}