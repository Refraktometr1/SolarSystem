using Codebase;
using UnityEngine;

public class PlanetaryObject : IPlanetaryObject
{
    public PlanetaryObject(double mass, double radius, MassClass massClass, Transform gameObjectTransform, Vector3 systemCenter)
    {
        Mass = mass;
        Radius = radius;
        MassClass = massClass;
        GameObjectTransform = gameObjectTransform;
        SystemCenter = systemCenter;
    }

    public double Mass { get; set; }
    public double Radius { get;}
    public MassClass MassClass { get;}
    
    public Transform GameObjectTransform { get; set; }
    
    public Vector3 SystemCenter { get;}
    
    public void Rotate(float time)
    {
        GameObjectTransform.RotateAround(SystemCenter,  Vector3.up, time * (1 / Vector3.SqrMagnitude(SystemCenter - GameObjectTransform.position)));
    }
}