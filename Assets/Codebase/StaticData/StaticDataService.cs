using System.Collections.Generic;
using System.Linq;
using Codebase.Services;
using UnityEngine;
using Zenject;


namespace Codebase.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<MassClass, PlanetStaticData> _planetaryObjectData;
        private readonly IRandomService _random;


        [Inject]
        public StaticDataService(IRandomService random)
        {
            _random = random;
            Load();
        }

        private const string PlanetStaticDataPath = "PlanetStaticData";

        private void Load()
        {
            _planetaryObjectData = Resources.LoadAll<PlanetStaticData>(PlanetStaticDataPath)
                .ToDictionary(x => x.MassClassID, x => x);
        }

        public PlanetStaticData GetPlanetaryObjectStaticData(MassClass massClass) => 
            _planetaryObjectData.TryGetValue(massClass, out PlanetStaticData staticData) ? staticData : null;

        public MassClass GetRandomMassClass()
        {
            var typeIndex = _random.GetRandomInt(1, _planetaryObjectData.Count);
            return (MassClass)typeIndex;
        }

        public MassClass GetMassClassByMass(double mass)
        {
            foreach (var planetStaticData in _planetaryObjectData)
            {
                if ( planetStaticData.Value.MinMass < mass && planetStaticData.Value.MaxMass > mass)
                {
                    return planetStaticData.Key;
                }
            }
            Debug.LogError(" planet mass not found");
            return MassClass.Asteroidan;
        }
    }
}