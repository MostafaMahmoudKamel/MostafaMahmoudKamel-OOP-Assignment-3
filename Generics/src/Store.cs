using System;
using System.Collections.Generic;
using System.Text;

namespace Generics.src;

internal class Store<T> where T : IHasId
{
    private readonly Dictionary<int, T> _items = new Dictionary<int, T>();

    public IReadOnlyDictionary<int, T> items => _items;

    public void Add(T item)
    {
        _items.Add(item.Id,item);
    }

    public T? GetById(int id)
    {
        foreach (var item in _items)
        {
            if (item.Key == id)
                return item.Value;
        }

        return default;
    }

    public IReadOnlyCollection<T> GetAll()
    {
        return _items.Values;
    }

    public void Remove(int id)
    {

        _items.Remove(id);

    }
}
