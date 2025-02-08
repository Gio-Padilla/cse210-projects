using System;
using System.Collections.Generic;

// Shows creativity and exceeds core requirements
// I did a few things to accoplish this and they are as follows:
// 1) For the ReflectingActivity, I made it do that there are no repeat questions. If they answer them all, then it will end before the time is up letting the customer know.
// 2) For the ShowSpinner() under activity, the code allows it have an input durration and a string that will show between the moving symbols.
// 3) When the user inputs the seconds for the activity, I created the RequestThenReturnSeconds() function under the Actifity class where the user can only input a while number above 0. If it receives anything else, it will display an error message. I had to look up how to do this.


class Program
{
    static void Main(string[] args)
    {
        List<string> menuOptions = new List<string>() {"1", "2", "3", "4"};

        string menuChoice = "";

        while (menuChoice != "4")
        {
            menuChoice = "";
            Console.Clear();
            Console.WriteLine("Welcome to the mindful program!");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine(" 1) Breathing Activity");
            Console.WriteLine(" 2) Reflecting Activity");
            Console.WriteLine(" 3) Listening Activity");
            Console.WriteLine(" 4) Quit");

            while (!menuOptions.Contains(menuChoice))
            {
                Console.Write("Please select a choice from the menu: ");
                menuChoice = Console.ReadLine();
                if (!menuOptions.Contains(menuChoice))
                {
                    Console.WriteLine("Wrong response received. Please try again.");
                    Console.WriteLine();
                }
            }

            if (menuChoice == "1")
            {
                BreathingActivity breathingActivity = new BreathingActivity();
                breathingActivity.Run();
            }

            if (menuChoice == "2")
            {
                ReflectingActivity reflectingActivity = new ReflectingActivity();
                reflectingActivity.Run();
            }

            if (menuChoice == "3")
            {
                ListeningActivity listeningActivity = new ListeningActivity();
                listeningActivity.Run();
            }
        }
    }
}