namespace FastExtensions.Specialized;

/// <summary>
/// A pair of <see cref="(T, int)"/> which caches the <see cref="GetHashCode"/> result on creation.
/// Only use in case of <see langword="readonly"/> types, such as strings or collections in <see cref="Collections.Immutable" />.
/// </summary>
/// <remarks>
/// This can also be used to force a hashcode value for a given object.
/// </remarks>
/// <typeparam name="T"></typeparam>
public readonly struct Hashed<T> : IEquatable<Hashed<T>>, IEquatable<T> where T : notnull, IEquatable<T>
{
    // TODO: Find a way to use an IEqualityComparer, but that would require runtime checks.
    readonly T _value;
    readonly int _hashCode;

    /// <summary>
    /// Creates a cached hashcode pair of <see cref="T"/> <paramref name="value"/> associated with its <see cref="int"/> <paramref name="hashCode" />.
    /// </summary>
    /// <param name="value">The underlying value </param>
    /// <param name="hashCode">The hashcode value corresponding to the <see cref="value"/>.</param>
    public Hashed(T value, int hashCode)
    {
        _value = value;
        _hashCode = hashCode;
    }

    /// <summary>
    /// Creates a cached hashcode pair of <see cref="T"/> <paramref name="value"/> associated with its <see cref="int"/> <see cref="T.GetHashCode"/> result.
    /// </summary>
    /// <param name="value">The underlying value on which <see cref="T.GetHashCode"/> is called.</param>
    public Hashed(T value) : this(value, value.GetHashCode())
    {
    }

    public bool Equals(T other) => _value.Equals(other);

    public bool Equals(Hashed<T> other) => Equals(other._value);

    public override bool Equals(object obj) => obj switch
    {
        null => false,
        T other => Equals(other),
        Hashed<T> other => Equals(other),
        _ => throw new InvalidOperationException($"Expected {typeof(T)} or {typeof(Hashed<T>)}, got {obj.GetType()}"),
    };

    public T Value => _value;

    public override int GetHashCode() => _hashCode;

    public override string ToString() => _value.ToString();

    // Not sure I like these yet, we'd end up with intermediate conversions
    // that would cause recalculation of the hashcode on reconstruction.

    //public static implicit operator T(Hashed<T> hashed) => hashed._value;
    //public static explicit operator Hashed<T>(T value) => new(value);
}
