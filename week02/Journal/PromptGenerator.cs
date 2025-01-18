using System;

public class PromptGenerator
{
    public List<string> _entries = new List<string>() 
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is one thing I learned today that I didn’t know before?",
        "What am I most grateful for today?",
        "Did I help someone today? If so, how?",
        "What is one challenge I faced today, and how did I handle it?",
        "What was a small moment of joy I experienced today?",
        "Who made me smile today, and why?",
        "What is something I accomplished today that I’m proud of?",
        "Did I notice anything beautiful in nature today?",
        "How did I show kindness to myself today?",
        "What is one thing I can do tomorrow to make it better than today?",
        "Did I encounter any unexpected surprises today?",
        "What inspired me today?",
        "If I could thank one person for something they did today, who would it be and why?",
        "What was a moment today when I felt truly at peace?",
        "How did I spend my time today? Was it meaningful?",
        "What is one thing I wish I had done differently today?",
        "Did I experience any moments of spiritual or personal insight today?",
        "What is one thing I want to remember about today?",
        "How did I show love or appreciation to someone today?",
        "What is one thing I’m looking forward to tomorrow?",
    };
    
    public string ReturnPrompt()
    {
        Random random = new Random();
        int randomInt = random.Next(0, _entries.Count - 1);
        string prompt = _entries[randomInt];
        return prompt;
    }
}