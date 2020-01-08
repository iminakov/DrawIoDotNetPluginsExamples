using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseDrawIoPlugin.Extensions
{
    public static class DictionaryExtensions
    {
        public static Dictionary<TKey, TValue> AddIfNotNull<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if (value != null)
            {
                dictionary.Add(key, value);
            }

            return dictionary;
        }
    }
}
