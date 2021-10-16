using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Should this be in a different namespace?
namespace System
{
    /// <summary>
    /// A map in which each key has a unique weak reference attached to itself.
    /// </summary>
    /// <typeparam name="T">The type of the object to be weakly referenced.</typeparam>
    public sealed class WeakSelfMap<T> where T : class?
    {
        readonly FinalizableGCHandle Empty = new(null, GCHandleType.Weak);
        readonly ConditionalWeakTable<T, FinalizableGCHandle> _map = new();

        /// <summary>
        /// Looks up and, if needed, creates a unique weak reference to the target object.
        /// </summary>
        /// <typeparam name="TTarget"></typeparam>
        /// <param name="target"></param>
        /// <returns>A <see cref="Weak{T}"/> containing a deduplicated WeakReference to an object.</returns>
        public Weak<TTarget> GetOrCreate<TTarget>(T? target) where TTarget : class, T
        {
            // Create or fake a non-generic reference that can be wrapped.
            var rawReference = target is null || target is not TTarget
                ? Empty
                : _map.GetValue(target, x => new FinalizableGCHandle(x, GCHandleType.Weak));

            return new Weak<TTarget>(rawReference);
        }

        /// <summary>
        /// Looks up whther a unique weak reference is already associated with the target object.
        /// </summary>
        /// <typeparam name="TTarget"></typeparam>
        /// <param name="target"></param>
        /// <returns>A <see cref="Weak{T}"/> containing a deduplicated WeakReference to an object.</returns>
        public bool TryGetValue<TTarget>(T? target, out Weak<TTarget> result) where TTarget : class, T
        {
            if (target != null && _map.TryGetValue(target, out var rawReference))
            {
                result = new Weak<TTarget>(rawReference);
                return true;
            }

            result = default;
            return false;
        }
    }

    /// <summary>
    /// This struct wraps a unique WeakReference-like object created via <see cref="WeakSelfMap{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    public readonly struct Weak<T> where T : class
    {
        public FinalizableGCHandle UniqueHandle { get; }

        internal Weak(FinalizableGCHandle target)
        {
            UniqueHandle = target;
        }

        /// <summary>
        /// Tries to retrieve the target object that is referenced by the current <see cref="Weak{T}"/> object.
        /// </summary>
        /// <param name="target">When this method returns, contains the target object, if it is available. This parameter is treated as uninitialized.</param>
        /// <returns>true if the target was retrieved; otherwise, false.</returns>
        public bool TryGet([NotNullWhen(returnValue: true)] out T? target)
        {
            return (target = Get()) != null;
        }

        public T? Get()
        {
            var handle = UniqueHandle._handle;

            return handle.IsAllocated ? handle.Target as T : null;
        }
    }

    public sealed class FinalizableGCHandle
    {
        internal GCHandle _handle;

        public FinalizableGCHandle(object? target, GCHandleType trackResurrection)
        {
            _handle = GCHandle.Alloc(target, trackResurrection);
        }

        ~FinalizableGCHandle()
        {
            _handle.Free();
        }
    }
}

