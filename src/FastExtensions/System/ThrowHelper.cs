using System.Diagnostics.CodeAnalysis;

namespace System;

public static class ThrowHelper
{
    [DoesNotReturn]
    public static void ThrowArgumentNullException(string paramName) => throw new ArgumentNullException(paramName);

    [DoesNotReturn]
    public static void ThrowInvalidOperationException(string message) => throw new InvalidOperationException(message);
}

