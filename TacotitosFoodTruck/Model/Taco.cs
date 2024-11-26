using TacotitosFoodTruck.Model;

public class Taco
{
    public int TacoId { get; set; }
    public string Name { get; set; }
    public List<Tortilla> Tortillas { get; set; }
    public List<Ingredient> Ingredients { get; set; }
    public Sauce Sauce { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime CreatedAt { get; set; }

    // Constructor sin parámetros
    public Taco()
    {
        Tortillas = new List<Tortilla>();
        Ingredients = new List<Ingredient>();
    }

    // Constructor con parámetros
    public Taco(string name, List<Tortilla> tortillas, List<Ingredient> ingredients, Sauce sauce)
    {
        Name = name;
        Tortillas = tortillas;
        Ingredients = ingredients;
        Sauce = sauce;
        CalculateTotalPrice();
        CreatedAt = DateTime.Now;
    }



    public void CalculateTotalPrice()
    {
        TotalPrice = 0; // Inicializamos el precio total

        // Sumar el precio de la salsa
        if (Sauce != null)
        {
            TotalPrice += Sauce.Price;
        }

        // Sumar el precio de las tortillas
        if (Tortillas != null && Tortillas.Any())
        {
            TotalPrice += Tortillas.Sum(t => t.Price);
        }

        // Sumar el precio de los ingredientes
        if (Ingredients != null && Ingredients.Any())
        {
            TotalPrice += Ingredients.Sum(i => i.Price);
        }
    }

}
