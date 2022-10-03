using System;

namespace Helpers
{
    public static class Mathematics
    {
        public static double NextDoubleLinear(Random random, double minValue, double maxValue)
        {
            var nextDouble = random.NextDouble();
            return (maxValue * nextDouble) + (minValue * (1d - nextDouble));
        }
    }
}