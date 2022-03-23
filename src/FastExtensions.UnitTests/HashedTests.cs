using System;
using FastExtensions.Specialized;
using Xunit;

namespace FastExtensions.UnitTests
{
    public class HashedTests
    {
        sealed class CaptureHashcode : IEquatable<CaptureHashcode>
        {
            public int HashCodeCallCount;

            public bool Equals(CaptureHashcode? other)
            {
                return base.Equals(other);
            }

            public override int GetHashCode()
            {
                HashCodeCallCount++;
                return base.GetHashCode();
            }
        }

        [Fact]
        public void CalledOnce()
        {
            var hashed = new Hashed<CaptureHashcode>(new CaptureHashcode());

            Assert.Equal(1, hashed.Value.HashCodeCallCount);

            // Subsequent calls don't do it again.
            _ = hashed.GetHashCode();

            Assert.Equal(1, hashed.Value.HashCodeCallCount);
        }

    }
}

