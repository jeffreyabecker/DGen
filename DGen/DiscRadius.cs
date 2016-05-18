using System;
using System.Collections.Generic;
using System.Linq;

namespace DGen
{
    public class DiscRadius : DgPhase
    {


        public override string PhaseType { get { return "Radius"; } }

        public override void Apply(Disc disc, Verse verse)
        {
            var inclination = Math.Abs(disc.Position.Inclination);
            var worldSizer = FindWorldSizer(inclination, verse);
            disc.Radius = verse.Rng.NextDouble(worldSizer.MinRadius, worldSizer.MaxRadius);
            disc.Radius = Math.Ceiling(disc.Radius);
        }

        private IPickWorldSize FindWorldSizer(double inclination, Verse verse)
        {
            int index = verse.Rng.Next(1, 100);
            var sizer = _worldSizes.FirstOrDefault(s => s.Chance.Contains(index));
            return sizer.Create(inclination, verse);

        }



        private IEnumerable<WorldSizer> _worldSizes = new WorldSizer[]
        {
            new WorldSizer(001,020,   200,    800), 
            new WorldSizer(021,050,   1500,   10000), 
            new WorldSizer(051,080,   12000,  22500), 
            new WorldSizer(081,090,   25000,  90000), 
            new WorldSizer(091,099,   100000, 175000), 
            new WorldSizer(100,100,   200000, 200000), 
        };



        private class PickWorldSize : IPickWorldSize
        {
            //Based on the inclination, no disc can be smaller than 55% of the min and more than 100% of the max
            //max size worlds are [30,60] degrees, min size worlds are below 10 degrees and above 80 degrees
            protected double ScaleFactor(double inclination) => Math.Max(Math.Min(((45.0 - Math.Abs(45.0 - inclination)) / 45.0) + .35, 1.0), .55);
            public Verse Verse { get; set; }
            public double Inclination { get; set; }

            double IPickWorldSize.MinRadius
            {
                get { return ScaleFactor(Inclination)*MinRadius; }
            }

            double IPickWorldSize.MaxRadius
            {
                get { return ScaleFactor(Inclination) * MaxRadius; }
            }
            public double MinRadius { get;  set; }
            public double MaxRadius { get; set; }
        }

        private interface IPickWorldSize
        {
            double MinRadius { get; }
            double MaxRadius { get; }
        }

        private class WorldSizer
        {
            public Range<int> Chance { get; protected set; }

            public Func<double, Verse, IPickWorldSize> Create { get; protected set; }
            public WorldSizer(int low, int high, double minRadius, double maxRadius)
            {
                Chance = new Range<int>(low, high);
                Create = (i, v) => new PickWorldSize
                {
                    Inclination = i,
                    Verse = v,
                    MinRadius = minRadius,
                    MaxRadius = maxRadius
                };
            }
        }


    }
}