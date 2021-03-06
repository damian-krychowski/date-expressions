﻿using System;
using System.Collections.Generic;

namespace DateExpressions.Generated.Infrastructure
{
    public sealed class Option<T>
    {
        private bool HasItem { get; }
        private T Item { get; }

        private Option()
        {
            this.HasItem = false;
        }

        private Option(T item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            this.HasItem = true;
            this.Item = item;
        }

        public static Option<T> None { get; } = new Option<T>();

        public static Option<T> Some(T value) => new Option<T>(value);

        public static Option<T> From(T value) => value == null ? None : Some(value);

        public static Option<T> From<TStruct>(TStruct? value) where TStruct : struct, T
        {
            return value.HasValue ? Some(value.Value) : None;
        }

        public Option<TResult> Select<TResult>(Func<T, TResult> selector)
        {
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            return this.HasItem
                ? Option<TResult>.Some(selector(this.Item))
                : Option<TResult>.None;
        }

        public Option<TResult> Select<TResult>(Func<T, Option<TResult>> selector)
        {
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            return this.HasItem
                ? selector(this.Item)
                : Option<TResult>.None;
        }

        public TResult Match<TResult>(Func<T, TResult> some, Func<TResult> none)
        {
            if (some == null) throw new ArgumentNullException(nameof(some));
            if (none == null) throw new ArgumentNullException(nameof(none));

            return this.HasItem ? some(Item) : none();
        }

        public bool TryGet(out T item)
        {
            if (HasItem)
            {
                item = Item;
                return true;
            }

            item = default(T);
            return false;
        }

        public IEnumerable<T> ToEnumerable()
        {
            if (HasItem) yield return Item;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Option<T>;
            if (other == null)
                return false;

            return object.Equals(this.Item, other.Item);
        }

        public override int GetHashCode()
        {
            return this.HasItem ? this.Item.GetHashCode() : 0;
        }
    }
}
