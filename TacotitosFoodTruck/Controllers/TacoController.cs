using TacotitosFoodTruck.DAO;
using TacotitosFoodTruck.Model;
using System;
using System.Collections.Generic;

namespace TacotitosFoodTruck.Controllers
{
    public class TacoController
    {
        private readonly TacoDao tacoDao;

        public TacoController()
        {
            tacoDao = new TacoDao();
        }

        //Se puede cambiar el retorno a un void sino se usa el tacoId que se devuelve en algún otro lado,por ejemplo,la vista
        public int CreateTaco(Taco taco)
        {
            if (taco == null)
            {
                throw new ArgumentNullException(nameof(taco), "El taco no puede ser nulo.");
            }

            if (taco.Tortillas.Count == 0 || taco.Ingredients.Count == 0)
            {
                throw new ArgumentException("Un taco debe tener al menos una tortilla y un ingrediente.");
            }

            try
            {
                int tacoId = tacoDao.AddTaco(taco);
                return tacoId;//Se puede quitar
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
}

