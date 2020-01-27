using AnimalCentre.Core;
using AnimalCentre.Core.Contracts;
using System;

namespace AnimalCentre
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //TODO Run your application from here

            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
