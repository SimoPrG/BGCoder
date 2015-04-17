namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public class Category : ICategory
    {
        private const int MinimumCategoryNameLenght = 2;
        private const int MaximumCategoryNameLenght = 15;

        private readonly ICollection<IProduct> products;

        private string name;

        public Category(string name)
        {
            this.Name = name;
            this.products = new List<IProduct>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, value));

                Validator.CheckIfStringLengthIsValid(
                    value,
                    MaximumCategoryNameLenght,
                    MinimumCategoryNameLenght,
                    string.Format(GlobalErrorMessages.InvalidStringLength, "Category name", MinimumCategoryNameLenght, MaximumCategoryNameLenght));

                this.name = value;
            }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            Validator.CheckIfNull(cosmetics, string.Format(GlobalErrorMessages.ObjectCannotBeNull, cosmetics));

            this.products.Add(cosmetics);
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            Validator.CheckIfNull(cosmetics, string.Format(GlobalErrorMessages.ObjectCannotBeNull, cosmetics));

            if (!this.products.Remove(cosmetics))
            {
                throw new ArgumentException(string.Format("Product {0} does not exist in category {1}!", cosmetics.Name, this.Name));
            }
        }

        public string Print()
        {
            StringBuilder result = new StringBuilder();

            var productMaybe = this.products.Count == 1 ? string.Empty : "s";

            result.AppendLine(string.Format("{0} category - {1} product{2} in total", this.Name, this.products.Count, productMaybe));

            foreach (var product in this.products.OrderBy(p => p.Brand).ThenByDescending(p => p.Price))
            {
                result.AppendLine(product.Print());
            }

            return result.ToString().TrimEnd();
        }
    }
}
