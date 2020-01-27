
namespace SoftUniRestaurant.Models.Drinks.Factories
{
    using SoftUniRestaurant.Models.Drinks.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    class DrinkFactory
    {
        public IDrink CreateDrink(string type, string name, int servingSize, string brand)
        {
            //Type type = Assembly.GetCallingAssembly()
            //    .GetTypes()
            //    .FirstOrDefault(t => t.Name == drinkType);

            //IDrink drink = (IDrink)Activator.CreateInstance(type, name, servingSize, brand);

            //return drink;

            // Bad idea but just in case :D
            return (IDrink)Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == type)
                .GetConstructors()
                .FirstOrDefault()
                .Invoke(new object[] { name, servingSize, brand });
        }
    }
}
