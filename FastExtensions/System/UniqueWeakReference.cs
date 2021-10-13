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
        /// <returns>A <see cref="UniqueWeakReference{T}"/> containing a deduplicated WeakReference to an object.</returns>
        public UniqueWeakReference<TTarget> GetOrCreate<TTarget>(T? target) where TTarget : class, T
        {
            // Create or fake a non-generic reference that can be wrapped.
            var rawReference = target is null || target is not TTarget
                ? Empty
                : _map.GetValue(target, x => new FinalizableGCHandle(x, GCHandleType.Weak));

            return new UniqueWeakReference<TTarget>(rawReference);
        }

        /// <summary>
        /// Looks up whther a unique weak reference is already associated with the target object.
        /// </summary>
        /// <typeparam name="TTarget"></typeparam>
        /// <param name="target"></param>
        /// <returns>A <see cref="UniqueWeakReference{T}"/> containing a deduplicated WeakReference to an object.</returns>
        public bool TryGetValue<TTarget>(T? target, out UniqueWeakReference<TTarget> result) where TTarget : class, T
        {
            if (target != null && _map.TryGetValue(target, out var rawReference))
            {
                result = new UniqueWeakReference<TTarget>(rawReference);
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
    public readonly struct UniqueWeakReference<T> where T : class
    {
        public FinalizableGCHandle UniqueHandle { get; }

        internal UniqueWeakReference(FinalizableGCHandle target)
        {
            UniqueHandle = target;
        }

        /// <summary>
        /// Tries to retrieve the target object that is referenced by the current <see cref="UniqueWeakReference{T}"/> object.
        /// </summary>
        /// <param name="target">When this method returns, contains the target object, if it is available. This parameter is treated as uninitialized.</param>
        /// <returns>true if the target was retrieved; otherwise, false.</returns>
        public bool TryGetTarget([NotNullWhen(returnValue: true)] out T? target)
        {
            var handle = UniqueHandle._handle;

            target = handle.IsAllocated ? handle.Target as T : null;

            return target != null;
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

