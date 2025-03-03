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
       
        public List<Ingredient> GetAllIngredients()
        {
            try
            {
                return ingredientDao.GetAllIngredients();
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching tortillas: " + ex.Message, ex);
            }
        }


        public void AddIngredient(string name, decimal price)
        {
            try
            {
                var ingredient = new Ingredient { Name = name, Price = price };
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

        public void AddTortilla(string name, decimal price)
        {
            try
            {
                var tortilla = new Tortilla { Name = name, Price = price };
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


        public void AddSauce(string name, decimal price)
        {
            try
            {
                var sauce = new Sauce { Name = name, Price = price };
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
