namespace DGen
{
    public class Disc
    {
        public DiscPosition Position { get; set; }
        public double Radius { get; set; }
        public Culture Culture { get; set; }
        public Politics Politics { get; set; }
        public Sophistication Sophistication { get; set; }
        public double Distance(Disc that)
        {
        }
    }
}