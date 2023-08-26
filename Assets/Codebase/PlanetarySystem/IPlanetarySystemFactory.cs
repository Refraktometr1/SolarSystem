using UnityEngine;

namespace Codebase
{
    public interface IPlanetarySystemFactory
    {
        public IPlanetarySystem Create(double mass, Vector3 systemPosition);
    }
}