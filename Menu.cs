namespace UI;
using static System.Console;

public class Menu : MenuItem
{
    public string Title { get; }
    public MenuItem[] items;

    public Menu(string key, string text, string title, params MenuItem[] items) : base(key, text)
    {
        this.Title = title;
        this.items = new MenuItem[items.Length];
        Array.Copy(items, this.items, items.Length);
    }

    public override void DoAction()
    {
        while (true)
        {
            WriteLine($"\n{Title}\n");
            WriteLine("Please select an option from the following list:\n");

            foreach (var item in items)
            {
                WriteLine(item);
            }

            WriteLine("\n?");

            string? userInput = ReadLine();

            if (userInput is null) throw new EndOfStreamException();

            userInput = userInput.Trim();

            MenuItem? selectedItem = null;

            foreach (var item in items)
            {
                if (string.Compare(userInput, item.Key, ignoreCase: true) == 0)
                {
                    selectedItem = item;
                    break;
                }
            }

            if (selectedItem is not null)
            {
                try
                {
                    selectedItem.DoAction();
                }
                catch (ExitMenuException)
                {
                    break;
                }
            }
            else
            {
                WriteLine("Please choose a valid option.");
            }
        }
    }
}
