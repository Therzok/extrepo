﻿using System;
using System.Runtime.InteropServices;


namespace ObjCRuntime.Native
{
	using NSObjectSafeHandle = IntPtr;

	public static partial class Interop
	{
		internal const string LIBOBJC_DYLIB = "/usr/lib/libobjc.dylib";

		public struct objc_super
		{
			public IntPtr Handle;
			public IntPtr SuperHandle;
		}

		//		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		//		public extern static void void_objc_msgSend_IntPtr_CGPoint_ref_CGPoint(NSObjectSafeHandle receiver, IntPtr selector, IntPtr scrollView, CGPoint velocity, ref CGPoint targetContentOffset);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper")]
		public extern static void void_objc_msgSendSuper(ref objc_super receiver, IntPtr selector);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static void void_objc_msgSend_IntPtr(NSObjectSafeHandle receiver, IntPtr selector, IntPtr value);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static void void_objc_msgSend_ref_IntPtr(NSObjectSafeHandle receiver, IntPtr selector, ref IntPtr value);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static void void_objc_msgSend_out_IntPtr(NSObjectSafeHandle receiver, IntPtr selector, out IntPtr value);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static void void_objc_msgSend_IntPtr_IntPtr(NSObjectSafeHandle receiver, IntPtr selector, IntPtr p1, IntPtr p2);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static nint nint_objc_msgSend_IntPtr_nint(NSObjectSafeHandle receiver, IntPtr selector, IntPtr p1, nint p2);

		//[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		//public extern static void void_objc_msgSend_IntPtr_ref_BlockLiteral(NSObjectSafeHandle receiver, IntPtr selector, IntPtr p1, ref BlockLiteral p2);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static void void_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr(NSObjectSafeHandle receiver, IntPtr selector, IntPtr p1, IntPtr p2, IntPtr p3, IntPtr p4);

		//[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		//public extern static void void_objc_msgSend_IntPtr_IntPtr_IntPtr_NSRange_IntPtr(NSObjectSafeHandle receiver, IntPtr selector, IntPtr p1, IntPtr p2, IntPtr p3, NSRange p4, IntPtr p5);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static void void_objc_msgSend_int(NSObjectSafeHandle receiver, IntPtr selector, int value);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static void void_objc_msgSend_int_int_int_int_int_int_IntPtr(NSObjectSafeHandle receiver, IntPtr selector, int p1, int p2, int p3, int p4, int p5, int p6, IntPtr p7);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static void void_objc_msgSend_IntPtr_IntPtr_IntPtr_long_int_IntPtr(NSObjectSafeHandle receiver, IntPtr selector, IntPtr p1, IntPtr p2, IntPtr p3, long p4, int p5, IntPtr p7);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static void void_objc_msgSend_long(NSObjectSafeHandle receiver, IntPtr selector, long value);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static void void_objc_msgSend_int_int_long(NSObjectSafeHandle receiver, IntPtr selector, int p1, int p2, long p3);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static void void_objc_msgSend_long_int_long(NSObjectSafeHandle receiver, IntPtr selector, long p1, int p2, long p3);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static IntPtr IntPtr_objc_msgSend(NSObjectSafeHandle receiver, IntPtr selector);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static IntPtr IntPtr_objc_msgSend_int(NSObjectSafeHandle receiver, IntPtr selector, int p1);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static IntPtr IntPtr_objc_msgSend_long(NSObjectSafeHandle receiver, IntPtr selector, long p1);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static int int_objc_msgSend_int(NSObjectSafeHandle receiver, IntPtr selector, int p1);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static IntPtr IntPtr_objc_msgSend_ref_IntPtr(NSObjectSafeHandle receiver, IntPtr selector, ref IntPtr p1);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static IntPtr IntPtr_objc_msgSend_IntPtr(NSObjectSafeHandle receiver, IntPtr selector, IntPtr p1);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static IntPtr IntPtr_objc_msgSend_IntPtr_IntPtr(NSObjectSafeHandle receiver, IntPtr selector, IntPtr p1, IntPtr p2);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static IntPtr IntPtr_objc_msgSend_double_double(NSObjectSafeHandle receiver, IntPtr selector, double a, double b);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static IntPtr IntPtr_objc_msgSend_bool(NSObjectSafeHandle receiver, IntPtr selector, [MarshalAs(UnmanagedType.I1)] bool p1);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static double Double_objc_msgSend(NSObjectSafeHandle receiver, IntPtr selector);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static float float_objc_msgSend(NSObjectSafeHandle receiver, IntPtr selector);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool bool_objc_msgSend(NSObjectSafeHandle receiver, IntPtr selector);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static int int_objc_msgSend(NSObjectSafeHandle receiver, IntPtr selector);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static long long_objc_msgSend(NSObjectSafeHandle receiver, IntPtr selector);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static void void_objc_msgSend(NSObjectSafeHandle receiver, IntPtr selector);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static int int_objc_msgSend_IntPtr(NSObjectSafeHandle receiver, IntPtr selector, IntPtr p1);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool bool_objc_msgSend_IntPtr(NSObjectSafeHandle receiver, IntPtr selector, IntPtr p1);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool bool_objc_msgSend_IntPtr_int(NSObjectSafeHandle receiver, IntPtr selector, IntPtr p1, int p2);

