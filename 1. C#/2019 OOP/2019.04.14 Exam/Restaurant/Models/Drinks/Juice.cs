
namespace SoftUniRestaurant.Models.Drinks
{
    public class Juice : Drink
    {
        private const decimal FuzzyDrinkPrice = 1.8m;

        public Juice(string name, int servingSize, string brand) 
            : base(name, servingSize, FuzzyDrinkPrice, brand)
        {
        }
    }
}
