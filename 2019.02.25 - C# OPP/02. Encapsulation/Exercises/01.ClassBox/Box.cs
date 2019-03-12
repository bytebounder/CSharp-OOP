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

        public double GetSurfaceArea()
        {
            double surfaceArea = 2 * this.length * this.width + 2 * this.length * this.height +
                                 2 * this.width * this.height;

            return surfaceArea;
        }

        public double GetLateralSurfaceArea()
        {
            double lateralSurfaceArea = 2 * this.length * this.height + 2 * this.width * this.height;

            return lateralSurfaceArea;
        }

        public double GetVolume()
        {
            double volume = this.length * this.width * this.height;

            return volume;
        }

        public override string ToString()
        {
            return $"Surface Area - {GetSurfaceArea():F2}" + Environment.NewLine +
                   $"Lateral Surface Area - {GetLateralSurfaceArea():F2}" + Environment.NewLine +
                   $"Volume - {GetVolume():F2}";
        }
    }
}