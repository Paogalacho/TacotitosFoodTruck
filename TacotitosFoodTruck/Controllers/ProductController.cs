using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacotitosFoodTruck.DAO;
using TacotitosFoodTruck.Model;

namespace TacotitosFoodTruck.Controllers
{

    public class ProductController
    {
        private readonly IngredientDao ingredientDao;
        private readonly TortillaDao tortillaDao;
        private readonly SauceDao sauceDao;

        public ProductController()
        {
            ingredientDao = new IngredientDao();
            tortillaDao = new TortillaDao();
            sauceDao = new SauceDao();  

        }

        #region Ingredients
        public List<Ingredient> GetAllIngredients() => ingredientDao.GetAllIngredients();

        public void AddIngredient(string name, decimal price)
        {
            var ingredient = new Ingredient { Name = name, Price = price };
            ingredientDao.AddIngredient(ingredient);
        }

        public void AddIngredient(Ingredient ingredient)
        {
            try
            {
                ingredientDao.AddIngredient(ingredient);
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating ingredients: " + ex.Message, ex);
            }
        }

        public void UpdateIngredient(Ingredient ingredient) 
        {
            try
            {
                ingredientDao.UpdateIngredient(ingredient);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating ingredients: " + ex.Message, ex);
            }
        }

        public void DeleteIngredient(int ingredientId)
        {
            try
            {
                ingredientDao.DeleteIngredient(ingredientId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting ingredients: " + ex.Message, ex);
            }
        }

        #endregion

        #region Tortillas
        public List<Tortilla> GetAllTortillas()
        {
            try
            {
                return tortillaDao.GetAllTortillas();
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching tortillas: " + ex.Message, ex);
            }
        }

        public void addTortilla(Tortilla tortilla)
        {
            try
            {
                tortillaDao.AddTortilla(tortilla);
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating tortillas: " + ex.Message, ex);
            }
        }

        public void UpdateTortilla(Tortilla tortilla)
        {
            try
            {
                tortillaDao.UpdateTortilla(tortilla);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating tortillas: " + ex.Message, ex);
            }
        }

        public void DeleteTortilla(int tortillaId)
        {
            try
            {
                tortillaDao.DeleteTortilla(tortillaId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting tortillas: " + ex.Message, ex);
            }
        }
        #endregion

        #region Sauces
        public List<Sauce> GetAllSauces()
        {
            try
            {
                return sauceDao.GetAllSauces();
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching sauces: " + ex.Message, ex);
            }
        }


        public void addSauce(Sauce sauce)
        {
            try
            {
                sauceDao.AddSauce(sauce);
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating sauces: " + ex.Message, ex);
            }
        }

        public void UpdateSauce(Sauce sauce)
        {
            try
            {
                sauceDao.UpdateSauce(sauce);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating sauces: " + ex.Message, ex);
            }
        }

        public void DeleteSauce(int sauceId)
        {
            try
            {
                sauceDao.DeleteSauce(sauceId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting sauces: " + ex.Message, ex);
            }
        }
        #endregion








    }

}
