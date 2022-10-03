using System;
using System.Collections.Generic;
using Enums;
using Helpers;
using Interfaces;
using UnityEngine;

namespace Core
{
    public class PlanetarySystem : IPlanetarySystem
    {
        public IEnumerable<IPlanetaryObject> PlanetaryObjects { get; set; }
        
        private IList<IPlanetaryObject> _planetaryObjects;
        private const int MaxObjectMass = 5000;

        public void Update(float deltaTime)
        {
            foreach (var po in PlanetaryObjects)
            {
                po.SetPosition(new Vector3(1,0,0), deltaTime / (float)po.DistanceFromTheSun);
            }
        }

        public void Create(double systemMass, int maxPlanetaryObjects)
        {
            Debug.Log($"Creating system with mass: {systemMass}");
            
            var light = new GameObject("Sun").AddComponent<Light>();
            light.intensity = 1;
            light.type = LightType.Point;
            light.range = 200;
            
            _planetaryObjects = new List<IPlanetaryObject>();
            
            var remainingMass = systemMass;
            var random = new System.Random();

            for (int i = 0; i < maxPlanetaryObjects; i++)
            {
                double objectMass;

                if (i == maxPlanetaryObjects - 1)
                {
                    objectMass = remainingMass;
                }
                else
                {
                    objectMass = remainingMass > MaxObjectMass
                        ? Mathematics.NextDoubleLinear(random, 0, MaxObjectMass)
                        : Mathematics.NextDoubleLinear(random, 0, remainingMass);

                    remainingMass -= objectMass;
                }

                _planetaryObjects.Add(CreatePlanetaryObject(objectMass));
            }

            PlanetaryObjects = new List<IPlanetaryObject>(_planetaryObjects);
        }

        private IPlanetaryObject CreatePlanetaryObject(double mass)
        {
            MassClassEnum massClass;
            var random = new System.Random();
            double radius;
            Color color;

            switch (mass)
            {
                case >= 0 and < .00001d:
                    massClass = MassClassEnum.Asteroidan;
                    radius = Mathematics.NextDoubleLinear(random, 0, .003f);
                    color = Color.gray;
                    break;
                case >= .00001d and < .1d:
                    massClass = MassClassEnum.Mercurian;
                    radius = Mathematics.NextDoubleLinear(random, .003f, .7f);
                    color = Color.black;
                    break;
                case >= .1d and < .5d:
                    massClass = MassClassEnum.Subterran;
                    radius = Mathematics.NextDoubleLinear(random, .5f, 1.2f);
                    color = Color.cyan;
                    break;
                case >= .5d and < 2:
                    massClass = MassClassEnum.Terran;
                    radius = Mathematics.NextDoubleLinear(random, .8f, 1.9f);
                    color = Color.green;
                    break;
                case >= 2 and < 10:
                    massClass = MassClassEnum.Superterran;
                    radius = Mathematics.NextDoubleLinear(random, 1.3f, 3.3f);
                    color = Color.yellow;
                    break;
                case >= 10 and < 50:
                    massClass = MassClassEnum.Neptunian;
                    radius = Mathematics.NextDoubleLinear(random, 2.1f, 5.7f);
                    color = Color.blue;
                    break;
                case >= 50 and < 5000:
                    massClass = MassClassEnum.Jovian;
                    radius = Mathematics.NextDoubleLinear(random, 3.5f, 27);
                    color = Color.red;
                    break;
                default:
                    return null;
            }
            
            var go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            go.transform.localScale = new Vector3((float)radius,(float)radius,(float)radius);
            var distanceFromTheSun = 10 * (_planetaryObjects.Count + 1);
            go.transform.localPosition = new Vector3(distanceFromTheSun, 0, 0);
            go.GetComponent<MeshRenderer>().material.color = color;
            var planetaryObject = go.AddComponent<PlanetaryObject>();
            planetaryObject.Init(massClass, mass, distanceFromTheSun);
            
            return planetaryObject;
        }
    }
}
