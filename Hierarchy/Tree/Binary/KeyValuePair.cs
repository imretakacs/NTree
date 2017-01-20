using System;

namespace Hierarchy.Tree.Binary
{
    public struct KeyValuePair<TKey, TValue> : IComparable
        where TKey : IComparable
    {
        public KeyValuePair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        public int CompareTo(object obj)
        {
            KeyValuePair<TKey, TValue> compareTo;
            try
            {
                compareTo = (KeyValuePair<TKey, TValue>)obj;
            }
            catch (InvalidCastException ex)
            {
                throw new InvalidCastException($"KeyValuePair can be compared only with KeyValuePair type, current type is: {obj.GetType()}", ex);
            }
            return Key.CompareTo(compareTo.Key);
        }

        public TKey Key { get; private set; }

        public TValue Value { get; private set; }
    }
}