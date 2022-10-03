using Enums;
using Interfaces;
using UnityEngine;

namespace Core
{
    public class PlanetaryObject : MonoBehaviour, IPlanetaryObject
    {
        public MassClassEnum MassClass { get; private set; }
        public double Mass { get; private set; }
        
        public double DistanceFromTheSun { get; private set; }

        public void Init(MassClassEnum massClassEnum, double mass, double distanceFromTheSun)
        {
            MassClass = massClassEnum;
            Mass = mass;
            DistanceFromTheSun = distanceFromTheSun;
        }

        public void SetPosition(Vector3 pos, float deltaTime)
        {
            transform.RotateAround(pos, Vector3.up, deltaTime);
        }
    }
}
