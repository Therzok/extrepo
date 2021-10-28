using System;
namespace FastExtensions.XamMac
{
    public ref struct OwnedReference<T> where T:class
    {
        public T Value { get; }

        public OwnedReference(T value)
        {
            Value = value;
        }

        public void Dispose()
        {
            // Release here.
        }
    }
}

