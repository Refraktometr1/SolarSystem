using System;

namespace Codebase.Services
{
    public class RandomService : IRandomService
    {
        private Random _random;

        public double GetRandomDouble(double min, double max)
        {
            _random = new Random();
            return _random.NextDouble() * (max - min) + min;
        }

        public int GetRandomInt(int min, int max)
        {
            _random = new Random();
            return _random.Next(min, max);
        }
    }
}