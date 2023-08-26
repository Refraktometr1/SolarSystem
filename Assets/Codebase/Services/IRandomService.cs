namespace Codebase.Services
{
    public interface IRandomService
    {
        double GetRandomDouble(double min, double max);
        int GetRandomInt(int min, int max);
    }
}