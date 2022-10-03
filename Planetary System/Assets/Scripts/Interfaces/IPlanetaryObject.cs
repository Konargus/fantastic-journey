using Enums;
using UnityEngine;

namespace Interfaces
{
    public interface IPlanetaryObject
    {
        MassClassEnum MassClass { get; }
        double Mass { get; }
        double DistanceFromTheSun { get; }
        void SetPosition(Vector3 pos, float deltaTime);
    }
}
