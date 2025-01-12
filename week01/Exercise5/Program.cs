using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int number = PromptUserNumber();
        int numberSquared = SquareNumber(number);
        DisplayResult(name, numberSquared);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string inputName = Console.ReadLine();
        return inputName;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        string inputNumber = Console.ReadLine();
        int number = int.Parse(inputNumber);
        return number;
    }

    static int SquareNumber(int numberUsed)
    {
        int numberSquared = numberUsed * numberUsed;
        return numberSquared;
    }

    static void DisplayResult(string name, int squareNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squareNumber}");
    }
}