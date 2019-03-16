namespace _03.Mankind
{
    using System;

    public class Worker : Human
    {
        private double weekSalary;
        private double workHoursPerDay;

        public Worker(string firstName, string lastName, double weekSalary, double workHoursPerDay) : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public double WeekSalary
        {
            get => this.weekSalary;
            set
            {
                if (value < 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }

                this.weekSalary = value;
            }
        }

        public double WorkHoursPerDay
        {
            get => this.workHoursPerDay;
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }

                this.workHoursPerDay = value;
            }
        }

        public double CalculateWeekSalary()
        {
            double result = (this.weekSalary / 5.0) / this.workHoursPerDay;

            return result;
        }

        public override string ToString()
        {
            return base.ToString() 
                   + $"Week Salary: {this.WeekSalary:F2}" + Environment.NewLine 
                   + $"Hours per day: {this.WorkHoursPerDay:F2}" + Environment.NewLine 
                   + $"Salary per hour: {CalculateWeekSalary().ToString("f2")}";
        }
    }
}