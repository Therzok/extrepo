using System;

namespace System.Linq
{
    public static partial class FastExtensions
    {
        // source generator for LINQ extensions on concrete types to avoid box
        // i.e. Array, List

        // Simple extension methods for array, immutablearray, spans

        public static bool Contains<T>(this T[] array, T value)
        {
            return Array.IndexOf(array, value) != -1;
        }

        public static T[] RemoveAt<T>(this T[] array, int index)
        {
            ReadOnlySpan<T> span = array;

            var left = span.Slice(0, index);
            var right = span.Slice(index + 1);

            return left.Combine(right);
        }

        public static T[] RemoveAt<T>(this T[] array, int start, int length)
        {
            ReadOnlySpan<T> span = array;

            var left = span.Slice(0, start);
            var right = span.Slice(start + length + 1);

            return left.Combine(right);
        }
    }
}

