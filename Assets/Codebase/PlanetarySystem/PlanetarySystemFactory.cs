using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

using UnityEngine;

namespace Codebase
{
    public class PlanetarySystemFactory : IPlanetarySystemFactory
    {
        private readonly IPlanetaryObjectCreator _planetaryObjectCreator;

        [Inject]
        public PlanetarySystemFactory(IPlanetaryObjectCreator planetaryObjectCreator)
        {
            _planetaryObjectCreator = planetaryObjectCreator;
        }

        public IPlanetarySystem Create(double mass, Vector3 systemPosition)
        {
            var planetarySystem = new PlanetarySystem();
            List<IPlanetaryObject> randomPlanetaryObjects = new List<IPlanetaryObject>();
            GameObject parentGameObject = new GameObject("PlanetaryObjectsSystem");
            parentGameObject.transform.position = systemPosition;
            
            while (mass > 0)
            {
                var planetaryObject = _planetaryObjectCreator.CreateRandomPlanetaryObject(randomPlanetaryObjects.Count() + 1, mass, parentGameObject);
                planetaryObject.GameObjectTransform.SetParent(parentGameObject.transform);
                randomPlanetaryObjects.Add(planetaryObject);
                mass -= planetaryObject.Mass;
            }
            
            planetarySystem.PlanetaryObjects = randomPlanetaryObjects;
            return planetarySystem;
        }
    }
}