		/*
		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static IntPtr IntPtr_objc_msgSend_CGSize(NSObjectSafeHandle receiver, IntPtr selector, CGSize p1);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static CGPoint CGPoint_objc_msgSend(NSObjectSafeHandle receiver, IntPtr selector);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static CGSize CGSize_objc_msgSend(NSObjectSafeHandle receiver, IntPtr selector);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static void void_objc_msgSend_CGRect(NSObjectSafeHandle receiver, IntPtr selector, CGRect p1);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static CGRect CGRect_objc_msgSend(NSObjectSafeHandle receiver, IntPtr selector);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static CGRect CGRect_objc_msgSend_int(NSObjectSafeHandle receiver, IntPtr selector, int p1);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static CGRect CGRect_objc_msgSend_IntPtr(NSObjectSafeHandle receiver, IntPtr selector, IntPtr p1);

#if !__TVOS__
		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static CGRect CGRect_objc_msgSend_MKCoordinateRegion_IntPtr(NSObjectSafeHandle receiver, IntPtr selector, MKCoordinateRegion p1, IntPtr p2);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static CGRect CGRect_objc_msgSend_MKMapRect(NSObjectSafeHandle receiver, IntPtr selector, MKMapRect p1);
#endif // !__TVOS__

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static CGRect CGRect_objc_msgSend_CGRect(NSObjectSafeHandle receiver, IntPtr selector, CGRect p1);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static CGRect CGRect_objc_msgSend_CGRect_int(NSObjectSafeHandle receiver, IntPtr selector, CGRect p1, int p2);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static CGRect CGRect_objc_msgSend_CGRect_IntPtr(NSObjectSafeHandle receiver, IntPtr selector, CGRect p1, IntPtr p2);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static CGRect CGRect_objc_msgSend_CGRect_CGRect_float(NSObjectSafeHandle receiver, IntPtr selector, CGRect p1, CGRect p2, float p3);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static CGRect CGRect_objc_msgSend_CGRect_CGRect_CGRect(NSObjectSafeHandle receiver, IntPtr selector, CGRect p1, CGRect p2, CGRect p3);

#if !__WATCHOS__
		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static Matrix3 Matrix3_objc_msgSend(NSObjectSafeHandle receiver, IntPtr selector);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static CATransform3D CATransform3D_objc_msgSend(NSObjectSafeHandle receiver, IntPtr selector);
#endif // !__WATCHOS__

#if !__TVOS__
		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend_stret")]
		public extern static void CGRect_objc_msgSend_stret_MKMapRect(out CGRect buf, NSObjectSafeHandle receiver, IntPtr selector, MKMapRect p1);
#endif // !__TVOS__

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend_stret")]
		public extern static void CGRect_objc_msgSend_stret(out CGRect buf, NSObjectSafeHandle receiver, IntPtr selector);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend_stret")]
		public extern static void CGPoint_objc_msgSend_stret(out CGPoint buf, NSObjectSafeHandle receiver, IntPtr selector);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend_stret")]
		public extern static void CGSize_objc_msgSend_stret(out CGSize buf, NSObjectSafeHandle receiver, IntPtr selector);

#if !__WATCHOS__
		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend_stret")]
		public extern static void Matrix3_objc_msgSend_stret(out Matrix3 buf, NSObjectSafeHandle receiver, IntPtr selector);
#endif // !__WATCHOS__

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend_stret")]
		public extern static void CGRect_objc_msgSend_stret_int(out CGRect buf, NSObjectSafeHandle receiver, IntPtr selector, int p1);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend_stret")]
		public extern static void CGRect_objc_msgSend_stret_IntPtr(out CGRect buf, NSObjectSafeHandle receiver, IntPtr selector, IntPtr p1);

#if !__TVOS__
		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend_stret")]
		public extern static void CGRect_objc_msgSend_stret_MKCoordinateRegion_IntPtr(out CGRect buf, NSObjectSafeHandle receiver, IntPtr selector, MKCoordinateRegion p1, IntPtr p2);
#endif // !__TVOS__

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend_stret")]
		public extern static void CGRect_objc_msgSend_stret_CGRect(out CGRect buf, NSObjectSafeHandle receiver, IntPtr selector, CGRect p1);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend_stret")]
		public extern static void CGRect_objc_msgSend_stret_CGRect_int(out CGRect buf, NSObjectSafeHandle receiver, IntPtr selector, CGRect p1, int p2);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend_stret")]
		public extern static void CGRect_objc_msgSend_stret_CGRect_IntPtr(out CGRect buf, NSObjectSafeHandle receiver, IntPtr selector, CGRect p1, IntPtr p2);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend_stret")]
		public extern static void CGRect_objc_msgSend_stret_CGRect_CGRect_float(out CGRect buf, NSObjectSafeHandle receiver, IntPtr selector, CGRect p1, CGRect p2, float p3);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend_stret")]
		public extern static void CGRect_objc_msgSend_stret_CGRect_CGRect_CGRect(out CGRect buf, NSObjectSafeHandle receiver, IntPtr selector, CGRect p1, CGRect p2, CGRect p3);

#if !__WATCHOS__
		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend_stret")]
		public extern static void CATransform3D_objc_msgSend_stret(out CATransform3D buf, NSObjectSafeHandle receiver, IntPtr selector);
#endif // !__WATCHOS__
		*/

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static void void_objc_msgSend_int_IntPtr_IntPtr(NSObjectSafeHandle receiver, IntPtr selector, int p1, ref IntPtr p2, out IntPtr p3);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static void void_objc_msgSend_int_IntPtr_IntPtr(NSObjectSafeHandle receiver, IntPtr selector, int p1, IntPtr p2, IntPtr p3);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static void void_objc_msgSend_int_int_int(NSObjectSafeHandle receiver, IntPtr selector, int p1, ref int p2, out int p3);

		[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		public extern static void void_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr(NSObjectSafeHandle receiver, IntPtr selector, ref IntPtr p1, ref IntPtr p2, ref IntPtr p3, ref IntPtr p4, ref IntPtr p5, ref IntPtr p6, ref IntPtr p7);

		//[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
		//public extern static void void_objc_msgSend_IntPtr_IntPtr_BlockLiteral(NSObjectSafeHandle receiver, IntPtr selector, IntPtr p1, IntPtr p2, ref BlockLiteral p3);
	}
}

