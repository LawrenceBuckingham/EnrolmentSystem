namespace EnrolmentSystem;

public class Name
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
        return givenNames != null &&
            familyNames != null &&
            (givenNames.Trim().Length > 0 || familyNames.Trim().Length > 0)
            ;
    }

    public static bool TryParse(string? s, out Name result)
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return $"{GivenNames}{(GivenNames.Length == 0 ? "" : " ")}{FamilyNames}";
    }
}