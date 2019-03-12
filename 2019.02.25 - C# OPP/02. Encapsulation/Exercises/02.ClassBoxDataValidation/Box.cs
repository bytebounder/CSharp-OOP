namespace _02.ClassBoxDataValidation
{
    using System;

    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get => length;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }

                this.length = value;
            }
        }

        public double Width
        {
            get => width;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get => height;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }

                this.height = value;
            }
        }

        public double GetSurfaceArea()
        {
            double surfaceArea = 2 * this.Length * this.Width + 2 * this.Length * this.Height +
                                 2 * this.Width * this.Height;

            return surfaceArea;
        }

        public double GetLateralSurfaceArea()
        {
            double lateralSurfaceArea = 2 * this.Length * this.Height + 2 * this.Width * this.Height;

            return lateralSurfaceArea;
        }

        public double GetVolume()
        {
            double volume = this.Length * this.Width * this.Height;

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