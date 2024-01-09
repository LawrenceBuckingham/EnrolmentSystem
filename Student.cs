using System.ComponentModel.DataAnnotations;

namespace EnrolmentSystem;

public class Student : IComparable {
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

    public int CompareTo(object? obj)
    {
        if ( obj is Student other ) {
            int result = this.Name.CompareTo(other.Name);

            if ( result == 0 ) {
                result = this.IdNumber.CompareTo(other.IdNumber);
            }

            return result;
        }
        else {
            return +1;
        }
    }
}