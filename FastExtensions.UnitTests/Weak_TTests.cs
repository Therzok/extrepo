using System;
using System.Text;
using NUnit.Framework;

namespace FastExtensions.UnitTests;

[TestFixture]
public class Weak_TTests
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
    public void TestGetAndTryGetAreSame()
    {
        var map = new WeakSelfMap<object>();

        var first = new StringBuilder();

        var weakRef = map.GetOrCreate<object>(first);

        weakRef.TryGet(out var weak);
        Assert.AreSame(weakRef.Get(), weak);
    }

    [Test]
    public void TestSameDerived()
    {
        var map = new WeakSelfMap<object>();

        var first = new StringBuilder();

        var weakRef = map.GetOrCreate<object>(first);

        Assert.IsNotNull(weakRef.Get());
        Assert.IsTrue(weakRef.TryGet(out var target));
        Assert.AreSame(target, first);

        var stringRef = map.GetOrCreate<string>(first);
        Assert.IsNull(stringRef.Get());
        Assert.IsFalse(stringRef.TryGet(out _));

        var stringBuilderRef = map.GetOrCreate<StringBuilder>(first);
        Assert.IsNotNull(stringBuilderRef.Get());
        Assert.IsTrue(stringBuilderRef.TryGet(out var stringBuilderTarget));
        Assert.AreSame(target, stringBuilderTarget);
        Assert.AreSame(weakRef.UniqueHandle, stringBuilderRef.UniqueHandle);
    }
}
