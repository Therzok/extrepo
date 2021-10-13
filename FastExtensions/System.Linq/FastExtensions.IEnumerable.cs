using System;
using System.Collections.Generic;

namespace System.Linq
{
    public static partial class FastExtensions
    {
        public static IEnumerable<T> Concat<T>(this IEnumerable<T> source, T item)
        {
            var toAdd = Enumerable.Repeat(item, 1);

            return source.Concat(toAdd);
        }

        public static IEnumerable<T> FastConcat<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            return second == Enumerable.Empty<T>() ? first : first.Concat(second);
        }

        public static int FindIndex<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            int i = 0;
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    return i;
                }
                i++;
            }
            return -1;
        }

        public static int FindIndex<T, TState>(this IEnumerable<T> source, TState state, Func<T, TState, bool> predicate)
        {
            int i = 0;
            foreach (var item in source)
            {
                if (predicate(item, state))
                {
                    return i;
                }
                i++;
            }
            return -1;
        }

        public static int FindIndex<T>(this IEnumerable<T> source, Func<T, bool> predicate, int start)
        {
            int index = source.Skip(start).FindIndex(predicate);

            return index == -1 ? -1 : index + start;
        }

        public static int FindIndex<T, TState>(this IEnumerable<T> source, TState state, Func<T, TState, bool> predicate, int start)
        {
            int index = source.Skip(start).FindIndex(state, predicate);

            return index == -1 ? -1 : index + start;
        }

        static TSource MaxValue<TSource, TCompare>(this IEnumerable<TSource> source, Func<TSource, TCompare> compareSelector, IComparer<TCompare> comparer, out bool hasValue)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            TSource result = default!;
            TCompare value = default!;
            hasValue = false;
            foreach (TSource item in source)
            {
                var x = compareSelector(item);
                if (hasValue)
                {
                    if (comparer.Compare(x, value!) > 0)
                    {
                        value = x;
                        result = item;
                    }
                }
                else
                {
                    value = x;
                    result = item;
                    hasValue = true;
                }
            }
            return result;
        }

        public static TSource MaxValue<TSource, TCompare>(this IEnumerable<TSource> source, Func<TSource, TCompare> compareSelector) where TCompare : IComparable<TCompare>
        {
            TSource result = MaxValue(source, compareSelector, Comparer<TCompare>.Default, out bool hasValue);
            if (hasValue)
                return result;
            throw new InvalidOperationException(string.Format("{0} contains no elements", nameof(source)));
        }

        public static TSource MaxValueOrDefault<TSource, TCompare>(this IEnumerable<TSource> source, Func<TSource, TCompare> compareSelector) where TCompare : IComparable<TCompare>
        {
            return MaxValue(source, compareSelector, Comparer<TCompare>.Default, out _);
        }

        public static TSource MaxValue<TSource, TCompare>(this IEnumerable<TSource> source, Func<TSource, TCompare> compareSelector, IComparer<TCompare> comparer)
        {
            TSource result = MaxValue(source, compareSelector, comparer, out bool hasValue);
            if (hasValue)
                return result;
            throw new InvalidOperationException(string.Format("{0} contains no elements", nameof(source)));
        }

        public static TSource MaxValueOrDefault<TSource, TCompare>(this IEnumerable<TSource> source, Func<TSource, TCompare> compareSelector, IComparer<TCompare> comparer)
        {
            return MaxValue(source, compareSelector, comparer, out _);
        }

        static TSource MinValue<TSource, TCompare>(this IEnumerable<TSource> source, Func<TSource, TCompare> compareSelector, IComparer<TCompare> comparer, out bool hasValue)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            TSource result = default!;
            TCompare value = default!;
            hasValue = false;
            foreach (TSource item in source)
            {
                var x = compareSelector(item);
                if (hasValue)
                {
                    if (comparer.Compare(x, value) < 0)
                    {
                        value = x;
                        result = item;
                    }
                }
                else
                {
                    value = x;
                    result = item;
                    hasValue = true;
                }
            }
            return result;
        }

        public static TSource MinValue<TSource, TCompare>(this IEnumerable<TSource> source, Func<TSource, TCompare> compareSelector) where TCompare : IComparable<TCompare>
        {
            TSource result = MinValue(source, compareSelector, Comparer<TCompare>.Default, out bool hasValue);
            if (hasValue)
                return result;
            throw new InvalidOperationException(string.Format("{0} contains no elements", nameof(source)));
        }

        public static TSource MinValueOrDefault<TSource, TCompare>(this IEnumerable<TSource> source, Func<TSource, TCompare> compareSelector) where TCompare : IComparable<TCompare>
        {
            return MinValue(source, compareSelector, Comparer<TCompare>.Default, out _);
        }

        public static TSource MinValue<TSource, TCompare>(this IEnumerable<TSource> source, Func<TSource, TCompare> compareSelector, IComparer<TCompare> comparer)
        {
            TSource result = MinValue(source, compareSelector, comparer, out bool hasValue);

            if (hasValue)
                return result;
            throw new InvalidOperationException(string.Format("{0} contains no elements", nameof(source)));
        }

        public static TSource MinValueOrDefault<TSource, TCompare>(this IEnumerable<TSource> source, Func<TSource, TCompare> compareSelector, IComparer<TCompare> comparer)
        {
            return MinValue(source, compareSelector, comparer, out _);
        }
    }
}

