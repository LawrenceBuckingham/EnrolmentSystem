namespace EnrolmentSystem;

public class StudentRegister
{
    private List<Student> students = new();

    public IEnumerable<Student> Students
    {
        get
        {
            return students;
        }
    }


    public void Add(Student newStudent)
    {

        // Make sure student only appears once.
        if (Find(newStudent.IdNumber) != null)
        {
            throw new ArgumentException();
        }

        students.Add(newStudent);
    }

    public Student? Find(uint studentId)
    {
        foreach (var student in students)
        {
            if (student.IdNumber == studentId) return student;
        }

        return null;
    }
}