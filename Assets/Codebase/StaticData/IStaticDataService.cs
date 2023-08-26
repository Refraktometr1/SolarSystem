namespace Codebase.StaticData
{
    public interface IStaticDataService
    {
        PlanetStaticData GetPlanetaryObjectStaticData(MassClass massClass);
        MassClass GetRandomMassClass();
        MassClass GetMassClassByMass(double mass);
    }
}