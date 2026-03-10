using System.Data.Common;
using System.Diagnostics;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Projet_1;
class Student 
{
    private static int nextId {get; set;}
    private int id {get; set;}
    public string name {get; set;}
    public float average {get; set;}
    public bool isScholarshipHolder {get; set;}

    public Student(string name, float average)
    {
        this.name = name;
        this.average = average;
        nextId++;
        id = nextId;
    }
    public Student(string name, float average, bool isScholarshipHolder)
    {
        this.name = name;
        this.average = average;
        this.isScholarshipHolder = isScholarshipHolder;
        nextId++;
        id = nextId;
    }
    public int getId()
    {
        return id;
    }
}
class Course
{
    public int id {get; set;}
    public string name {get; set;}
    public float credits {get; set;}
    public bool isMandatory {get; set;}
    public List<Student> Students {get; set;}
    public Course (string name)
    {
        this.name = name;
        id++;
    }
    public Course (string name, float credits, bool isMandatory, List<Student> Students)
    {
        this.name = name;
        this.credits = credits;
        this.isMandatory = isMandatory;
        this.Students = Students;
        id++;
    }
}
class Program
{
    // PARTIE students
    static void Main(string[] args)
    {
        static void DisplayStudent(Student s)
        {
            Console.WriteLine($"Id : {s.getId()} | Nom : {s.name} | Moyenne : {s.average} | Boursier : {s.isScholarshipHolder}");
        }

        static void DisplayStudents(List<Student> Liste)
        {
            foreach (Student s in Liste)
            {
                DisplayStudent(s);
            }
        }
        static void DisplayScholarship(List<Student> students)
        {
            foreach (Student s in students)
            {
                if (s.isScholarshipHolder)
                {
                    DisplayStudent(s);
                }
            }
        }
        static void DisplayAboveFifteen(List<Student> students)
        {
            foreach (Student s in students)
            {
                if (s.average >= 15)
                {
                    DisplayStudent(s);
                }
            }
        }
        Student s1 = new Student("Alice", 12, true);
        Student s2 = new Student("Bernard", 11, false);
        Student s3 = new Student("Emma", 18, true);
        Student s4 = new Student("Lucas", 16, false);
        Student s5 = new Student("Sarah", 13, false);
        List<Student> ListeEleves = new List<Student>();
        ListeEleves.Add(s1);
        ListeEleves.Add(s2);
        ListeEleves.Add(s3);
        ListeEleves.Add(s4);
        ListeEleves.Add(s5);
        DisplayStudents(ListeEleves);

        // PARTIE course
        static void DisplayCourse(Course c)
        {
            if (c.isMandatory)
            {
                Console.WriteLine($"Le cours obligatoire de {c.name} a {c.credits} crédit(s) sera attendu par {c.Students.Count} élève(s).");
            }
            else
            {
                Console.WriteLine($"Le cours de {c.name} a {c.credits} crédit(s) sera attendu par {c.Students.Count} élève(s).");
            }
        }
        static void DisplayCourseStudents(Course c)
        {
            DisplayCourse(c);
            Console.WriteLine("Liste élèves :");
            DisplayStudents(c.Students);
            Console.WriteLine("\n");
        }
        static void DisplayMandatoryCourses(List<Course> listCourses)
        {
            foreach (Course c in listCourses)
            {
                if (c.isMandatory)
                {
                    DisplayCourse(c);
                }
            }
        }

        Course Math = new Course("Mathématiques", 3, true, new List<Student>());
        Course Info = new Course("Informatique", 5, false, new List<Student>());
        Course Eng = new Course("Anglais", 1, false, new List<Student>());
        Course Hist = new Course("Histoire", 1, false, new List<Student>());

        List<Course> listCourses = new List<Course>();
        listCourses.Add(Math);
        listCourses.Add(Info);
        listCourses.Add(Eng);
        listCourses.Add(Hist);

        Math.Students.Add(s1);
        Math.Students.Add(s2);
        Math.Students.Add(s3);
        Info.Students.Add(s2);
        Info.Students.Add(s4);
        Eng.Students.Add(s1);
        Eng.Students.Add(s5);
        Hist.Students.Add(s4);

        DisplayCourse(Math);
        DisplayCourseStudents(Info);
        DisplayCourse(Eng);
        DisplayCourseStudents(Hist);

        DisplayMandatoryCourses(listCourses);
        Console.WriteLine("Boursiers");
        DisplayScholarship(ListeEleves);
        Console.WriteLine("Au dessus de 15");
        DisplayAboveFifteen(ListeEleves);

        Math.Students.Remove(s1);
        DisplayCourseStudents(Math);

        DisplayStudents(ListeEleves);
    }
}