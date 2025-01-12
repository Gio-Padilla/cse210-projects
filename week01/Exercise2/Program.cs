using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is the grade persetage?");
        Console.WriteLine("Please only provide a whole number between 1 to 100.");
        Console.Write("Grade: ");
        string gradeString = Console.ReadLine();
        int gradeInt = int.Parse(gradeString);
        Console.WriteLine();

        string letter = "Error";

        if (gradeInt >= 90)
        {
            letter = "A";
        }
        else if (gradeInt >= 80)
        {
            letter = "B";
        }
        else if (gradeInt >= 70)
        {
            letter = "C";
        }
        else if (gradeInt >= 60)
        {
            letter = "D";
        }
        else if (gradeInt < 60)
        {
            letter = "F";
        }

        Console.WriteLine($"You got a '{letter}' for the class.");
        if (gradeInt < 70)
        {
            Console.WriteLine("You needed a 'C' or better in order to pass the class. Better luck next time!");
        }
        else
        {
            Console.WriteLine("Great job! You have passed the class. Keep up the amazing work!");
        }
    }
}