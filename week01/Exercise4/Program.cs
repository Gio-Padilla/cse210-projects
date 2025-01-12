using System;
using System.Collections.Generic;
using System.ComponentModel;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Lets do some calculations based off of a group of numbers you provide.");
        Console.WriteLine("Please continue providing whole numbers until you feel satisfied.");
        Console.WriteLine("Once you feel satisfied, end by typing '0' as your response.");
        Console.WriteLine("--------------------------------------------------------------------------------");
        
        string inputNumberString;
        int inputNumberInt;
        List<int> numberList = new List<int>();
        
        do
        {
            Console.Write("Please provide a whole number: ");
            inputNumberString = Console.ReadLine();
            inputNumberInt = int.Parse(inputNumberString);
            if (inputNumberInt != 0)
            {
                numberList.Add(inputNumberInt);
            }
        } while (inputNumberInt != 0);

        int numberSum = 0;
        int numberLargest = numberList[0];

        foreach (int number in numberList)
        {
            numberSum += number;
            if (number > numberLargest)
            {
                numberLargest = number;
            }
        }

        float numberAverage = (float)numberSum / numberList.Count;

        Console.WriteLine($"The sum of the numbers provided is: {numberSum}");
        Console.WriteLine($"The average of the numbers provided is: {numberAverage}");
        Console.WriteLine($"The largest number that was provided is: {numberLargest}");

    }
}