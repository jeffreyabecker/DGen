using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGen
{
    /* methodology:


         */


    public class DiscGenerator
    {
        // build a collection of DGPhases
        // apply biases from existing collection when
        // picking next DGPhase


        public bool TooCloseToAnotherDisc(Disc disc, Verse verse)
        {
            //TODO: Check the 'Verse to make sure we're not overlapping
            Disc that = verse.FindNearestDisc(disc);
            if (that == null) return false;
            var minDistance =
                _minimumDistances.FirstOrDefault(d => d.InclinationRange.Contains(disc.Position.Inclination));
            if (minDistance == null) return true; // this isnt a valid place for a disc;
            var distance = disc.Position.Distance(that.Position);
            return distance < minDistance.MinimumDistance(Math.Max(disc.Radius, that.Radius));
        }

        private class MinDistance
        {
            public Range<double> InclinationRange { get; set; }
            public Func<double, double> MinimumDistance { get; set; }
        }

        private static readonly IEnumerable<MinDistance> _minimumDistances = new List<MinDistance>
        {
            new MinDistance
            {
                InclinationRange = new Range<double>(5.0, 20.0),
                MinimumDistance = (otherRadius) => Math.Max((otherRadius*1.5), otherRadius + DiscRadius.MinimumDiscRadius)
            },
            new MinDistance
            {
                InclinationRange = new Range<double>(20,70.0),
                MinimumDistance=(otherRadius)=> Math.Max((otherRadius * .85) , otherRadius+ DiscRadius.MinimumDiscRadius)
            },
            new MinDistance
            {
                InclinationRange = new Range<double>(7.0, 85.0),
                MinimumDistance = (otherRadius) => Math.Max((otherRadius*1.8), otherRadius +DiscRadius. MinimumDiscRadius*2)
            },
            new MinDistance
            {
                InclinationRange = new Range<double>(-5.0, -20.0),
                MinimumDistance = (otherRadius) => Math.Max((otherRadius*1.5), otherRadius + DiscRadius.MinimumDiscRadius)
            },
            new MinDistance
            {
                InclinationRange = new Range<double>(-20,-70.0),
                MinimumDistance=(otherRadius)=> Math.Max((otherRadius * .85) , otherRadius+ DiscRadius.MinimumDiscRadius)
            },
            new MinDistance
            {
                InclinationRange = new Range<double>(-7.0, -85.0),
                MinimumDistance = (otherRadius) => Math.Max((otherRadius*1.8), otherRadius + DiscRadius.MinimumDiscRadius*2)
            },
        };
    }
}
