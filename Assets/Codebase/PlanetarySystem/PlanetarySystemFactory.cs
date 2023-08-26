using System.Collections.Generic;
using System.Linq;
using Codebase.StaticData;
using UnityEngine;
using Zenject;

namespace Codebase
{
    public class PlanetarySystemFactory : IPlanetarySystemFactory
    {
        private IPlanetaryObjectCreator _planetaryObjectCreator;
        
        [Inject]
        public void Construct(IStaticDataService staticDataService, IPlanetaryObjectCreator planetaryObjectCreator)
        {
            _planetaryObjectCreator = planetaryObjectCreator;
        }

        public IPlanetarySystem Create(double mass, Vector3 systemPosition)
        {
            var planetarySystem = new PlanetarySystem();
            List<IPlanetaryObject> randomPlanetaryObjects = new List<IPlanetaryObject>();
            
            while (mass > 0)
            {
                var planetaryObject = _planetaryObjectCreator.CreateRandomPlanetaryObject(randomPlanetaryObjects.Count() + 1, mass, systemPosition);
                randomPlanetaryObjects.Add(planetaryObject);
                mass -= planetaryObject.Mass;
            }
            
            planetarySystem.PlanetaryObjects = randomPlanetaryObjects;
            return planetarySystem;
        }
    }
}