using UnityEngine;
using Zenject;

namespace Codebase
{
    public class PlanetSystemCreator : MonoBehaviour
    {
        [SerializeField] private double _planetarySystemMass;
        [SerializeField] private Vector3 _systemPosition;
        
        private IPlanetarySystemFactory _planetarySystemFactory;
        private IPlanetarySystem _planetarySystem;

        [Inject]
        public void Construct(IPlanetarySystemFactory planetarySystemFactory)
        {
            _planetarySystemFactory = planetarySystemFactory;
        }

        private void Start()
        {
            _planetarySystem = _planetarySystemFactory.Create(_planetarySystemMass, _systemPosition);
        }

        private void Update()
        {
            _planetarySystem.Update(Time.deltaTime);
        }
    }
}