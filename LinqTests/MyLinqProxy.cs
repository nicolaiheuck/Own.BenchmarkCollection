using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqTests;

public static class MyLinqProxy
{
    public static int FastCount<T>(this IEnumerable<T> list, Func<T, bool> predicate)
    {
        return list.Where(predicate)
                   .Count();
    }
    public static int ManualCountUsingToList<T>(this IEnumerable<T> inputList, Func<T, bool> predicate)
    {
        List<T> list = inputList.ToList();

        int c = 0;
        for (int i = 0; i < list.Count(); i++)
        {
            T item = list[i];
            if (predicate.Invoke(item))
            {
                c++;
            }
        }

        return c;
    }
    public static int ManualCountUsingEnumerator<T>(this IEnumerable<T> inputList, Func<T, bool> predicate)
    {
        int c = 0;
        foreach (T item in inputList)
        {
            if (predicate.Invoke(item))
            {
                c++;
            }
        }

        return c;
    }
}