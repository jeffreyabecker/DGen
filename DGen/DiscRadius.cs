using System;
using System.Collections.Generic;
using System.Linq;

namespace DGen
{
    public class DiscRadius : DgPhase
    {
        public const double MinimumDiscRadius = 200.00;
        public const double MaximumDiscRadius = 200000.00;

        public override string PhaseType { get { return "Radius"; } }

        public override void Apply(Disc disc, Verse verse)
        {
            var inc = Math.Abs(disc.Position.Inclination);
            disc.Radius = verse.Rng.NextDouble(MinimumDiscRadius * MinScaleFactor(inc), MaximumDiscRadius*MaxScaleFactor(inc));
            disc.Radius = Math.Ceiling(disc.Radius);
        }

        private double MinScaleFactor(double inc)
        {
            return ((45.0 - Math.Abs(45.0 - inc)) / 45.0) * .25 + 1.0;
        }

        private double MaxScaleFactor(double inc)
        {
            return ((45.0 - Math.Abs(45.0 - inc))/45.0);
        }

  

    }70000/53
}