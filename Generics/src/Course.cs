using System;
using System.Collections.Generic;
using System.Text;

namespace Generics.src;

public class Course :IHasId
{
    public Course(int id, string title)
    {
        Id = id;
        Title = title;
    }

    public int Id { set; get; }
    public string Title { set; get; }
    public decimal Price { set; get; }
}
