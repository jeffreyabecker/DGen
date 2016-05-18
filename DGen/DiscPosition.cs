using System;

namespace DGen
{
    public class DiscPosition
    {
        public double Azimuth { get; set; } // Theta
        public double Inclination { get; set; } // Phi
        public double Radius { get; set; } // r

        /// <summary>
        /// 
        /// </summary>
        /// <param name="that"></param>
        /// <returns></returns>
        public double Distance(DiscPosition that)
        {
            //http://math.stackexchange.com/questions/1078231/distance-between-2-points-in-3d-space-in-spherical-polar-coordinates
            return Math.Sqrt(
                this.Radius * this.Radius
                +
                that.Radius * that.Radius
                +
                2* this.Radius *that.Radius
                *
                (Math.Cos(this.Azimuth)*Math.Cos(that.Azimuth)*Math.Cos(this.Inclination - that.Inclination) +
                 Math.Sin(this.Azimuth)*Math.Sin(that.Azimuth))
                );
        }

        bool IsInside(BoundingBox box)
        {
            return box.Azimuth.Contains(Azimuth)
                   && box.Radius.Contains(Radius)
                   && box.Inclination.Contains(Inclination);
        }
    }
}