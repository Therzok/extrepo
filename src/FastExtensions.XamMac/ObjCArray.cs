using System;
using Foundation;

namespace FastExtensions.XamMac
{
    // TODO: Replace NSArray with something smarter, like,
    ref struct ObjCArray
    {
        // Maybe use Handle directly?
        public NSArray? Array { get; private set; }

        public ObjCArray(NSArray array)
        {
            Array = array;
        }

        public void Dispose()
        {
            Array?.Dispose();
            Array = null;
        }
    }
}

