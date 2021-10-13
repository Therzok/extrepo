using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using Foundation;

namespace Foundation
{
    public static class NSObjectExtensions
    {
        static readonly WeakSelfMap<NSObject> _weakSelfMap = new();

        public static UniqueWeakReference<T> WeakSelf<T>(this T? that) where T : NSObject
        {
            return _weakSelfMap.GetOrCreate<T>(that);
        }
    }

}

