
namespace SoftUniRestaurant.Models.Drinks
{
    public class Water : Drink
    {
        private const decimal FuzzyDrinkPrice = 1.5m;

        public Water(string name, int servingSize, string brand) 
            : base(name, servingSize, FuzzyDrinkPrice, brand)
        {
        }
    }
}
