using System.Collections.Generic;

namespace DGen.Sizing
{
    public class WorldSizerFactory
    {
        //TODO Make this sensitive to the relative sizes of the worlds
        public IEnumerable<WorldSizer> GetSizers(DiscPosition position, Verse verse)
        {
            //double azimuthRange, inclinationRange, radiusRange;
            //IEnumerable<Disc> nearby = verse.GetNearbyWorlds(position, azimuthRange, inclinationRange, radiusRange);
            return _worldSizes;
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
    }
}