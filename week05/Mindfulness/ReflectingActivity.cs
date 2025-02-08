using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;

public class ReflectingActivity : Activity
{
    private int _seconds;
    private Random _random = new Random();
    private List<string> _prompts = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless.",
        "Think of a time when you overcame a major obstacle.",
        "Think of a time when you pushed through fear to achieve something important.",
        "Think of a time when you turned a setback into an opportunity.",
        "Think of a time when you stayed true to your values despite pressure.",
        "Think of a time when you supported someone through a difficult time.",
        "Think of a time when you challenged yourself beyond your comfort zone.",
        "Think of a time when you stayed persistent despite wanting to give up.",
        "Think of a time when you learned an important lesson from failure.",
        "Think of a time when you found strength in vulnerability.",
        "Think of a time when you inspired or motivated someone else."
    };
    private List<string> _questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?",
        "How did you stay motivated throughout the process?",
        "What challenges did you face along the way, and how did you overcome them?",
        "Who or what supported you during this experience?",
        "What strengths did you discover about yourself?",
        "How did your perspective change as a result of this experience?",
        "If you could go back, what would you do differently?",
        "What did you learn about others during this time?",
        "How did this experience affect your confidence?",
        "How did you manage any self-doubt you faced?",
        "What role did patience play in this experience?",
        "What part of the experience surprised you the most?",
        "How did you deal with setbacks during this experience?",
        "What would you tell someone else going through a similar situation?",
        "How did this experience challenge your beliefs or assumptions?",
        "What new skills or abilities did you develop?",
        "How can you use what you learned in future situations?",
        "How did you celebrate your success after completing this experience?",
        "In what ways did this experience change your outlook on life?",
        "How did you feel when you were in the middle of the experience?",
        "What did you realize about the importance of perseverance through this experience?"
    };

    public ReflectingActivity() : base("Reflecting Activity", "This activity will guide you in reflecting on moments when you’ve demonstrated strength and resilience. By recognizing your inner power, you’ll gain a deeper understanding of how to apply it to other areas of your life.") {}

    public void Run()
    {
        DisplayStartingMessage();
        string prompt = GetRandomPrompt();

        _seconds = RequestThenReturnSeconds();
        Console.Clear();
        ShowSpinner(3, "The Reflecting Activity will now begine");
        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"    --- {prompt} ---");
        Console.WriteLine();
        Console.WriteLine("Be sure to have something specific in mind because the program will display questions that need answers based off of your response.");
        Console.WriteLine();
        Console.Write("When you are ready to beging, please press any key and the questions will start...");
        Console.ReadKey();
        Console.WriteLine();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_seconds);

        while (DateTime.Now < endTime)
        {
            if (!NoMoreQuestions())
            {
                Console.Write($"> {GetRandomQuestion()} ");
                ShowSpinner(5, "Please take 5 seconds to think before next question");
            }
            else
            {
                Console.WriteLine("You have been shown all of the questions we have. No more time needed.");
                break;
            }
        }
        Console.WriteLine();
        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        int randomIndex = _random.Next(_prompts.Count);
        string prompt = _prompts[randomIndex];
        return prompt;
    }

    private string GetRandomQuestion()
    {
        int randomIndex = _random.Next(_questions.Count);
        string question = _questions[randomIndex];
        _questions.RemoveAt(randomIndex);
        return question;
    }

    private bool NoMoreQuestions()
    {
        if (_questions.Count > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

}