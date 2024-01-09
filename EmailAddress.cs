using System.ComponentModel;

namespace EnrolmentSystem;

public class EmailAddress {
    private string userName;
    private string domain;

    public EmailAddress ( string userName, string domain ) {
        if (!IsValid(userName, domain))
        {
            throw new ArgumentException();
        }

       this.userName = userName;
       this.domain = domain;
    }

    public static bool IsValid(string userName, string domain)
    {
        if (userName == null) return false;
        if (domain == null) return false;
        userName = userName.Trim();
        domain = domain.Trim();
        if (userName.Length == 0 || domain.Length == 0) return false;
        if (!IsValidUserName(userName)) return false;
        if ( !IsValidDomain(domain)) return false;
        return true;
    }

    private static bool IsValidUserName(string s)
    {
        var parts = s.Split(['-', '.']);

        foreach (var part in parts)
        {
            if (!IsLettersOrNumbers(part)) return false;
        }

        return true;
    }

    private static bool IsValidDomain(string s)
    {
        var parts = s.Split(['-', '.']);

        foreach (var part in parts.SkipLast(1))
        {
            if (!IsLettersOrNumbers(part)) return false;
        }

        if ( ! IsLetters(parts.Last())) return false;

        return true;
    }

    private static bool IsLettersOrNumbers(string s)
    {
        if (s.Length == 0) return false;

        foreach (var ch in s)
        {
            if (!Char.IsLetterOrDigit(ch)) return false;
        }

        return true;
    }

    private static bool IsLetters(string s)
    {
        if (s.Length == 0) return false;

        foreach (var ch in s)
        {
            if (!Char.IsLetter(ch)) return false;
        }

        return true;
    }

    /// <summary>
    /// Parses a name in the form 'userName@domain'
    /// </summary>
    /// <param name="s">The string to be parsed</param>
    /// <param name="result">Varibale that will hold the parsed email address if successful</param>
    /// <returns>Returns true if and only if the address can be parsed.</returns>
    public static bool TryParse(string? s, out EmailAddress result)
    {
        result = new EmailAddress("De", "Fault");

        if (s == null) return false;

        var parts = s.Split('@');

        if (parts.Length != 2) return false;

        if ( ! IsValid( parts[0], parts[1] ) ) return false;

        result = new EmailAddress( parts[0].Trim(), parts[1].Trim());
        return true;
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