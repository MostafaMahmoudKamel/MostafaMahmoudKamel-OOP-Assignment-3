//using Generics.src;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Xml.Linq;


//namespace Generics;

//internal class itemStore
//{
//    private readonly List<item> _items = new List<item>();

//    public IReadOnlyList<item> items => _items;

//    public void Add(item item)
//    {
//        _items.Add(item);
//    }

//    public item? GetById(int id)
//    {
//        foreach (var item in _items)
//        {
//            if (item.Id == id)
//                return item;
//        }

//        return null;
//    }

//    public IReadOnlyList<item> GetAll()
//    {
//        return _items;
//    }

//    public void Remove(int id)
//    {
//        item? item = GetById(id);

//        if (item != null)
//        {
//            _items.Remove(item);
//        }
//    }
//}
