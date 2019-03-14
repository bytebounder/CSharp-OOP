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
            get => this.length;
            set
            {
                ValidateParameter(value, nameof(this.Length));
                this.length = value;
            }
        }

        public double Width
        {
            get => this.width;
            set
            {
                ValidateParameter(value, nameof(this.Width));
                this.width = value;
            }
        }

        public double Height
        {
            get => this.height;
            set
            {
                ValidateParameter(value, nameof(this.Height));
                this.height = value;
            }
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

        private void ValidateParameter(double value, string parameters)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{parameters} cannot be zero or negative.");
            }
        }

        public override string ToString()
        {
            return $"Surface Area - {CalculateSurfaceArea():F2}" + Environment.NewLine +
                   $"Lateral Surface Area - {CalculateLateralSurfaceArea():F2}" + Environment.NewLine +
                   $"Volume - {CalculateVolume():F2}";
        }
    }
}