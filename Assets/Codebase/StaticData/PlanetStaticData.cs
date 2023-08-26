using UnityEngine;

namespace Codebase.StaticData
{
    [CreateAssetMenu(fileName = "PlanetData", menuName = "Static Data/Planet")]
    public class PlanetStaticData : ScriptableObject
    {
        public MassClass MassClassID;

        public double MaxMass;
        public double MinMass;

        public double MaxRadius;
        public double MinRadius;
        
        public GameObject Prefab;
        
        [Range(0.1f, 1.5f)]
        public float PrefabRadius;

        public Material Material;
    }
}