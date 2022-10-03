using Interfaces;
using UnityEngine;

namespace Core
{
    public class Main : MonoBehaviour
    {
        private IPlanetarySystem _system;

        private void Start()
        {
            var factory = new PlanetarySystemFactory();
            _system = factory.Create(99);
        }

        private void Update()
        {
            _system.Update(1);
        }
    }
}