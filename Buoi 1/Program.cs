using System;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography;

public class Student
{
    private string name;
    private double score;
    private static int totalStudents = 0;

    public Student(string name, double score)
    {
        this.name = name;
        this.score = score;
        totalStudents++;
    }

    // TODO: write instance methods here
    public string GetName()
    {
        return name;
    }

    public double Score()
    {
        return score;
    }
    public bool IsPassed()
    {
        return score >= 5.0;
    }

    public string GetClassification()
    {
        if (score >= 8.0) { return "Excellent"; }
        else if (score >= 6.5) { return "Good"; }
        else if (score >= 5.0) { return "Average"; }
        else { return "Weak"; }
    }

    // TODO: write static methods here

    public static int GetTotalStudents() { return totalStudents; }

    public static Student FindTopStudent(Student[] students)
    {
        Student TopStudent = students[0];
        for (int i = 1; i < students.Length; i++)
        {
            if (students[i].score > TopStudent.score)
            {
                TopStudent = students[i];
            }
        }
        return TopStudent;
    }

    public static double CalculateAverageScore(Student[] students)
    {
        double TotalScore = students[0].score;
        for (int i = 1; i < students.Length; i++)
        {
            TotalScore += students[i].score;
        }
        double AverageScore = TotalScore / students.Length;
        return AverageScore;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // TODO: create array of Student objects
        Student[] students =
        {
            new Student("An", 7.5),
            new Student("Binh", 8.5),
            new Student("Chi", 6.0),
            new Student("Dung", 9.0),
            new Student("Hoa", 4.5)
        };

        Console.WriteLine("Total students: " + Student.GetTotalStudents());

        foreach (Student student in students)
        {
            Console.WriteLine(
                "Name: " + student.GetName() +
                ", Classification: " + student.GetClassification() +
                ", Status: " + (student.IsPassed() ? "Passed" : "Failed")
            );
        }

        Student TopStudent = Student.FindTopStudent(students);
        Console.WriteLine("Top-scoring Student: " + TopStudent.GetName());

        Console.WriteLine("Class average score : " + Student.CalculateAverageScore(students));
    }
    // TODO: call static and instance methods as required
}