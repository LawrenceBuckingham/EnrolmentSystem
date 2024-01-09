namespace EnrolmentSystem;
using static Console;

public delegate bool Parser<T>( string ? s, out T result);

public static class Helpers {
    public static T Read<T>( 
        string prompt, 
        string formatError,
        Parser<T> tryParse
    ) {
        T result;

        while (true) {
            WriteLine(prompt);

            string ? userInput = ReadLine();

            if ( userInput is null ) throw new EndOfStreamException();

            if ( tryParse( userInput, out result ) ) {
                break;
            }

            WriteLine(formatError);
        }

        return result;
    }
}