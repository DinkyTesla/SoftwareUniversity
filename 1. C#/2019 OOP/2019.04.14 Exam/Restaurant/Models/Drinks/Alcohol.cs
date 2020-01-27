
namespace SoftUniRestaurant.Models.Drinks
{
   public class Alcohol : Drink
    {
        private const decimal FuzzyDrinkPrice = 3.5m;

        public Alcohol(string name, int servingSize, string brand) 
            : base(name, servingSize, FuzzyDrinkPrice, brand)
        {
        }
    }
}
