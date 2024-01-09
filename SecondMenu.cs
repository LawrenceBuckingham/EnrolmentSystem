namespace UI;

using static Console;

public class SecondMenu : Menu
{
    public SecondMenu(string key, string text, string title, params MenuItem[] items) : 
        base(key, text, title, items)
    {
    }

    public override void DoAction()
    {
        WriteLine("Check to see if the user is registered here. Press enter to continue...");
        ReadLine();
        
        base.DoAction();
    }
}