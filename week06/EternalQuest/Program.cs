using System;
using System.Runtime.InteropServices;

// Shows creativity and exceeds core requirements
// For this I did a couple of small things, but they added up
// 1) For the Eternal Goal, I added a counter so that it keeps track of the number of times they have completed the goal.
// 2) I added a PressAnyKeyToContinue() script in the GoalManager because there were multiple times when I wanted to allow time for the user to view the code before it gets cleared. Make it more user friendly.
// 3) In the GoalManager class, I also added a GetPositiveInteger(), this will return an integer that is positive, if the user inputs anything else, it will return an error. I sed this multiple times, as an example, any time it requested for points, it used it so that the user could not input the wrong number or something that would not work.

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        GoalManager goalManager = new GoalManager();
        string menuChoice = "";
        while (menuChoice != "6")
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine(" 1) Create New Goal");
            Console.WriteLine(" 2) List Goals");
            Console.WriteLine(" 3) Save Goals");
            Console.WriteLine(" 4) Load Goals");
            Console.WriteLine(" 5) Record Event");
            Console.WriteLine(" 6) Quit");

            menuChoice = goalManager.GetOptionFromList("Select a choice from the menu: ", new List<string> {"1", "2", "3", "4", "5", "6"});

            if (menuChoice == "1")
            {
                goalManager.CreateNewGoal();
            }

            if (menuChoice == "2")
            {
                goalManager.ListGoals();
                goalManager.PressAnyKeyToContinue();
                Console.WriteLine();
            }

            if (menuChoice == "3")
            {
                Console.WriteLine("What is the name of the file you would like to save the Goals to?");
                Console.WriteLine("If you leave the file name blank, it will save it as a default name of 'Goals.txt'");
                Console.Write("File Name: ");
                string fileName = Console.ReadLine();
                if (fileName == "")
                {
                    fileName = "Goals.txt";
                }
                goalManager.SaveGoalsToFile(fileName);
                goalManager.PressAnyKeyToContinue();
                Console.WriteLine();
            }

            if (menuChoice == "4")
            {
                Console.WriteLine("What is the name of the file you would like to Load the Goals from?");
                Console.WriteLine("If you leave the file name blank, it will use the default name of 'Goals.txt'");
                Console.Write("File Name: ");
                string fileName = Console.ReadLine();
                if (fileName == "")
                {
                    fileName = "Goals.txt";
                }
                goalManager.LoadGoalsFromFile(fileName);
                goalManager.PressAnyKeyToContinue();
                Console.WriteLine();
            }

            if (menuChoice == "5")
            {
                goalManager.RecordEvent();
            }
        }
    }
}