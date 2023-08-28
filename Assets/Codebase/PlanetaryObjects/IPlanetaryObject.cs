using Codebase;
using UnityEngine;

public interface IPlanetaryObject
{
    public double Mass { get; set; }
    MassClass MassClass{ get; }
    Transform GameObjectTransform { get; set; }
    double Radius { get; }

    public void Rotate(float time);
}