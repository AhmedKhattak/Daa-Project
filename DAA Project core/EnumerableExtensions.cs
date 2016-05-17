using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DAA_Project_core
{
    static class EnumerableExtensions
    {
        public static IEnumerable<IEnumerable<T>> Partition<T>(this IEnumerable<T> source, int size)
        {
            T[] list = null;
            int index = 0;
            foreach (T iteratorVariable2 in source)
            {
                if (list == null)
                {
                    list = new T[size];
                }
                list[index] = iteratorVariable2;
                index++;
                if (index == size)
                {
                    yield return new ReadOnlyCollection<T>(list);
                    list = null;
                    index = 0;
                }
            }
            if (list == null)
            {
                yield break;
            }
            Array.Resize<T>(ref list, index);
            yield return new ReadOnlyCollection<T>(list);
        }
    }
}
