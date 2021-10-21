using System;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace ObjCRuntime
{
    /*
    public class NSObjectSafeHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        public NSObjectSafeHandle(IntPtr native, bool owned) : base(owned)
        {
            SetHandle(native);
        }

        protected override bool ReleaseHandle()
        {

            throw new NotImplementedException();
        }
    }

    public sealed class NSObjectUIThreadSafeHandle : NSObjectSafeHandle
    {
        public NSObjectUIThreadSafeHandle(IntPtr native, bool owned) : base(native, owned)
        {
        }

        protected override bool ReleaseHandle()
        {
            // Use UI thread.
            return base.ReleaseHandle();
        }
    }
    */
}

