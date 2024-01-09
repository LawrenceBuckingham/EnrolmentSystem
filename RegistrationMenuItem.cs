namespace UI;

using System.Net;
using EnrolmentSystem;
using static Console;

public class RegistrationMenuItem : MenuItem
{
    private StudentRegister students;

    public RegistrationMenuItem(string key, string text, StudentRegister students ) : base(key, text)
    {
        this.students = students;
    }

    public override void DoAction()
    {
        WriteLine("\nStudent Registration Dialog\n");
        uint idNumber = Helpers.Read<uint>( "Student Id Number:", "Please provide numeric input", uint.TryParse );

        // Name = Helpers.Read<Name> ();
    }
}