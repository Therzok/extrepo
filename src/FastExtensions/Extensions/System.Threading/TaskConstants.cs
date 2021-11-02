using System;

namespace System.Threading
{
    public static class TaskConstants
    {
        public static Task<bool> False { get; } = TaskConstants<bool>.Default;
        public static Task<bool> True { get; } = Task.FromResult(true);
        public static Task<int> IntZero { get; } = Task.FromResult(0);
        public static Task<int> IntNegativeOne { get; } = Task.FromResult(-1);
        public static Task Cancelled { get; } = TaskConstants<object>.Cancelled;
    }

    public static class TaskConstants<T>
    {
        public static Task<T> Default { get; } = Task.FromResult(default(T));
        public static Task<T> Cancelled { get; } = Task.FromCanceled<T>(new CancellationToken(true));
    }
}

