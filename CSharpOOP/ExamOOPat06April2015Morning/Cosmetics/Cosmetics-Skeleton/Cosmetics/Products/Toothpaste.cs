namespace Cosmetics.Products
{
    using System.Collections.Generic;
    using System.Text;

    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public class Toothpaste : Product, IProduct, IToothpaste
    {
        private const int MinimumIngredientNameLenght = 4;
        private const int MaximumIngredientNameLenght = 12;

        private IEnumerable<string> ingredientsCollection;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients)
            : base(name, brand, price, gender)
        {
            this.IngredientsCollection = ingredients;
        }

        public string Ingredients
        {
            get { return string.Join(", ", this.ingredientsCollection); }
        }

        private IEnumerable<string> IngredientsCollection
        {
            set
            {
                Validator.CheckIfNull(value, string.Format(GlobalErrorMessages.ObjectCannotBeNull, value));

                foreach (var ingredient in value)
                {
                    Validator.CheckIfStringIsNullOrEmpty(
                        ingredient,
                        string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, ingredient));
                    Validator.CheckIfStringLengthIsValid(
                        ingredient,
                        MaximumIngredientNameLenght,
                        MinimumIngredientNameLenght,
                        string.Format(
                            GlobalErrorMessages.InvalidStringLength,
                            "Each ingredient",
                            MinimumIngredientNameLenght,
                            MaximumIngredientNameLenght));

                    this.ingredientsCollection = value;
                }
            }
        }

        public override string Print()
        {
            StringBuilder result = new StringBuilder();

            result.Append(base.Print());
            result.Append(string.Format("  * Ingredients: {0}", this.Ingredients));

            return result.ToString();
        }
    }
}
