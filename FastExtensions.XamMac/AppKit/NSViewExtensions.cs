using System;
using AppKit;
using Foundation;
using ObjCRuntime;

namespace FastExtensions.XamMac;

public static class NSViewExtensions
{
    static readonly IntPtr selSubviews = Selector.GetHandle("subviews");

    // Should this be CFArray? Do it when updating Xamarin.Mac or net6 targets?
    // Prototype struct wrapper for Subviews so you don't have to deal with complex API names.
    public static NSArray GetSubviews(this NSView view)
    {
        var subviewsHandle = view.IntPtr_msgSend(selSubviews);
        // TODO: Should this own the array? I think so.
        return Runtime.GetNSObject<NSArray>(subviewsHandle);
    }

    public static bool ContainsSubview(this NSView view, NSView subview)
    {
        using var subviews = view.GetSubviews();
        return subviews.Contains(subview);
    }

    public static nuint IndexOfSubview(this NSView view, NSView subview)
    {
        using var subviews = view.GetSubviews();
        return subviews.IndexOf(subview);
    }

    public static NSView GetSubviewAt(this NSView view, int index)
    {
        using var subviews = view.GetSubviews();
        return subviews.GetItem<NSView>((nuint)index);
    }

    public static nuint GetSubviewCount(this NSView view)
    {
        using var subViews = view.GetSubviews();
        return subViews.Count;
    }

    public static void ClearSubviews(this NSView view)
    {
        foreach (var subview in view.Subviews)
        {
            subview.RemoveFromSuperview();
        }
    }
}

