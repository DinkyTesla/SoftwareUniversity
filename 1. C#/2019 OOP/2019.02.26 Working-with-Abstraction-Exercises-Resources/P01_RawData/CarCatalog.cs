
namespace P01_RawData
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CarCatalog
    {
        private List<Car> cars;

        public CarCatalog()
        {
            this.cars = new List<Car>();
        }

        public void Add(string[] paramaeters)
        {
            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carParameters = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string model = carParameters[0];

                int engineSpeed = int.Parse(carParameters[1]);
                int enginePower = int.Parse(carParameters[2]);
                int cargoWeight = int.Parse(carParameters[3]);
                string cargoType = carParameters[4];

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                Tire[] tires = new Tire[4];

                int tireIndex = 0;

                for (int j = 5; j < 12; j++)
                {
                    double tirePressure = double.Parse(carParameters[j]);
                    int tireAge = int.Parse(carParameters[j]);

                    Tire tire = new Tire(tirePressure, tireAge);

                    tires[tireIndex] = tire;
                    tireIndex++;
                }

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

        }
        public List<>   ;
    }
}
