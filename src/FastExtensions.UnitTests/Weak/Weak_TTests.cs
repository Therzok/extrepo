using System;
using System.Runtime.CompilerServices;
using System.Text;
using Xunit;

using FastExtensions.Specialized.Weak;

namespace FastExtensions.UnitTests;

public class Weak_TTests
{
    [Fact]
    public void DoesNotContain_Null()
    {
        var weakMap = new WeakSelfMap<object>();

        // Check empty values
        Assert.False(weakMap.TryGetValue<object>(null, out var objValue));
        Assert.Null(objValue.Get());

        Assert.False(weakMap.TryGetValue<string>(null, out var strValue));
        Assert.Null(strValue.Get());
    }

    [Fact]
    public void DoesNotContain_NewObject()
    {
        var weakMap = new WeakSelfMap<object>();
        var obj = new string('a', 1);

        // Check object that's not added
        Assert.False(weakMap.TryGetValue<object>(obj, out var objValue));
        Assert.Null(objValue.Get());

        Assert.False(weakMap.TryGetValue<string>(obj, out var strValue));
        Assert.Null(strValue.Get());
    }

    [Fact]
    public void GetAndTryGet_AreSame()
    {
        var weakMap = new WeakSelfMap<object>();
        var obj = new StringBuilder();

        // Add the object
        var weakObj = weakMap.GetOrAdd<object>(obj);

        // Check the entry exists.
        Assert.True(weakObj.TryGet(out var objValue));
        Assert.Same(obj, objValue);
        Assert.Same(obj, weakObj.Get());
    }

    [Fact]
    public void MultipleDerivedGetOrAdd_SameObjects()
    {
        var map = new WeakSelfMap<object>();
        var obj = new StringBuilder();

        // Add the object, initially requesting a Weak<object>
        var weakObj = map.GetOrAdd<object>(obj);
        Assert.Same(obj, weakObj.Get());

        // Try requesting a Weak<string> which should fail.
        var weakString = map.GetOrAdd<string>(obj);
        Assert.Null(weakString.Get());

        // Request Weak<StringBuilder> and ensure it is correct.
        var weakStringBuilder = map.GetOrAdd<StringBuilder>(obj);
        Assert.Same(obj, weakStringBuilder.Get());

        // Check whether the target objects are the same.
        Assert.True(weakStringBuilder.TryGet(out var stringBuilderTarget));
        Assert.Same(obj, stringBuilderTarget);
    }

    [Fact]
    public void CheckHandleTypes_AllObjects()
    {
        var map = new WeakSelfMap<object>();
        var obj = new StringBuilder();

        // Null object and invalid type are empty handles.
        var nullObj = map.GetOrAdd<object>(null).GetHandle();
        Assert.Equal("FastExtensions.Specialized.Weak.SafeGCHandle+EmptyHandle", nullObj.GetType().FullName);

        var typeMismatchObj = map.GetOrAdd<StringComparer>(obj).GetHandle();
        Assert.Equal("FastExtensions.Specialized.Weak.SafeGCHandle+EmptyHandle", typeMismatchObj.GetType().FullName);

        var typeMismatchOtherObj = map.GetOrAdd<StringComparer>(new object()).GetHandle();
        Assert.Equal("FastExtensions.Specialized.Weak.SafeGCHandle+EmptyHandle", typeMismatchOtherObj.GetType().FullName);

        // Check the same EmptyHandle is used.
        Assert.Same(nullObj, typeMismatchObj);
        Assert.Same(typeMismatchObj, typeMismatchOtherObj);

        var weakObj = map.GetOrAdd<object>(obj).GetHandle();
        Assert.Equal("FastExtensions.Specialized.Weak.SafeGCHandle+AllocatedHandle", weakObj.GetType().FullName);

        var weakStringBuilder = map.GetOrAdd<StringBuilder>(obj).GetHandle();
        Assert.Equal("FastExtensions.Specialized.Weak.SafeGCHandle+AllocatedHandle", weakStringBuilder.GetType().FullName);

        // Check the GCHandles are the same.
        Assert.Same(weakObj, weakStringBuilder);
    }

    [Theory]
    [InlineData(1, 2.0)]
    [InlineData(1, 3.0)]
    [InlineData(1, 4.0)]
    public void Meh(int x, double y)
    {

    }
}
