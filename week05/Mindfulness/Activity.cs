using System;
using System.Collections.Generic;

public class Activity
{
    private string _name;
    private string _description;
    private List<string> _spinnerRotation = new List<string>()
    {
        "|||",
        "///",
        "|||",
        @"\\\",

    };

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("Well done!");
        Console.WriteLine("Please click any key to got back to the menu.");
        Thread.Sleep(100);
        while (Console.KeyAvailable)
        {
            Console.ReadKey(true);
        }
        Console.ReadKey(true);
        Console.Clear();
    }

    private int RapInRange(int lowest, int highest, int chosenNumber)
    {
        int returnNumber = chosenNumber;
        int theRange = highest - lowest + 1;

        if (returnNumber > highest)
        {
            returnNumber = (int)Math.Round(returnNumber - (Math.Floor((float)returnNumber / theRange) * theRange));
        }

        if (returnNumber < lowest)
        {
            returnNumber = (int)Math.Round(returnNumber + (Math.Ceiling((float)(lowest - returnNumber) / theRange) * theRange));
        }
        return returnNumber;
    }

    public void ShowSpinner(int seconds, string prompt)
    {
        int k;
        string prompt2;
        for(int i = 0; i < (seconds * 5); i ++)
        {
            k = RapInRange(0, _spinnerRotation.Count - 1, i);
            prompt2 = $"{_spinnerRotation[k]} {prompt} {_spinnerRotation[k]}";
            Console.Write(prompt2);
            Thread.Sleep(200);
            Console.Write(new string('\b', prompt2.Length));
        }
        Console.WriteLine();
    }

    public void ShowCountdoun(int seconds)
    {
        for(int i = seconds; i > 0; i --)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b");
        }
        Console.WriteLine(0);
    }

    public int RequestThenReturnSeconds()
    {
        int returnSeconds;
        Console.Write("How long, in seconds, would you like your session? ");
        while (!int.TryParse(Console.ReadLine(), out returnSeconds) || returnSeconds <= 0)
        {
            Console.WriteLine();
            Console.WriteLine("Invalid input. Please enter a positive integer greater than 0.");
            Console.Write("How long, in seconds, would you like your session? ");
        }
        Console.WriteLine();
        return returnSeconds;
    }
}