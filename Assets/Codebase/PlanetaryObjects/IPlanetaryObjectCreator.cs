using UnityEngine;

namespace Codebase
{
    public interface IPlanetaryObjectCreator
    {
        public IPlanetaryObject CreateRandomPlanetaryObject(int orbitCount, double availableMass,
            GameObject systemCenter);
    }
}