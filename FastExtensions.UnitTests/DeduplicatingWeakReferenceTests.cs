using System;
using System.Text;
using NUnit.Framework;

namespace FastExtensions.UnitTests;

[TestFixture]
public class DeduplicatingWeakReferenceTests
{
    [Test]
    public void TestEmpty()
    {
        var map = new WeakSelfMap<object>();

        // Check empty values
        Assert.IsFalse(map.TryGetValue<object>(null, out _));
        Assert.IsFalse(map.TryGetValue<string>(null, out _));

        // Check object that's not added
        var first = new string('a', 1);
        Assert.IsFalse(map.TryGetValue<object>(first, out _));
        Assert.IsFalse(map.TryGetValue<string>(first, out _));
    }

    [Test]
    public void TestSameDerived()
    {
        var map = new WeakSelfMap<object>();

        var first = new StringBuilder();

        var weakRef = map.GetOrCreate<object>(first);

        Assert.IsTrue(weakRef.TryGetTarget(out var target));
        Assert.AreSame(target, first);

        var stringRef = map.GetOrCreate<string>(first);
        Assert.IsFalse(stringRef.TryGetTarget(out _));

        var stringBuilderRef = map.GetOrCreate<StringBuilder>(first);
        Assert.IsTrue(stringBuilderRef.TryGetTarget(out var stringBuilderTarget));
        Assert.AreSame(target, stringBuilderTarget);
        Assert.AreSame(weakRef.UniqueHandle, stringBuilderRef.UniqueHandle);
    }
}
