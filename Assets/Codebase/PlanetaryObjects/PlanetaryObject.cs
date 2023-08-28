using Codebase;
using UnityEngine;

public class PlanetaryObject : MonoBehaviour , IPlanetaryObject
{
    [field: SerializeField] public double Mass { get; set; }
    [field: SerializeField] public double Radius { get; private set; }
    [field: SerializeField] public MassClass MassClass { get; private set; }
    
    [field: SerializeField] public Vector3 SystemCenter { get; private set; }
    
    public void Rotate(float time)
    {
        transform.RotateAround(SystemCenter,  Vector3.up, time * (1 / Vector3.SqrMagnitude(SystemCenter - transform.position)));
    }

    public void Init(double planetMass, double planetRadius, MassClass type, Vector3 systemCenter)
    {
        Mass = planetMass;
        Radius = planetRadius;
        MassClass = type;
        SystemCenter = systemCenter;
    }
}