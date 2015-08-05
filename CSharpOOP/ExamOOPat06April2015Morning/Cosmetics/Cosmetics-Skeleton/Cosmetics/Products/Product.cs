namespace Cosmetics.Products
{
    using System;
    using System.Globalization;
    using System.Text;

    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public abstract class Product : IProduct
    {
        private const int MinimumProductNameLenght = 3;
        private const int MaximumProductNameLenght = 10;
        private const int MinimumBrandNameLenght = 2;
        private const int MaximumBrandNameLenght = 10;

        private string name;
        private string brand;

        protected Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
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
                    MaximumProductNameLenght,
                    MinimumProductNameLenght,
                    string.Format(GlobalErrorMessages.InvalidStringLength, "Product name", MinimumProductNameLenght, MaximumProductNameLenght));

                this.name = value;
            }
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }

            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, value));

                Validator.CheckIfStringLengthIsValid(
                    value,
                    MaximumBrandNameLenght,
                    MinimumBrandNameLenght,
                    string.Format(GlobalErrorMessages.InvalidStringLength, "Product brand", MinimumBrandNameLenght, MaximumBrandNameLenght));

                this.brand = value;
            }
        }

        public decimal Price { get; private set; }

        public GenderType Gender { get; private set; }

        public virtual string Print()
        {
            IFormatProvider formatProvider = new CultureInfo("en-US");
            StringBuilder result = new StringBuilder();

            result.AppendLine(string.Format("- {0} - {1}:", this.Brand, this.Name));
            result.AppendLine(string.Format(formatProvider, "  * Price: {0:C}", this.Price));
            result.AppendLine(string.Format("  * For gender: {0}", this.Gender));

            return result.ToString();
        }
    }
}
