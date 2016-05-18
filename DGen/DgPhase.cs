namespace DGen
{
    public abstract class DgPhase
    {
        // represents a single component phase
        // of building a world.
        // can apply biases towards later phases
        public abstract string PhaseType { get; }
        public abstract void Apply(Disc disc, Verse verse);
    }
}