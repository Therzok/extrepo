namespace System;

public static partial class FastExtensions
{
    public static int IndexOf<T>(this Span<T> span, T value, int startIndex) where T : IEquatable<T>
    {
        return IndexOf((ReadOnlySpan<T>)span, value, startIndex);
    }

    public static int IndexOfAny<T>(this Span<T> span, ReadOnlySpan<T> values, int startIndex) where T : IEquatable<T>
    {
        return IndexOfAny((ReadOnlySpan<T>)span, values, startIndex);
    }

    public static int LastIndexOf<T>(this Span<T> span, T value, int startIndex) where T : IEquatable<T>
    {
        return LastIndexOf((ReadOnlySpan<T>)span, value, startIndex);
    }

    public static int LastIndexOfAny<T>(this Span<T> span, ReadOnlySpan<T> values, int startIndex) where T : IEquatable<T>
    {
        return LastIndexOfAny((ReadOnlySpan<T>)span, values, startIndex);
    }
}

