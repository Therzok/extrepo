namespace System.Linq;

// 100% productivity win with Arrays, and also perf boost, but not sure how useful with net6 and specialized codegen.   
public static partial class FastExtensions
{
    // source generator for LINQ extensions on concrete types to avoid box
    // i.e. Array, List

    // Simple extension methods for array, immutablearray, spans

    public static bool Contains<T>(this T[] array, T value)
    {
        return Array.IndexOf(array, value) != -1;
    }

    public static T First<T>(this T[] array)
    {
        return array[0];
    }

    public static T? FirstOrDefault<T>(this T[] array)
    {
        return array.Length > 0 ? array[0] : default;
    }

    public static bool Any<T>(this T[] array)
    {
        return array.Length > 0;
    }

    public static int IndexOf<T>(this T[] array, T value)
    {
        return Array.IndexOf(array, value);
    }

    public static int IndexOf<T>(this T[] array, T value, int startIndex)
    {
        return Array.IndexOf(array, value, startIndex);
    }

    public static int IndexOf<T>(this T[] array, T value, int startIndex, int count)
    {
        return Array.IndexOf(array, value, startIndex, count);
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

