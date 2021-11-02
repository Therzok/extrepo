using System.Runtime.CompilerServices;

namespace FastExtensions.Specialized.Weak;

/// <summary>
/// A map in which each key has a unique weak reference attached to itself.
/// It is useful for scenarios when passing <see cref="WeakReference{T}"/> is verbose.
/// It should help alleviate GC pressure as a result of reduced <see cref="GCHandle"/>.
/// </summary>
/// <typeparam name="T">The type of the object to be weakly referenced.</typeparam>
/// <remarks>
/// The map does not support removal, as this can lead to weak <see cref="GCHandle"/> duplication.
/// </remarks>
public sealed class WeakSelfMap<T> where T : class?
{
    readonly ConditionalWeakTable<T, SafeGCHandle> _map = new();

    /// <summary>
    /// Adds a deduplicated <see cref="Weak{T}"/> associated with <paramref names="target"/>
    /// to the <see cref="WeakSelfMap{T}"/> if the key does not already exist.
    /// </summary>
    /// <typeparam name="TTarget">Any destination target type.</typeparam>
    /// <param name="target">The object to be uniquely weakly referenced.</param>
    /// <returns>A <see cref="Weak{T}"/> which is technically an uniquely associated <see cref="WeakReference{T}"/>.</returns>
    public Weak<TTarget> GetOrAdd<TTarget>(T? target) where TTarget : class, T
    {
        // Create or fake a non-generic reference that can be wrapped.
        SafeGCHandle rawReference = target switch
        {
            TTarget key => _map.GetValue(key, static x => SafeGCHandle.Weak(x)),
            _ => SafeGCHandle.Empty,
        };

        return new Weak<TTarget>(rawReference);
    }

    /// <summary>
    /// Looks up the <see cref="WeakSelfMap{T}"/> for an associated <see cref="Weak{T}"/> with <paramref name="target"/>.
    /// </summary>
    /// <typeparam name="TTarget">Any destination target type.</typeparam>
    /// <param name="target">The object to be uniquely weakly referenced .</param>
    /// <returns><see langword="true"/> is the target has an uniquely associated <see cref="Weak{T}"/>, <see langword="false"/> otherwise.</returns>
    public bool TryGetValue<TTarget>(T? target, out Weak<TTarget> result) where TTarget : class, T
    {
        if (target is TTarget && _map.TryGetValue(target, out SafeGCHandle rawReference))
        {
            result = new Weak<TTarget>(rawReference);
            return true;
        }

        result = new Weak<TTarget>(SafeGCHandle.Empty);
        return false;
    }

    internal bool TryGetValue(T? target, out SafeGCHandle rawReference)
    {
        if (target is null)
        {
            rawReference = SafeGCHandle.Empty;
            return false;
        }

        return _map.TryGetValue(target, out rawReference);
    }
}

