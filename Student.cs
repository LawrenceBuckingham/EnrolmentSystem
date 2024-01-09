using System.ComponentModel.DataAnnotations;

namespace EnrolmentSystem;

public class Student {
    public uint IdNumber { get; }

    public Name Name { get; }

    public EmailAddress EmailAddress { get; }

    public Student( uint idNumber, Name name, EmailAddress emailAddress ) {
        // Validation on idNumber
        IdNumber = idNumber;
        Name = name;
        EmailAddress = emailAddress;
    }

    public override string ToString()
    {
        return $"{Name},{EmailAddress}";
    }
}