using System.Collections.Generic;
using Core;

namespace Interfaces
{
    public interface IPlanetarySystem
    {
        IEnumerable<IPlanetaryObject> PlanetaryObjects { get; set; }
        void Update(float deltaTime);
        void Create(double systemMass, int maxPlanetaryObjects);
    }
}
