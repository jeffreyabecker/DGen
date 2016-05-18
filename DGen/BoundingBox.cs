namespace DGen
{
    public class BoundingBox
    {
        public Range<double> Azimuth { get; set; } // Theta
        public Range<double> Inclination { get; set; } // Phi
        public Range<double> Radius { get; set; } // r

        public bool Contains(DiscPosition position)
        {
            return Azimuth.Contains(position.Azimuth)
                   && Inclination.Contains(position.Inclination)
                   && Radius.Contains(position.Radius);
        }
    }
}