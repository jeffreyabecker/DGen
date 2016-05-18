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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="that"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public bool Contains(T that, RangeMode mode = RangeMode.IncludeBoth)
        {
            if (mode == RangeMode.IncludeBoth)
            {
                return this.Min.CompareTo(that) <= 0 && that.CompareTo(this.Max) <= 0;
            }
            if (mode == RangeMode.IncludeMin)
            {
                return this.Min.CompareTo(that) <= 0 && that.CompareTo(this.Max) < 0;
            }
            if (mode == RangeMode.IncludeMax)
            {
                return this.Min.CompareTo(that) < 0 && that.CompareTo(this.Max) <= 0;
            }
            if (mode == RangeMode.ExcludeBoth)
            {
                return this.Min.CompareTo(that) < 0 && that.CompareTo(this.Max) < 0;
            }
            throw new ArgumentException($"Bad mode {mode}", nameof(mode));

        }
    }

    public enum RangeMode
    {
        IncludeBoth,
        IncludeMin,
        IncludeMax,
        ExcludeBoth
    }
}