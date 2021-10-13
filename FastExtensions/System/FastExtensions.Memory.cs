using System;
namespace System
{
    public static partial class FastExtensions
    {
        public static int IndexOf<T>(this ReadOnlySpan<T> span, T value, int startIndex) where T:IEquatable<T>
        {
            var indexInSlice = span.Slice(startIndex).IndexOf(value);
            return indexInSlice == -1 ? -1 : startIndex + indexInSlice;
        }

        public static int IndexOfAny<T>(this ReadOnlySpan<T> span, ReadOnlySpan<T> values, int startIndex) where T:IEquatable<T>
        {
            var indexInSlice = span.Slice(startIndex).IndexOfAny(values);
            return indexInSlice == -1 ? -1 : startIndex + indexInSlice;
        }

        public static int LastIndexOf<T>(this ReadOnlySpan<T> span, T value, int startIndex) where T : IEquatable<T>
        {
            var indexInSlice = span.Slice(startIndex).LastIndexOf(value);
            return indexInSlice == -1 ? -1 : startIndex + indexInSlice;
        }

        public static int LastIndexOfAny<T>(this ReadOnlySpan<T> span, ReadOnlySpan<T> values, int startIndex) where T : IEquatable<T>
        {
            var indexInSlice = span.Slice(startIndex).LastIndexOfAny(values);
            return indexInSlice == -1 ? -1 : startIndex + indexInSlice;
        }

        public static T[] Combine<T>(this ReadOnlySpan<T> left, ReadOnlySpan<T> right)
        {
            var result = new T[left.Length + right.Length];

            Span<T> span = result;

            left.CopyTo(span);
            left.CopyTo(span.Slice(right.Length));

            return result;
        }

        /// <summary>
        /// Optimized overload of ToString() with takes the original value to not allocate in that case.
        /// In case two different strings with the same length are passed, the method will not work as you think.
        /// </summary>
        /// <returns>The originalValue if the lengths are the same. Otherwise a new string is allocated from span</returns>
        /// <param name="span">The span string.</param>
        /// <param name="originalValue">The original string the span is created from.</param>
        public static string ToStringWithOriginal(this ReadOnlySpan<char> span, string originalValue)
        {
            return span.Length == originalValue.Length ? originalValue : span.ToString();
        }
    }
}

