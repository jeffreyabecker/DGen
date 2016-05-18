using System;

namespace DGen
{
    public struct Range<T> where T:struct, IComparable<T>
    {
        public Range(T min, T max)
        {
            Min = min;
            Max = max;
        }
        public T Min { get; private set; }
        public T Max { get; private set; }

        public bool Contains(T that)
        {
            return this.Min.CompareTo(that) < 0 && that.CompareTo(this.Max) <= 0;
        }
    }
}