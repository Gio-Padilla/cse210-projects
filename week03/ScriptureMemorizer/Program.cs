using System;
using System.ComponentModel;

// Shows creativity and exceeds core requirements.
// For this, I did a couple of things.
// 1) I made it so that it hides random words based off of the ones that are not hidden. It will not atempt to hide the words that are already hidden.
// 2) I also allowed it so that the user can reset the program without restarting it. In short, it will show all of the hidden words by typing 'Reset'.

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Provers", 3, 5, 6);
        string scriptureText = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
        Scripture scripture = new Scripture(reference, scriptureText);

        string inputText = "";

        while (inputText != "quit")
        {
            Console.Clear();
            Console.WriteLine("Welcome to the scripture memorizer program.");
            Console.WriteLine("Please click enter in order to hide 3 words, or type 'Quit' to close the program.");
            Console.WriteLine("Type 'Reset' to show all words again.");
            Console.WriteLine(scripture.GetDisplayText());
            if (inputText != "")
            {
                Console.WriteLine("An unknown command was received.");
                inputText = "";
            }
            if (scripture.AreAllHidden() == true)
            {
                Console.WriteLine("There are no more words that can be removed. Press enter to quit or type 'reset' to show all words again.");
            }
            inputText = Console.ReadLine().ToLower();
            if (scripture.AreAllHidden() == true)
            {
                if (inputText == "")
                {
                    inputText = "quit";
                }
            }
            scripture.HideRandomWords(3);
            if (inputText == "reset")
            {
                scripture.Reset();
                inputText = "";
            }
        }
    }
}