using Codebase.Services;
using Codebase.StaticData;
using Zenject;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Codebase
{
    public class PlanetaryObjectCreator : IPlanetaryObjectCreator
    {
        private IStaticDataService _staticDataService;
        private IRandomService _randomService;

        [Inject]
        public PlanetaryObjectCreator(IStaticDataService staticDataService, IRandomService randomService)
        {
            _staticDataService = staticDataService;
            _randomService = randomService;
        }
        
        public IPlanetaryObject CreateRandomPlanetaryObject(int orbitCount, double availableMass,
            GameObject systemCenter)
        {
            var planetaryObjectClass = _staticDataService.GetRandomMassClass();
            var staticData = _staticDataService.GetPlanetaryObjectStaticData(planetaryObjectClass);
            var planetaryObjectMass = _randomService.GetRandomDouble(staticData.MinMass, staticData.MaxMass);

            if (availableMass - planetaryObjectMass <= 0)
            {
                if (orbitCount == 1) 
                    availableMass *= 0.4;

                planetaryObjectClass = _staticDataService.GetMassClassByMass(availableMass);
                staticData = _staticDataService.GetPlanetaryObjectStaticData(planetaryObjectClass);
                planetaryObjectMass = availableMass;
            }

            var planetRadius = _randomService.GetRandomDouble(staticData.MinRadius, staticData.MaxRadius);
            
            var planetGameObject =  Object.Instantiate(staticData.Prefab,  systemCenter.transform.position + Vector3.right * orbitCount, Quaternion.identity, systemCenter.transform);
            planetGameObject.transform.localScale = Vector3.one * staticData.PrefabRadius;
            planetGameObject.GetComponent<Renderer>().material = staticData.Material;

            var planetaryObject = new PlanetaryObject(planetaryObjectMass, planetRadius, planetaryObjectClass,
                planetGameObject.transform, systemCenter.transform);
            
            return planetaryObject;
        }
    }
}