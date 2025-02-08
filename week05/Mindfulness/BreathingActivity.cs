using System;

public class BreathingActivity : Activity
{
    private int _seconds;

    public BreathingActivity() : base("Breathing Activity", "This activity is designed to help you relax by guiding you through slow, intentional breathing. It will clear your mind, reduce stress, and bring your focus to the rhythm of your breath.") {}
    
    public void Run()
    {
        DisplayStartingMessage();
        _seconds = RequestThenReturnSeconds();
        ShowSpinner(3, "The Breathing Activity will now begine");
        Console.WriteLine();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_seconds);

        while (DateTime.Now < endTime)
        {
            Console.Write("Inhale...");
            ShowCountdoun(4);
            if (DateTime.Now > endTime) {break;}
            Console.Write("Exhale...");
            ShowCountdoun(4);
        }
        Console.WriteLine();
        DisplayEndingMessage();

    }
}