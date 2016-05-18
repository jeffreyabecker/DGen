using System;

namespace DGen.Sizing
{
    public class CanHazRadiusRange : ICanHazRadiusRange
    {
        //Based on the inclination, no disc can be smaller than 55% of the min and more than 100% of the max
        //max size worlds are [30,60] degrees, min size worlds are below 10 degrees and above 80 degrees
        protected double ScaleFactor(double inclination) => Math.Max(Math.Min(((45.0 - Math.Abs(45.0 - inclination)) / 45.0) + .35, 1.0), .55);
        public Verse Verse { get; set; }
        public double Inclination { get; set; }

        double ICanHazRadiusRange.MinRadius
        {
            get { return ScaleFactor(Inclination) * MinRadius; }
        }

        double ICanHazRadiusRange.MaxRadius
        {
            get { return ScaleFactor(Inclination) * MaxRadius; }
        }
        public double MinRadius { get; set; }
        public double MaxRadius { get; set; }
    }
}