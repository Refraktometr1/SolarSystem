using Codebase;

public interface IPlanetaryObject
{
    public double Mass { get; set; }
    MassClass MassClass{ get; }

    public void Rotate(float time);
}