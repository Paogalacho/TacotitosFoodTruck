using MySql.Data.MySqlClient;
using System.Data.Common;
using TacotitosFoodTruck.DAO;




public class TacoController
{
    private readonly TacoDao tacoDao;
  

    public TacoController()
    {
        tacoDao = new TacoDao();

    }



    public void CreateTaco(Taco taco)
    {
        try
        {
            taco.CalculateTotalPrice(); // Centralizar la lógica del cálculo
            tacoDao.AddTaco(taco);
        }
        catch (Exception ex)
        {
            throw new Exception("Error creating taco: " + ex.Message, ex);
        }
    }

    public List<Taco> GetAllTacos()
    {
        try
        {
            return tacoDao.GetAllTacos();
        }
        catch (Exception ex)
        {
            throw new Exception("Error fetching tacos: " + ex.Message, ex);
        }
    }

    // Obtener el taco más económico
    public Taco GetCheapestTaco()
    {
        try
        {
            return tacoDao.GetCheapestTaco();
        }
        catch (Exception ex)
        {
            throw new Exception("Error fetching the cheapest taco: " + ex.Message, ex);
        }
    }

    // Obtener el taco más costoso
    public Taco GetMostExpensiveTaco()
    {
        try
        {
            return tacoDao.GetMostExpensiveTaco();
        }
        catch (Exception ex)
        {
            throw new Exception("Error fetching the most expensive taco: " + ex.Message, ex);
        }
    }

    // Obtener el promedio del precio de los tacos
    public decimal GetAveragePrice()
    {
        try
        {
            return tacoDao.GetAveragePrice();

        }
        catch (Exception ex)
        {
            throw new Exception("Error calculating the average price: " + ex.Message, ex);
        }
    }



    


}
