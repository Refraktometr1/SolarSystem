using System.Collections.Generic;

namespace Codebase
{
    public class PlanetarySystem : IPlanetarySystem
    {
        private List<IPlanetaryObject> _planetaryObjects = new List<IPlanetaryObject>();

        public IEnumerable<IPlanetaryObject> PlanetaryObjects
        {
            get => _planetaryObjects;
            set => _planetaryObjects.AddRange(value);
        }

        public void Update(float deltaTime)
        {
            foreach (var planet in PlanetaryObjects)
            {
                planet.Rotate(deltaTime);
            }
        }
    }
}