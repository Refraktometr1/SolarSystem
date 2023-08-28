using UnityEngine;
using Zenject;

namespace Codebase
{
    public class PlanetSystemCreator : MonoBehaviour
    {
        [SerializeField] private double _planetarySystemMass = 10;
        [SerializeField] private Vector3 _systemPosition = Vector3.zero;
        [SerializeField] private int RotationSpeed =1 ;
        
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
            _planetarySystem.Update(Time.deltaTime * RotationSpeed);
        }
    }
}