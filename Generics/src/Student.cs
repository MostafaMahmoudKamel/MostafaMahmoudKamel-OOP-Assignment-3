using System;
using System.Collections.Generic;
using System.Text;

namespace Generics.src;

public class Student: IHasId
{
    public Student(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { set; get; }
    public string Name { set; get; }
}
