namespace _05.PizzaCalories
{
    using System;
    using System.Collections.Generic;

    public class Dough
    {
        private const double BaseDoughtCalories = 2;

        private string flourType;
        private string bakingTechnique;
        private double weight;
        private Dictionary<string, double> validFlourTypes;
        private Dictionary<string, double> validBackingTechniques;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.validFlourTypes = new Dictionary<string, double>();
            this.validBackingTechniques = new Dictionary<string, double>();
            this.SeedFlourTypes();
            this.SeedBackingTechnuque();
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get => this.flourType;

            private set
            {
                if (this.validFlourTypes.ContainsKey(value.ToLower()) == false)
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;

            private set
            {
                if (this.validBackingTechniques.ContainsKey(value.ToLower()) == false)
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }

        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }

        public double CalculateCalories()
        {
            return (BaseDoughtCalories * this.Weight) 
                   * this.validFlourTypes[this.flourType.ToLower()] * this.validBackingTechniques[this.bakingTechnique.ToLower()];
        }

        private void SeedFlourTypes()
        {
            this.validFlourTypes.Add("white", 1.5);
            this.validFlourTypes.Add("wholegrain", 1.0);
        }

        private void SeedBackingTechnuque()
        {
            this.validBackingTechniques.Add("crispy", 0.9);
            this.validBackingTechniques.Add("chewy", 1.1);
            this.validBackingTechniques.Add("homemade", 1.0);
        }
    }
}