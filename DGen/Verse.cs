using System;
using System.Collections.Generic;

namespace DGen
{
    public class Verse
    {
        public Verse()
        {
            Rng = new Random();
        }

        private List<Disc> _discs = new List<Disc>();
        public Random Rng { get; set; }

        //public IEnumerable<Disc> GetNearbyWorlds(DiscPosition position, double azimuthRange, double inclinationRange, double radiusRange)
        //{
        //    var box = new BoundingBox
        //    {
        //        Azimuth = new Range<double>(position.Azimuth -)
        //    }
        //}
    }
}