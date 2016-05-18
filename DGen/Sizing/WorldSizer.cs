using System;

namespace DGen.Sizing
{
    public class WorldSizer
    {
        public Range<int> Chance { get; protected set; }

        public Func<double, Verse, ICanHazRadiusRange> Create { get; protected set; }
        public WorldSizer(int low, int high, double minRadius, double maxRadius)
        {
            Chance = new Range<int>(low, high);
            Create = (i, v) => new CanHazRadiusRange
            {
                Inclination = i,
                Verse = v,
                MinRadius = minRadius,
                MaxRadius = maxRadius
            };
        }
    }
}