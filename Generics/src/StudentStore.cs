//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Text;

//namespace Generics.src;

//internal class StudentStore
//{
//    private List<Student> _students = new List<Student>();
//    public IReadOnlyList<Student> students => _students;

//    public void Add(Student student)
//    {
//        _students.Add(student);
//    }

//    public Student? GetById(int id)
//    {


//        foreach (var student in _students)
//        {
//            if (student.Id == id) return student;
//        }
//        return null;
//    }

//    public List<Student> GetAll() => _students;

//    public void Remove(int id)
//    {
//        Student? student = GetById(id);
//        if (student != null)
//        {
//            _students.Remove(student);
//        }

//    }
//}
