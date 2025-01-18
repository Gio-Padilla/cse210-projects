using System;

// Shows creativity and exceeds core requirements
// For this, I did a couple of this that were more small than large.
// 1) When saving the prompt, I made it so that it saves it with the time it was saved, just in case the user wants to answer multiple throughout the day.
// 2) I made it so that it clears the console in orderr to hav3e a more ease of navigation.
// 3) In the entry class, I made it so that it converts the saved file lines back and forth from its file lines since it deals directly with entries. Refering to ConvertLineToVariables(string lineString) and ReturnConvertedEntryToLine()

class Program
{
    static void Main(string[] args)
    {   
        PromptGenerator promptGenerator = new PromptGenerator();
        Journal journal = new Journal();
        string response = "";

        while (response == "")
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Journal Program!");
            Console.WriteLine("Please select one of the options.");
            Console.WriteLine("1. Answer new prompt for the day");
            Console.WriteLine("2. Display all answered prompts");
            Console.WriteLine("3. Load a saved file");
            Console.WriteLine("4. Save to a file or to new file");
            Console.WriteLine("5. Close program");
            Console.WriteLine("-----------------------------------");

            List<string> possibleResponse = new List<string>() {"1", "2", "3", "4", "5"};

            while (!possibleResponse.Contains(response))
            {
                Console.Write("Choose an option 1 to 5: ");
                response = Console.ReadLine();

                if (!possibleResponse.Contains(response))
                {
                    Console.WriteLine("Invalid response. Please try again.");
                }
            }

            if (response == "1")
            {
                Entry newEntry = new Entry();
                Console.Clear();
                Console.WriteLine("Here is you prompt for today:");
                newEntry._promptText = promptGenerator.ReturnPrompt();
                Console.WriteLine(newEntry._promptText);
                newEntry._entryText = Console.ReadLine();
                newEntry._date = DateTime.Now.ToString("MMMM dd, yyyy @ hh:mm tt");
                journal.AddEntry(newEntry);
                Console.WriteLine("Your entry has been added to the your Journal.");
                Console.WriteLine("Press any key to go back to the main menu.");
                Console.ReadKey();
                response = "";
            }

            if (response == "2")
            {
                Console.Clear();
                Console.WriteLine("Here are all of the entries for your Journal.");
                Console.WriteLine("---------------------------------------------");
                journal.DisplayAll();
                Console.WriteLine("Press any key to go back to the main menu.");
                Console.ReadKey();
                response = "";
            }

            if (response == "3")
            {
                Console.Clear();
                Console.WriteLine("You are currently attempting to Load a saved file.");
                Console.WriteLine("If you leave your response blank, by default, it will set the name to 'My Journal'.");
                Console.Write("What is the name of the file you are trying to open: ");
                string fileName = Console.ReadLine();
                if (fileName == "")
                {
                    fileName = "My Journal";
                }
                journal.LoadFromFile(fileName);
                Console.WriteLine("Press any key to go back to the main menu.");
                Console.ReadKey();
                response = "";
            }

            if (response == "4")
            {
                Console.Clear();
                Console.WriteLine("You are currently attempting to save your data to a file.");
                Console.WriteLine("If you leave your response blank, by default, it will set the name to 'My Journal'.");
                Console.Write("What is the name of the file you would like to save it to: ");
                string fileName = Console.ReadLine();
                if (fileName == "")
                {
                    fileName = "My Journal";
                }
                journal.SaveToFile(fileName);
                Console.WriteLine("Press any key to go back to the main menu.");
                Console.ReadKey();
                response = "";
            }

            if (response == "5")
            {
                Console.WriteLine("The program will now close. Please click any key to continue.");
                Console.ReadKey();
            }
        }
    }
}