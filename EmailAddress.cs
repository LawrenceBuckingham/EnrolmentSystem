namespace EnrolmentSystem;

public class EmailAddress {
    private string userName;
    private string domain;

    public EmailAddress ( string address ) {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return $"{userName}@{domain}";
    }

    public override bool Equals(object? obj)
    {
        if ( obj is EmailAddress other) {
            return string.Compare( userName, other.userName, ignoreCase: true ) == 0
            && string.Compare( domain, other.domain, ignoreCase: true ) == 0;
        }
        else {
            return false;
        }
    }
}