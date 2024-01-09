using EnrolmentSystem;
using static System.Console;

namespace UI;

public class ListEnrolledStudents : MenuItem
{
    private StudentRegister students;

    public ListEnrolledStudents(string key, string text, StudentRegister students) : base(key, text)
    {
        this.students = students;
    }

    public override void DoAction()
    {
        List<Student> allStudents = new(students.Students);

        if (allStudents.Count == 0)
        {
            WriteLine("No data!");
        }
        else
        {
            allStudents.Sort();

            WriteLine("\nStudent List\n");
            WriteLine("Num\tID\tName\tEmail address");

            int number = 0;

            foreach (var student in allStudents)
            {
                number++;
                WriteLine($"{number}\t{student.IdNumber}\t{student.Name}\t{student.EmailAddress}");
            }

        }
        
        WriteLine();
    }
}