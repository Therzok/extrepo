using System;
using System.Runtime.InteropServices;
using AppKit;
using Foundation;
using ObjCRuntime;

namespace FastExtensions.XamMac;

public static class NSStackViewExtensions
{
    static readonly IntPtr selArrangedSubviews = Selector.GetHandle("arrangedSubviews");

    public static NSArray GetArrangedSubviews(this NSStackView view)
    {
        var arrangedSubviews = view.IntPtr_msgSend(selArrangedSubviews);
        // Should this be owned?
        return Runtime.GetNSObject<NSArray>(arrangedSubviews);
    }

    public static nuint GetArrangedSubviewCount(this NSStackView view)
    {
        using var subviews = view.GetArrangedSubviews();
        return subviews.Count;
    }
}

