using System;
using System.Diagnostics.Tracing;


namespace FastExtensions.Specialized.Weak;

[EventSource(Name = DeduplicatedWeakEventSource.EventSourceName)]
public sealed class DeduplicatedWeakEventSource : EventSource
{
    public const string EventSourceName =
        nameof(FastExtensions) + "." +
        nameof(Specialized) + "." +
        nameof(Weak) + "." +
        nameof(DeduplicatedWeakEventSource);

    public static readonly DeduplicatedWeakEventSource Log = new DeduplicatedWeakEventSource();

    private EventCounter _requestCounter;

    private DeduplicatedWeakEventSource() =>
        _requestCounter = new EventCounter("request-time", this)
        {
            DisplayName = "Request Processing Time",
            DisplayUnits = "ms"
        };

    public void Request(string url, long elapsedMilliseconds)
    {
        WriteEvent(1, url, elapsedMilliseconds);
        _requestCounter?.WriteMetric(elapsedMilliseconds);
    }

    protected override void Dispose(bool disposing)
    {
        _requestCounter?.Dispose();
        _requestCounter = null;

        base.Dispose(disposing);
    }
}
