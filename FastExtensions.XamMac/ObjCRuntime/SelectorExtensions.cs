using System;
using ObjCRuntime;

namespace FastExtensions.XamMac;

// TODO: Convert to source generator that generates these.
// TODO: Provide specific Selector overrides to avoid errors.
public static partial class SelectorExtensions
{
    //public static void void_msgSendSuper(ref Interop.objc_super receiver, IntPtr selector);

    public static void void_msgSend(this Selector selector, INativeObject receiver, IntPtr value) =>
        receiver.void_msgSend(selector.Handle, value);

    public static void void_msgSend_ref(this Selector selector, INativeObject receiver, ref IntPtr value) =>
        receiver.void_msgSend_ref(selector.Handle, ref value);

    public static void void_msgSend_out(this Selector selector, INativeObject receiver, out IntPtr value) =>
        receiver.void_msgSend_out(selector.Handle, out value);

    public static void void_msgSend(this Selector selector, INativeObject receiver, IntPtr p1, IntPtr p2) =>
        receiver.void_msgSend(selector.Handle, p1, p2);

    // nint is different in Xamarin.Mac and net6.
    //public static nint nint_objc_msgSend_IntPtr_nint(this Selector selector, INativeObject receiver, IntPtr p1, nint p2) =>
    //    Interop.nint_objc_msgSend_IntPtr_nint(receiver, selector.Handle, p1, p2);

    //public static void void_objc_msgSend_IntPtr_ref_BlockLiteral(this Selector selector, INativeObject receiver, IntPtr p1, ref BlockLiteral p2);

    public static void void_msgSend(this Selector selector, INativeObject receiver, IntPtr p1, IntPtr p2, IntPtr p3, IntPtr p4) =>
        receiver.void_msgSend(selector.Handle, p1, p2, p3, p4);

    //public static void void_objc_msgSend_IntPtr_IntPtr_IntPtr_NSRange_IntPtr(this Selector selector, INativeObject receiver, IntPtr p1, IntPtr p2, IntPtr p3, NSRange p4, IntPtr p5);

    public static void void_msgSend(this Selector selector, INativeObject receiver, int value) =>
        receiver.void_msgSend(selector.Handle, value);

    public static void void_msgSend(this Selector selector, INativeObject receiver, int p1, int p2, int p3, int p4, int p5, int p6, IntPtr p7) =>
        receiver.void_msgSend(selector.Handle, p1, p2, p3, p4, p5, p6, p7);

    public static void void_msgSend(this Selector selector, INativeObject receiver, IntPtr p1, IntPtr p2, IntPtr p3, long p4, int p5, IntPtr p7) =>
        receiver.void_msgSend(selector.Handle, p1, p2, p3, p4, p5, p7);

    public static void void_msgSend(this Selector selector, INativeObject receiver, long value) =>
        receiver.void_msgSend(selector.Handle, value);

    public static void void_msgSend(this Selector selector, INativeObject receiver, int p1, int p2, long p3) =>
        receiver.void_msgSend(selector.Handle, p1, p2, p3);

    public static void void_msgSend(this Selector selector, INativeObject receiver, long p1, int p2, long p3) =>
        receiver.void_msgSend(selector.Handle, p1, p2, p3);

    public static IntPtr IntPtr_msgSend(this Selector selector, INativeObject receiver) =>
        receiver.IntPtr_msgSend(selector.Handle);

    public static IntPtr IntPtr_msgSend(this Selector selector, INativeObject receiver, int p1) =>
        receiver.IntPtr_msgSend(selector.Handle, p1);

    public static IntPtr IntPtr_msgSend(this Selector selector, INativeObject receiver, long p1) =>
        receiver.IntPtr_msgSend(selector.Handle, p1);

    public static int int_msgSend(this Selector selector, INativeObject receiver, int p1) =>
        receiver.int_msgSend(selector.Handle, p1);

    public static IntPtr IntPtr_msgSend_ref(this Selector selector, INativeObject receiver, ref IntPtr p1) =>
        receiver.IntPtr_msgSend_ref(selector.Handle, ref p1);

    public static IntPtr IntPtr_msgSend(this Selector selector, INativeObject receiver, IntPtr p1) =>
        receiver.IntPtr_msgSend(selector.Handle, p1);

    public static IntPtr IntPtr_msgSend(this Selector selector, INativeObject receiver, IntPtr p1, IntPtr p2) =>
        receiver.IntPtr_msgSend(selector.Handle, p1, p2);

    public static IntPtr IntPtr_msgSend(this Selector selector, INativeObject receiver, double a, double b) =>
        receiver.IntPtr_msgSend(selector.Handle, a, b);

    public static IntPtr IntPtr_msgSend(this Selector selector, INativeObject receiver, bool p1) =>
        receiver.IntPtr_msgSend(selector.Handle, p1);

    public static double double_msgSend(this Selector selector, INativeObject receiver) =>
        receiver.double_msgSend(selector.Handle);

    public static float float_msgSend(this Selector selector, INativeObject receiver) =>
        receiver.float_msgSend(selector.Handle);

    public static bool bool_msgSend(this Selector selector, INativeObject receiver) =>
        receiver.bool_msgSend(selector.Handle);

    public static int int_msgSend(this Selector selector, INativeObject receiver) =>
        receiver.int_msgSend(selector.Handle);

    public static long long_msgSend(this Selector selector, INativeObject receiver) =>
        receiver.long_msgSend(selector.Handle);

    public static void void_msgSend(this Selector selector, INativeObject receiver) =>
        receiver.void_msgSend(selector.Handle);

    public static int int_msgSend(this Selector selector, INativeObject receiver, IntPtr p1) =>
        receiver.int_msgSend(selector.Handle, p1);

    public static bool bool_msgSend(this Selector selector, INativeObject receiver, IntPtr p1) =>
        receiver.bool_msgSend(selector.Handle, p1);

    public static bool bool_msgSend(this Selector selector, INativeObject receiver, IntPtr p1, int p2) =>
        receiver.bool_msgSend(selector.Handle, p1, p2);
}

