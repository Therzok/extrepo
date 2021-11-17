// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using Microsoft.CodeAnalysis;

namespace FastExtensions.Experimental;

/// <summary>
/// Represents a single item or many items (including none).
/// </summary>
/// <remarks>
/// Used when a collection usually contains a single item but sometimes might contain multiple.
/// </remarks>
internal readonly struct OneOrMany<T>
    where T : notnull
{
    public static readonly OneOrMany<T> Empty = new OneOrMany<T>(ImmutableArray<T>.Empty);

    private readonly T? _one;
    private readonly ImmutableArray<T> _many;

    public OneOrMany(T one)
    {
        _one = one;
        _many = default;
    }

    public OneOrMany(ImmutableArray<T> many)
    {
        if (!many.IsDefault)
        {
            _one = default;
            _many = many;
        }
        else
        {
            throw new ArgumentNullException(nameof(many));
        }
    }

    [MemberNotNullWhen(true, nameof(_one))]
    private bool HasOne =>
        _many.IsDefault;

    public T this[int index]
    {
        get
        {
            if ((uint)index >= (uint)Count)
            {
                throw new IndexOutOfRangeException($"Index was {index}");
            }

            return HasOne ? _one : _many[index];
        }
    }

    public int Count =>
        HasOne ? 1 : _many.Length;

    public bool IsEmpty =>
        Count == 0;

    public OneOrMany<T> Add(T one)
    {
        if (IsEmpty)
        {
            return new(one);
        }

        var array = HasOne ? ImmutableArray.Create(_one, one) : _many.Add(one);
        return new(array);
    }

    public bool Contains<TOther>(TOther item)
        where TOther : notnull, IEquatable<T>
    {
        var iter = GetEnumerator();
        while (iter.MoveNext())
        {
            if (item.Equals(iter.Current))
            {
                return true;
            }
        }

        return false;
    }

    public OneOrMany<T> RemoveAll<TOther>(TOther item)
        where TOther : notnull, IEquatable<T>
    {
        if (HasOne)
        {
            return item.Equals(_one) ? Empty : this;
        }

        var builder = ImmutableArray.CreateBuilder<T>(_many.Length);
        var iter = GetEnumerator();
        while (iter.MoveNext())
        {
            if (!item.Equals(iter.Current))
            {
                builder.Add(iter.Current);
            }
        }

        return builder.Count == Count ? this : new OneOrMany<T>(builder.ToImmutable());
    }

    public OneOrMany<TResult> Select<TResult>(Func<T, TResult> selector)
        where TResult : notnull
    {
        return HasOne ?
            OneOrMany.Create(selector(_one)) :
            OneOrMany.Create(_many.SelectAsArray(selector));
    }

    public OneOrMany<TResult> Select<TResult, TArg>(Func<T, TArg, TResult> selector, TArg arg)
        where TResult : notnull
    {
        return HasOne ?
            OneOrMany.Create(selector(_one, arg)) :
            OneOrMany.Create(_many.SelectAsArray(selector, arg));
    }

    public T? FirstOrDefault(Func<T, bool> predicate)
    {
        if (HasOne)
        {
            return predicate(_one) ? _one : default;
        }

        foreach (var item in _many)
        {
            if (predicate(item))
            {
                return item;
            }
        }

        return default;
    }

    public T? FirstOrDefault<TArg>(Func<T, TArg, bool> predicate, TArg arg)
    {
        if (HasOne)
        {
            return predicate(_one, arg) ? _one : default;
        }

        foreach (var item in _many)
        {
            if (predicate(item, arg))
            {
                return item;
            }
        }

        return default;
    }

    public Enumerator GetEnumerator() =>
        new(this);

    internal struct Enumerator
    {
        private readonly OneOrMany<T> _collection;
        private int _index;

        internal Enumerator(OneOrMany<T> collection)
        {
            _collection = collection;
            _index = -1;
        }

        public bool MoveNext()
        {
            return ++_index < _collection.Count;
        }

        public T Current
        {
            get => _collection[_index];
        }
    }
}

internal static class OneOrMany
{
    public static OneOrMany<T> Create<T>(T one)
        where T : notnull
    {
        return new OneOrMany<T>(one);
    }

    public static OneOrMany<T> Create<T>(ImmutableArray<T> many)
        where T : notnull
    {
        return new OneOrMany<T>(many);
    }
}
