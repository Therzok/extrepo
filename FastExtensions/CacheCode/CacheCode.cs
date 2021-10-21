namespace System;

/// <summary>
/// A pair of <see cref="(T, int)"/> which caches the <see cref="GetHashCode"/> result on creation.
/// Only use in case of <see langword="readonly"/> types, such as strings or collections in <see cref="Collections.Immutable" />.
/// </summary>
/// <remarks>
/// This can also be used to force a hashcode value for a given object.
/// </remarks>
/// <typeparam name="T"></typeparam>
public readonly struct CacheCode<T> : IEquatable<CacheCode<T>>, IEquatable<T> where T : IEquatable<T>
{
    readonly T _value;
    readonly int _hashCode;

    /// <summary>
    /// Creates a cached hashcode pair of <see cref="T"/> <paramref name="value"/> associated with its <see cref="int"/> <paramref name="hashCode" />.
    /// </summary>
    /// <param name="value">The underlying value </param>
    /// <param name="hashCode">The hashcode value corresponding to the <see cref="value"/>.</param>
    public CacheCode(T value, int hashCode)
    {
        _value = value;
        _hashCode = hashCode;
    }

    /// <summary>
    /// Creates a cached hashcode pair of <see cref="T"/> <paramref name="value"/> associated with its <see cref="int"/> <see cref="T.GetHashCode"/> result.
    /// </summary>
    /// <param name="value">The underlying value on which <see cref="T.GetHashCode"/> is called.</param>
    public CacheCode(T value) : this(value, value.GetHashCode())
    {
    }

    public bool Equals(T other) => _value.Equals(other);

    public bool Equals(CacheCode<T> other) => Equals(other._value);

    public override bool Equals(object obj) => obj switch
    {
        null => false,
        T other => Equals(other),
        CacheCode<T> other => Equals(other),
        _ => throw new InvalidOperationException($"Expected {typeof(T)} or {typeof(CacheCode<T>)}, got {obj.GetType()}"),
    };

    public override int GetHashCode() => _hashCode;

    public override string ToString() => _value.ToString();

    public static implicit operator T(CacheCode<T> cacheCode) => cacheCode._value;
    public static explicit operator CacheCode<T>(T value) => new(value);
}
