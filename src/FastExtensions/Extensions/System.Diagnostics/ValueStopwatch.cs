using System;

namespace System.Diagnostics;

// Based off of Roslyn's version:
// https://github.com/dotnet/roslyn/blob/1a03aae79f6c8db82936c71b9a21f55e2f974fcc/src/Compilers/Core/Portable/InternalUtilities/SharedStopwatch.cs#L12
internal readonly struct ValueStopwatch
{
    private static readonly Stopwatch s_stopwatch = Stopwatch.StartNew();

    private readonly TimeSpan _started;

    private ValueStopwatch(TimeSpan started)
    {
        _started = started;
    }

    public TimeSpan Elapsed => s_stopwatch.Elapsed - _started;

    public static ValueStopwatch StartNew()
        => new ValueStopwatch(s_stopwatch.Elapsed);
}
