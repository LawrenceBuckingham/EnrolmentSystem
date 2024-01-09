namespace UI;

using System.Net;
using EnrolmentSystem;
using static Console;

public class RegistrationMenuItem : MenuItem
{
    private StudentRegister students;

    public RegistrationMenuItem(string key, string text, StudentRegister students) : base(key, text)
    {
        this.students = students;
    }

    public override void DoAction()
    {
        WriteLine("\nStudent Registration Dialog\n");
        uint idNumber = Helpers.Read<uint>("Student Id Number:", "Please provide numeric input", uint.TryParse);

        Name name = Helpers.Read<Name>("Student Name (Family names, given names):", "Valid names consist of letters, spaces, apostrophes and hyphens, and start and finish with a letter.", Name.TryParse);
        // TODO: proper email address handling

        EmailAddress address = Helpers.Read<EmailAddress>("Student Email Address (user@domain):", "Valid email addresses consist of two part separated by '@', according to normal conventions.", EmailAddress.TryParse);

        Student? existingRecord = students.Find(idNumber);

        if (existingRecord is not null)
        {
            WriteLine("There is already a student with that id number. Operation cancelled.");
        }
        else
        {
            Student newStudent = new(idNumber, name, address);

            students.Add(newStudent);

            WriteLine( $"Successfully added student {newStudent} to enrolment system." );
        }
    }
}