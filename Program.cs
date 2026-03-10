using System.Data.Common;
using System.Diagnostics;
using System.Collections.Generic;

namespace Projet_1;
class Student 
{
    public int nextId { get; set;}
    public int id {get; set;}
    public string name {get; set;}
    public float average {get; set;}
    public bool isScholarshipHolder {get; set;}

    public Student(string name, float average)
    {
        this.name = name;
        this.average = average;
        id++;
    }
    public Student(string name, float average, bool isScholarshipHolder)
    {
        this.name = name;
        this.average = average;
        this.isScholarshipHolder = isScholarshipHolder;
        id++;
    }
}
class Program
{
    static void Main(string[] args)
    {
        static void DisplayStudent(Student s)
        {
            Console.WriteLine($"Nom : {s.name} | Moyenne : {s.average} | Boursier : {s.isScholarshipHolder}");
        }

        static void DisplayStudents(List<Student> Liste)
        {
            foreach (Student s in Liste)
            {
                DisplayStudent(s);
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
        Console.WriteLine("Hello, World!");
    }
}