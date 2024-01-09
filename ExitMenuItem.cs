namespace UI;


public class ExitMenuException : Exception {}

public class ExitMenuItem : MenuItem
{
    public ExitMenuItem(string key, string text) : base(key, text)
    {
    }

    public override void DoAction()
    {
        throw new ExitMenuException();
    }
}