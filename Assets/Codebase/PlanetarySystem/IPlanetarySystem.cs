using System.Collections.Generic;

namespace Codebase
{
    public interface IPlanetarySystem
    {
        IEnumerable<IPlanetaryObject> PlanetaryObjects { get; set; }
        public void Update(float deltaTime);
    }
}