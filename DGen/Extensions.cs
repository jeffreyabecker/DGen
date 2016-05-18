using System;

namespace DGen
{
    public static class Extensions
    {
        public static double NextDouble(this Random rng, double minimum, double maximum)
        {
            return rng.NextDouble()*((maximum - minimum) + minimum);
        }
    }
}