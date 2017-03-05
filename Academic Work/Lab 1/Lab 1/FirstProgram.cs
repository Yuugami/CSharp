using System;

public class FirstProgram
{
    public static void Main()
    {
        // Create a string varaiable and initialize it to an empty string
        // Note: This is NOT a space.
        // It is two double quotes right next to each other
        string name = "";

        // Display a prompt to the user
        Console.Write("What is your name? ");
        Console.Beep();

        // Capture the user's response
        name = Console.ReadLine();

        /* Display a string literal combined with the value of the string
         varuable. What does the "\n" do? It stands for newline. 
         Jumps to a new line */
        Console.Write("Hello " + name + "\n");

        // Waits for user to press a key
        // Allows us to read what was displayed
        Console.Read();

    }
}