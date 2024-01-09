namespace EnrolmentSystem;

public class Name: IComparable
{
    public string GivenNames { get; }

    public string FamilyNames { get; }

    public Name(string givenNames, string familyNames)
    {
        if (!IsValid(givenNames, familyNames))
        {
            throw new ArgumentException();
        }

        GivenNames = givenNames;
        FamilyNames = familyNames;
    }

    public static bool IsValid(string givenNames, string familyNames)
    {
        if (givenNames == null) return false;
        if (familyNames == null) return false;
        givenNames = givenNames.Trim();
        familyNames = familyNames.Trim();
        if (givenNames.Length == 0 && familyNames.Length == 0) return false;
        if (givenNames.Length > 0 && !IsValidNames(givenNames)) return false;
        if (familyNames.Length > 0 && !IsValidNames(familyNames)) return false;
        return true;
    }

    // Law' ' ' '-'-'rence
    private static bool IsValidNames(string s)
    {
        var parts = s.Split(['\'', '-', ' ']);

        foreach (var part in parts)
        {
            if (!IsLetters(part)) return false;
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
    /// Parses a name in the form 'family names, given names'
    /// </summary>
    /// <param name="s">The string to be parsed</param>
    /// <param name="result">Varibale that will hold the parsed name if successful</param>
    /// <returns>Returns true if and only if the name can be parsed.</returns>
    public static bool TryParse(string? s, out Name result)
    {
        result = new Name("De", "Fault");

        if (s == null) return false;

        var parts = s.Split(',');

        if (parts.Length != 2) return false;

        if ( ! IsValid( parts[1], parts[0] ) ) return false;

        result = new Name( parts[1].Trim(), parts[0].Trim());
        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"{GivenNames}{(GivenNames.Length == 0 ? "" : " ")}{FamilyNames}";
    }

    public int CompareTo(object? obj)
    {
        if ( obj is Name other ) {
            int result = this.FamilyNames.CompareTo(other.FamilyNames);

            if ( result == 0) {
                result = this.GivenNames.CompareTo(other.GivenNames);
            }

            return result;
        }
        else {
            return +1;
        }
    }
}