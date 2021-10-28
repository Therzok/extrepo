using System;
using ObjCRuntime;
using ObjCRuntime.Native;

namespace FastExtensions.XamMac;

// TODO: Convert to source generator that generates these.
// TODO: Provide specific Selector overrides to avoid errors.
public static partial class INativeObjectExtensions
{
    //public static void void_msgSendSuper(ref Interop.objc_super receiver, IntPtr selector);

    public static void void_msgSend(this INativeObject receiver, IntPtr selector, IntPtr value) =>
        RuntimeInterop.void_objc_msgSend_IntPtr(receiver.GetHandle(), selector, value);

    public static void void_msgSend_ref(this INativeObject receiver, IntPtr selector, ref IntPtr value) =>
        RuntimeInterop.void_objc_msgSend_ref_IntPtr(receiver.GetHandle(), selector, ref value);

    public static void void_msgSend_out(this INativeObject receiver, IntPtr selector, out IntPtr value) =>
        RuntimeInterop.void_objc_msgSend_out_IntPtr(receiver.GetHandle(), selector, out value);

    public static void void_msgSend(this INativeObject receiver, IntPtr selector, IntPtr p1, IntPtr p2) =>
        RuntimeInterop.void_objc_msgSend_IntPtr_IntPtr(receiver.GetHandle(), selector, p1, p2);

    // nint is different in Xamarin.Mac and net6.
    //public static nint nint_objc_msgSend_IntPtr_nint(this INativeObject receiver, IntPtr selector, IntPtr p1, nint p2) =>
    //    Interop.nint_objc_msgSend_IntPtr_nint(receiver.GetHandle(), selector, p1, p2);

    //public static void void_objc_msgSend_IntPtr_ref_BlockLiteral(this INativeObject receiver, IntPtr selector, IntPtr p1, ref BlockLiteral p2);

    public static void void_msgSend(this INativeObject receiver, IntPtr selector, IntPtr p1, IntPtr p2, IntPtr p3, IntPtr p4) =>
        RuntimeInterop.void_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr(receiver.GetHandle(), selector, p1, p2, p3, p4);

    //public static void void_objc_msgSend_IntPtr_IntPtr_IntPtr_NSRange_IntPtr(this INativeObject receiver, IntPtr selector, IntPtr p1, IntPtr p2, IntPtr p3, NSRange p4, IntPtr p5);

    public static void void_msgSend(this INativeObject receiver, IntPtr selector, int value) =>
        RuntimeInterop.void_objc_msgSend_int(receiver.GetHandle(), selector, value);

    public static void void_msgSend(this INativeObject receiver, IntPtr selector, int p1, int p2, int p3, int p4, int p5, int p6, IntPtr p7) =>
        RuntimeInterop.void_objc_msgSend_int_int_int_int_int_int_IntPtr(receiver.GetHandle(), selector, p1, p2, p3, p4, p5, p6, p7);

    public static void void_msgSend(this INativeObject receiver, IntPtr selector, IntPtr p1, IntPtr p2, IntPtr p3, long p4, int p5, IntPtr p7) =>
        RuntimeInterop.void_objc_msgSend_IntPtr_IntPtr_IntPtr_long_int_IntPtr(receiver.GetHandle(), selector, p1, p2, p3, p4, p5, p7);

    public static void void_msgSend(this INativeObject receiver, IntPtr selector, long value) =>
        RuntimeInterop.void_objc_msgSend_long(receiver.GetHandle(), selector, value);

    public static void void_msgSend(this INativeObject receiver, IntPtr selector, int p1, int p2, long p3) =>
        RuntimeInterop.void_objc_msgSend_int_int_long(receiver.GetHandle(), selector, p1, p2, p3);

    public static void void_msgSend(this INativeObject receiver, IntPtr selector, long p1, int p2, long p3) =>
        RuntimeInterop.void_objc_msgSend_long_int_long(receiver.GetHandle(), selector, p1, p2, p3);

    public static IntPtr IntPtr_msgSend(this INativeObject receiver, IntPtr selector) =>
        RuntimeInterop.IntPtr_objc_msgSend(receiver.GetHandle(), selector);

    public static IntPtr IntPtr_msgSend(this INativeObject receiver, IntPtr selector, int p1) =>
        RuntimeInterop.IntPtr_objc_msgSend_int(receiver.GetHandle(), selector, p1);

    public static IntPtr IntPtr_msgSend(this INativeObject receiver, IntPtr selector, long p1) =>
        RuntimeInterop.IntPtr_objc_msgSend_long(receiver.GetHandle(), selector, p1);

    public static int int_msgSend(this INativeObject receiver, IntPtr selector, int p1) =>
        RuntimeInterop.int_objc_msgSend_int(receiver.GetHandle(), selector, p1);

    public static IntPtr IntPtr_msgSend_ref(this INativeObject receiver, IntPtr selector, ref IntPtr p1) =>
        RuntimeInterop.IntPtr_objc_msgSend_ref_IntPtr(receiver.GetHandle(), selector, ref p1);

    public static IntPtr IntPtr_msgSend(this INativeObject receiver, IntPtr selector, IntPtr p1) =>
        RuntimeInterop.IntPtr_objc_msgSend_IntPtr(receiver.GetHandle(), selector, p1);

    public static IntPtr IntPtr_msgSend(this INativeObject receiver, IntPtr selector, IntPtr p1, IntPtr p2) =>
        RuntimeInterop.IntPtr_objc_msgSend_IntPtr_IntPtr(receiver.GetHandle(), selector, p1, p2);

    public static IntPtr IntPtr_msgSend(this INativeObject receiver, IntPtr selector, double a, double b) =>
        RuntimeInterop.IntPtr_objc_msgSend_double_double(receiver.GetHandle(), selector, a, b);

    public static IntPtr IntPtr_msgSend(this INativeObject receiver, IntPtr selector, bool p1) =>
        RuntimeInterop.IntPtr_objc_msgSend_bool(receiver.GetHandle(), selector, p1);

    public static double double_msgSend(this INativeObject receiver, IntPtr selector) =>
        RuntimeInterop.Double_objc_msgSend(receiver.GetHandle(), selector);

    public static float float_msgSend(this INativeObject receiver, IntPtr selector) =>
        RuntimeInterop.float_objc_msgSend(receiver.GetHandle(), selector);

    public static bool bool_msgSend(this INativeObject receiver, IntPtr selector) =>
        RuntimeInterop.bool_objc_msgSend(receiver.GetHandle(), selector);

    public static int int_msgSend(this INativeObject receiver, IntPtr selector) =>
        RuntimeInterop.int_objc_msgSend(receiver.GetHandle(), selector);

    public static long long_msgSend(this INativeObject receiver, IntPtr selector) =>
        RuntimeInterop.long_objc_msgSend(receiver.GetHandle(), selector);

    public static void void_msgSend(this INativeObject receiver, IntPtr selector) =>
        RuntimeInterop.void_objc_msgSend(receiver.GetHandle(), selector);

    public static int int_msgSend(this INativeObject receiver, IntPtr selector, IntPtr p1) =>
        RuntimeInterop.int_objc_msgSend_IntPtr(receiver.GetHandle(), selector, p1);

    public static bool bool_msgSend(this INativeObject receiver, IntPtr selector, IntPtr p1) =>
        RuntimeInterop.bool_objc_msgSend_IntPtr(receiver.GetHandle(), selector, p1);

    public static bool bool_msgSend(this INativeObject receiver, IntPtr selector, IntPtr p1, int p2) =>
        RuntimeInterop.bool_objc_msgSend_IntPtr_int(receiver.GetHandle(), selector, p1, p2);
}

