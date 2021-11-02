using System;
using System.Runtime.InteropServices;

namespace FastExtensions.Specialized.Weak;

// This intentionally doesn't implement IDisposable, there is no direct way to remove items from the mapping.
public abstract class SafeGCHandle
{
    public static readonly SafeGCHandle Empty = new EmptyHandle();

    public static SafeGCHandle Weak(object? target)
    {
        var gch = GCHandle.Alloc(target, GCHandleType.Weak);

        return new AllocatedHandle(gch);
    }

    internal abstract object? Get();

    sealed class EmptyHandle : SafeGCHandle
    {
        internal sealed override object? Get() => null;
    }

    sealed class AllocatedHandle : SafeGCHandle
    {
        GCHandle _handle;
        public AllocatedHandle(GCHandle handle)
        {
            _handle = handle;
        }

        ~AllocatedHandle()
        {
            _handle.Free();
        }

        // _handle.Allocated can never be false until finalization.
        internal sealed override object? Get() => _handle.Target;
    }
}


