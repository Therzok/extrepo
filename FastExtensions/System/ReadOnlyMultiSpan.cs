using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System;
    /*
    /// <summary>
    /// ReadOnlyMultiSpan is a way to represent concatenated <see cref="ReadOnlySpan{T}"/>.
    /// </summary>
    [DebuggerDisplay("{ToString(),raw}")]
    public readonly ref struct ReadOnlyMultiSpan<T>
    {
        readonly ReadOnlySpan<T> _left;
        readonly ReadOnlySpan<T> _right;

        /// <summary>
        /// Creates a new span-like type representing the concatenated spans.
        /// </summary>
        /// <param name="left">The leading span</param>
        /// <param name="right">The trailing span</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ReadOnlyMultiSpan(ReadOnlySpan<T> left, ReadOnlySpan<T> right)
        {
            _left = left;
            _right = right;
        }

        /// <summary>
        /// Returns the specified element of the read-only multispan.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException">
        /// Thrown when index less than 0 or index greater than or equal to Length
        /// </exception>
        public ref readonly T this[int index]
        {
            get
            {
                int end = _left.Length;
                if (index < end)
                {
                    return ref _left[index];
                }

                return ref _right[index - end];
            }
        }

        public int Length
        {
            get => _left.Length + _right.Length;
        }

        public bool IsEmpty
        {
            get => 0 >= Length;
        }

        /// <summary>
        /// This method is not supported as spans cannot be boxed. To compare two spans, use operator==.
        /// <exception cref="System.NotSupportedException">
        /// Always thrown by this method.
        /// </exception>
        /// </summary>
        [Obsolete("Equals() on ReadOnlySpan has will always throw an exception. Use the equality operator instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) =>
            throw new NotSupportedException("Equals() on Span and ReadOnlySpan is not supported. Use operator== instead.");

        /// <summary>
        /// This method is not supported as spans cannot be boxed.
        /// <exception cref="System.NotSupportedException">
        /// Always thrown by this method.
        /// </exception>
        /// </summary>
        [Obsolete("GetHashCode() on ReadOnlySpan will always throw an exception.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() =>
            throw new NotSupportedException("GetHashCode() on Span and ReadOnlySpan is not supported. Use operator== instead.");

        /// <summary>
        /// Returns a 0-length read-only span whose base is the null pointer.
        /// </summary>
        public static ReadOnlyMultiSpan<T> Empty => default;

        /// <summary>Gets an enumerator for this span.</summary>
        public Enumerator GetEnumerator() => new Enumerator(this);

        /// <summary>Enumerates the elements of a <see cref="ReadOnlySpan{T}"/>.</summary>
        public ref struct Enumerator
        {
            /// <summary>The span being enumerated.</summary>
            private readonly ReadOnlyMultiSpan<T> _span;
            private int _index;

            /// <summary>Initialize the enumerator.</summary>
            /// <param name="span">The span to enumerate.</param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal Enumerator(ReadOnlyMultiSpan<T> span)
            {
                _span = span;
                _index = -1;
            }

            /// <summary>Advances the enumerator to the next element of the span.</summary>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext()
            {
                int index = _index + 1;
                if (index < _span.Length)
                {
                    _index = index;
                    return true;
                }

                return false;
            }

            /// <summary>Gets the element at the current position of the enumerator.</summary>
            public ref readonly T Current
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => ref _span[_index];
            }
        }
    }*/


