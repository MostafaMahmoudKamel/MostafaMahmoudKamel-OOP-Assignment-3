using Generics.src;

namespace Generics;

public class Program
{
    static void Main(string[] args)
    {
        // 1.Store<Student>
        Store<Student> studentStore = new Store<Student>();

        studentStore.Add(new Student(1, "Mostafa"));
        studentStore.Add(new Student(2, "Mahmoud"));
        studentStore.Add(new Student(3, "Kamel"));
        studentStore.Add(new Student(4, "Elsayed"));
        studentStore.Add(new Student(5, "Mohamed"));

        // 2. Store<Course> 
        Store<Course> courseStore = new Store<Course>();

        courseStore.Add(new Course(101, "C#"));
        courseStore.Add(new Course(102, "SQL"));
        courseStore.Add(new Course(103, "OOP"));

        // 3. Get one student and one course by ID
        Student? student = studentStore.GetById(2);
        Course? course = courseStore.GetById(102);

        Console.WriteLine($"Student: {student?.Name}");
        Console.WriteLine($"Course: {course?.Title}");

        // 4. Try to add a student with a duplicate ID
        try
        {
            studentStore.Add(new Student(2, "Another Mona"));
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        // 5. Print page 2, with 2 students per page
        Console.WriteLine("\nPage 2 of students:");

        foreach (Student item in studentStore.items.Values.Page(2, 2))
        {
            Console.WriteLine($"{item.Id}: {item.Name}");
        }

        // 6. Call FindById on a plain List<Course>
        List<Course> courses = new List<Course>
        {
            new Course(201, "Algorithms"),
            new Course(202, "Databases"),
            new Course(203, "Networking")
        };

        Course? foundCourse = courses.FindById(202);
        Console.WriteLine($"\nFound course: {foundCourse?.Title}");

    }
}

