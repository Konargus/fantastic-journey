namespace Interfaces
{
    public interface IPlanetarySystemFactory
    {
        IPlanetarySystem Create(double mass);
    }
}