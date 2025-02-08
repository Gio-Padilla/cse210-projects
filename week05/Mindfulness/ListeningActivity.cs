using System;
using System.Collections.Generic;
using System.Globalization;

public class ListeningActivity : Activity
{
    private int _count;
    private Random _random = new Random();
    private int _seconds;
    private List<string> _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?",
        "What are some things that bring you joy?",
        "What is something you’ve recently accomplished that you’re proud of?",
        "What are some moments that made you feel truly grateful?",
        "What are some hobbies or activities that make you feel fulfilled?",
        "Who are people that inspire you to be your best self?",
        "What are some ways you’ve made a positive impact on others recently?",
        "What are some things in nature that you find beautiful?",
        "What are some skills you’ve developed that you’re proud of?",
        "What are some small acts of kindness you’ve experienced or given?",
        "What are things in your life that you’re looking forward to?"
    };
    public ListeningActivity() : base("Listening Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _count = 0;
    }

    public void Run()
    {
        DisplayStartingMessage();
        string prompt = GetRandomPrompt();

        _seconds = RequestThenReturnSeconds();
        Console.Clear();

        Console.WriteLine($">>> {prompt} <<<");
        Console.WriteLine();
        ShowSpinner(2, "Get ready to answer the prompt above");
        Console.WriteLine();
        
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_seconds);

        while (DateTime.Now < endTime)
        {
            Console.Write("* ");
            Console.ReadLine();
            _count ++;
        }
        Console.WriteLine();
        Console.WriteLine($"You provided a total of {_count} answers to the question.");
        Console.WriteLine();
        ShowSpinner(3, "Done!");
        Console.WriteLine();
        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        int randomIndex = _random.Next(_prompts.Count);
        string prompt = _prompts[randomIndex];
        return prompt;
    }


}