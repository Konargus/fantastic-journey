using Interfaces;

namespace Core
{
    public class PlanetarySystemFactory : IPlanetarySystemFactory
    {
        public IPlanetarySystem Create(double mass)
        {
            IPlanetarySystem planetarySystem = new PlanetarySystem();
            planetarySystem.Create(mass, 9);
            
            return planetarySystem;
        }
    }
}
