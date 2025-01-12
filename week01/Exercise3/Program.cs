using System;

class Program
{
    static void Main(string[] args)
    {

        int highestNumber = 100;
        int guessedNumberInt = 0;
        int numberOfTries = 0;
        string guessedNumberString = guessedNumberInt.ToString();

        // Sets a varible to a random number
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, highestNumber);
        

        Console.WriteLine($"A magic number between 1 to {highestNumber} has been chosen.");
        Console.WriteLine("Your job is to guess that number in as few possibilities as possible.");
        Console.WriteLine("Whole numbers only.");
        Console.WriteLine("----------------------------------------------------------------------");

        while (guessedNumberInt != magicNumber)
        {
            Console.Write("What is your guess? ");
            guessedNumberString = Console.ReadLine();
            guessedNumberInt = int.Parse(guessedNumberString);
            numberOfTries ++;

            if (guessedNumberInt > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else if (guessedNumberInt < magicNumber)
            {
                Console.WriteLine("Higher");
            }

        }
        Console.WriteLine($"You guessed the magic number in {numberOfTries} tries!");

    }
}