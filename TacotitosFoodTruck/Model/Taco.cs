using System;
using System.Collections.Generic;
using System.Linq;

namespace TacotitosFoodTruck.Model
{
    public class Taco
    {
        public int TacoId { get; set; }
        public string Name { get; set; }
        public List<Tortilla> Tortillas { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public Sauce Sauce { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }

        public Taco()
        {
            Tortillas = new List<Tortilla>();
            Ingredients = new List<Ingredient>();
        }


        public void AddTortillas(List<Tortilla> tortillas)
        {
            if (Tortillas.Count + tortillas.Count > 2)
            {
                throw new ArgumentException("Un taco no puede tener más de dos tortillas.");
            }
            Tortillas.AddRange(tortillas);
            CalculateTotalPrice();
        }

        public void AddIngredients(List<Ingredient> ingredients)
        {
            if (Ingredients.Count + ingredients.Count > 5)
            {
                throw new ArgumentException("Un taco no puede tener más de cinco ingredientes.");
            }
            Ingredients.AddRange(ingredients);
            CalculateTotalPrice();
        }

        public void SetSauce(Sauce sauce)
        {
            Sauce = sauce;
            CalculateTotalPrice();
        }

        public void CalculateTotalPrice()
        {
            decimal tortillasTotal = 0;
            foreach (Tortilla tortilla in Tortillas)
            {
                tortillasTotal += tortilla.Price;
            }

            decimal ingredientsTotal = 0;
            foreach (Ingredient ingredient in Ingredients)
            {
                ingredientsTotal += ingredient.Price;
            }

            decimal saucePrice = 0;
            if (Sauce != null)
            {
                saucePrice = Sauce.Price;
            }

            TotalPrice = tortillasTotal + ingredientsTotal + saucePrice;
        }

        public class SelectedItemView
        {
            public string Category { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
        }

        public List<SelectedItemView> GetSelectedItemViews()
        {
            var selectedItems = new List<SelectedItemView>();

            foreach (var tortilla in Tortillas)
            {
                selectedItems.Add(new SelectedItemView
                {
                    Category = "Tortilla",
                    Name = tortilla.Name,
                    Price = tortilla.Price
                });
            }

            foreach (var ingredient in Ingredients)
            {
                selectedItems.Add(new SelectedItemView
                {
                    Category = "Ingrediente",
                    Name = ingredient.Name,
                    Price = ingredient.Price
                });
            }

            if (Sauce != null)
            {
                selectedItems.Add(new SelectedItemView
                {
                    Category = "Salsa",
                    Name = Sauce.Name,
                    Price = Sauce.Price
                });
            }

            return selectedItems;
        }
    }
}

