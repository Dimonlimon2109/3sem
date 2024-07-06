using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_09
{
    public class MyDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private Dictionary<TKey, TValue> innerDictionary = new Dictionary<TKey, TValue>();

        public static int id { get; set; }
        public TValue this[TKey key]
        {
            get
            {
                if (innerDictionary.ContainsKey(key))
                {
                    return innerDictionary[key];
                }
                throw new KeyNotFoundException();
            }
            set
            {
                innerDictionary[key] = value;
            }
        }

        public int Count => innerDictionary.Count;

        public bool IsReadOnly => ((IDictionary<TKey, TValue>)innerDictionary).IsReadOnly;

        public ICollection<TKey> Keys => innerDictionary.Keys;

        public ICollection<TValue> Values => innerDictionary.Values;

        public void Add(TKey key, TValue value)
        {
            innerDictionary.Add(key, value);
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            ((IDictionary<TKey, TValue>)innerDictionary).Add(item);
        }

        public void Print()
        {
            foreach (var item in innerDictionary)
            {
                Console.WriteLine($"Ключ: {item.Key}, {item.Value}");
            }
        }
        public void Clear()
        {
            innerDictionary.Clear();
            id = 0;
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return ((IDictionary<TKey, TValue>)innerDictionary).Contains(item);
        }

        public bool ContainsKey(TKey key)
        {
            return innerDictionary.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            ((IDictionary<TKey, TValue>)innerDictionary).CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return innerDictionary.GetEnumerator();
        }

        public bool Remove(TKey key)
        {
            return innerDictionary.Remove(key);
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return ((IDictionary<TKey, TValue>)innerDictionary).Remove(item);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return innerDictionary.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
