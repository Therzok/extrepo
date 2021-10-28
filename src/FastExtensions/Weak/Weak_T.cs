using System.Runtime.CompilerServices;

namespace System;

/// <summary>
/// This struct wraps a <see cref="WeakReference{T}"/>-like created via <see cref="WeakSelfMap{T}"/>.
/// </summary>
/// <typeparam name="T">The target type of the object.</typeparam>
public readonly struct Weak<T> where T : class
{
    readonly SafeGCHandle _uniqueHandle;

    internal Weak(SafeGCHandle target)
    {
        _uniqueHandle = target;
    }

    /// <summary>
    /// Retrieves the currently weak referenced <paramref name="target"/>.
    /// </summary>
    /// <returns>Returns the weakly referenced object, if it is available, otherwise <see langword="null"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T? Get() => _uniqueHandle.Get() as T;
}


