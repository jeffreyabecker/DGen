using System;
using System.Collections.Generic;
using System.Linq;

namespace DGen.Sizing
{
    public class DiscRadius : DgPhase
    {
        private static readonly WorldSizerFactory _sizerFactory = new WorldSizerFactory();

        public override string PhaseType { get { return "Radius"; } }

        public override void Apply(Disc disc, Verse verse)
        {
            var inclination = Math.Abs(disc.Position.Inclination);
            var worldSizer = FindWorldSizer(disc.Position, verse);
            disc.Radius = verse.Rng.NextDouble(worldSizer.MinRadius, worldSizer.MaxRadius);
            disc.Radius = Math.Ceiling(disc.Radius);
        }

        private ICanHazRadiusRange FindWorldSizer(DiscPosition postion, Verse verse)
        {
            int index = verse.Rng.Next(1, 100);
            var sizer = _sizerFactory.GetSizers(postion, verse).FirstOrDefault(s => s.Chance.Contains(index));
            return sizer.Create(inclination, verse);

        }



        

    }
}