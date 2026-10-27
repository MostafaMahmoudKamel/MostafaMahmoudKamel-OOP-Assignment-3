
using System;
using System.Collections.Generic;

namespace Generics.src;

public static class EnumerableExtensions
{
    // R1: Return only the items belonging to the requested page
    public static IEnumerable<T> Page<T>(
        this IEnumerable<T> source,
        int pageNumber,
        int pageSize)
    {
        

        int startIndex = (pageNumber - 1) * pageSize;
        int currentIndex = 0;
        int returnedItems = 0;

        foreach (T item in source)
        {
            if (currentIndex >= startIndex && returnedItems < pageSize)
            {
                yield return item;
                returnedItems++;
            }

            if (returnedItems == pageSize)
                yield break;

            currentIndex++;
        }
    }

    // R2: Find an item by its Id
    public static T? FindById<T>(
        this IEnumerable<T> source,
        int id)
        where T : IHasId
    {
        foreach (T item in source)
        {
            if (item.Id == id)
                return item;
        }

        return default;
    }

    // R3: Convert items into a read-only dictionary keyed by Id
    public static IReadOnlyDictionary<int, T> ToIdDictionary<T>(
        this IEnumerable<T> source)
        where T : IHasId
    {
        Dictionary<int, T> dictionary = new Dictionary<int, T>();

        foreach (T item in source)
        {
            if (dictionary.ContainsKey(item.Id))
            {
                throw new ArgumentException(
                    $"An item with ID {item.Id} already exists.");
            }

            dictionary.Add(item.Id, item);
        }

        return dictionary;
    }
}
