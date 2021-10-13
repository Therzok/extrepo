using System;
using System.Diagnostics.CodeAnalysis;

// Different namespace?
namespace System
{
    public static class ThrowHelper
    {
        [DoesNotReturn]
        public static void ThrowArgumentNullException(string paramName) => throw new ArgumentNullException(paramName);
    }
}

