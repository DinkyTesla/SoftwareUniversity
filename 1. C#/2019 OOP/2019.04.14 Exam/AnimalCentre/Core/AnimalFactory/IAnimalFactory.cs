using AnimalCentre.Models.Contracts;
using System;

namespace AnimalCentre.Core.AnimalFactory
{
    public interface IAnimalFactory
    {
        IAnimal CreateAnimal(string type, string name, int energy, int happiness, int procedureTime);
    }
}
