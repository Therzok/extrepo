using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

using FastExtensions.Specialized.Weak;

namespace System;

static class Weak_TExtensions
{
    // TODO: Not sure which API is nicer, since you can now do:
    // if (weakRef.Get() is MyType obj)

    /// <summary>
    /// Retrieves the currently weak referenced <paramref name="target"/>.
    /// </summary>
    /// <param name="target">When this method returns, contains the target object, if it is available. This parameter is treated as uninitialized.</param>
    /// <returns><see langword="true"/> if the target was retrieved; otherwise, <see langword="false"/>.</returns>
    internal static bool TryGet<T>(this Weak<T> weak, [NotNullWhen(returnValue: true)] out T? target) where T : class
    {
        target = weak.Get();

        return target != null;
    }

    internal static object GetHandle<T>(this Weak<T> weak) where T:class
    {
        // Get the underlying SafeGCHandle
        return Unsafe.As<Weak<T>, object>(ref weak);
    }
}

