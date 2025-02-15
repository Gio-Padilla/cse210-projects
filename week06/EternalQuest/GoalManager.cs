using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private string _separator = "/*/";
    private int _score;
    private string _spacer = "=======================================";

    private void RequestCreateSimpleGoal()
    {
        string name;
        string description;
        int points;
        Console.WriteLine(_spacer);
        Console.WriteLine("Creating a new Simple Goal");
        Console.WriteLine(_spacer);
        Console.Write("What is the name of your Goal? ");
        name = Console.ReadLine();
        Console.Write("What is a short description of the Goal? ");
        description = Console.ReadLine();
        points = GetPositiveInteger("What is the amount of points gained from completing this goal? ");
        _goals.Add(new SimpleGoal(name, description, points));
        Console.WriteLine("Your new Goal has been added to the list.");
        PressAnyKeyToContinue();
    }

    private void RequestCreateEternalGoal()
    {
        string name;
        string description;
        int points;
        Console.WriteLine(_spacer);
        Console.WriteLine("Creating a new Eternal Goal");
        Console.WriteLine(_spacer);
        Console.Write("What is the name of your Goal? ");
        name = Console.ReadLine();
        Console.Write("What is a short description of the Goal? ");
        description = Console.ReadLine();
        points = GetPositiveInteger("What is the amount of points gained from acomplishing this Goal everytime? ");
        _goals.Add(new EternalGoal(name, description, points));
        Console.WriteLine("Your new Goal has been added to the list.");
        PressAnyKeyToContinue();
    }

    private void RequestCreateChecklistGoal()
    {
        string name;
        string description;
        int points;
        int numberTarget;
        int completedBonus;
        Console.WriteLine(_spacer);
        Console.WriteLine("Creating a new Checklist Goal");
        Console.WriteLine(_spacer);
        Console.Write("What is the name of your Goal? ");
        name = Console.ReadLine();
        Console.Write("What is a short description of the Goal? ");
        description = Console.ReadLine();
        numberTarget = GetPositiveInteger("How many times are you needing to complete this Goal (Target Amount)? ");
        points = GetPositiveInteger("What is the amount of points gained from acomplishing this Goal everytime? ");
        completedBonus = GetPositiveInteger("How many extra points do you get for reaching your target amount? ");
        _goals.Add(new ChecklistGoal(name, description, points, numberTarget, completedBonus));
        Console.WriteLine("Your new Goal has been added to the list.");
        PressAnyKeyToContinue();
    }

    public void CreateNewGoal()
    {
        Console.WriteLine(_spacer);
        Console.WriteLine("Choose the type of Goal you want");
        Console.WriteLine(_spacer);
        Console.WriteLine(" 1) Simple Goal");
        Console.WriteLine(" 2) Eternal Goal");
        Console.WriteLine(" 3) Checklist Goal");
        string option = GetOptionFromList("Goal Choice: ", new List<string> () {"1", "2", "3"});
        if (option == "1")
        {
            RequestCreateSimpleGoal();
        }
        if (option == "2")
        {
            RequestCreateEternalGoal();
        }
        if (option == "3")
        {
            RequestCreateChecklistGoal();
        }
    }

    public string GetOptionFromList(string promptOrQuestion, List<string> possibleOptions)
    {
        string response;
        while (true)
        {
            Console.Write(promptOrQuestion);
            response = Console.ReadLine().ToLower();
            if (possibleOptions.Contains(response))
            {
                return response;
            }
            else
            {
                Console.WriteLine("Worng respose received.");
                Console.Write("Only possible answers are: ");
                foreach(string option in possibleOptions)
                {
                    Console.Write($"{option}, ");
                }
                Console.WriteLine("\b\b");
                Console.WriteLine();
            }
        }
    }

    public void ListGoals()
    {
        Console.WriteLine();
        Console.WriteLine($"You have {_score} points");
        Console.WriteLine();
        Console.WriteLine("The Goals are:");
        int count = 1;
        foreach (Goal goal in _goals)
        {
            Console.Write($"{count}. ");
            Console.WriteLine(goal.GetDetailsString());
            count += 1;
        }
    }

    public void SaveGoalsToFile(string fileName)
    {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine(_score);
            foreach(Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoalsFromFile(string fileName)
    {
        string[] lines = File.ReadAllLines(fileName);
        if (lines.Length > 0)
        {
            _score = int.Parse(lines[0]);
            for (int i = 1; i < lines.Length; i ++)
            {
                _goals.Add(ConvertStringRepresentationToGoal(lines[i]));
            }
        }
    }

    public Goal ConvertStringRepresentationToGoal(string stringRepresentation)
    {
        List<string> parts = new List<string>(stringRepresentation.Split(_separator));
        Goal goal;


        if (parts[0] == "EternalGoal")
        {
            goal = new EternalGoal
            (
                parts[1], // Name
                parts[2], // Description
                int.Parse(parts[3]), // Points
                // I skipped 4 since it is not important for this goal
                int.Parse(parts[5]) // Number of times completed
            );
        }
        else if (parts[0] == "SimpleGoal")
        {
            goal = new SimpleGoal
            (
                parts[1], // Name
                parts[2], // Description
                int.Parse(parts[3]), // Points
                bool.Parse(parts[4]) // Is Completed or not (bool)
            );
        }
        else
        {
            goal = new ChecklistGoal(
                parts[1], // Name
                parts[2], // Description
                int.Parse(parts[3]), // Points
                // I skipped 4 since it is not important for this goal
                int.Parse(parts[5]), // Number Target
                int.Parse(parts[6]), // Completed Points
                int.Parse(parts[7]) // Number Completed
            );
        }
        return goal;
    }

    private int GetPositiveInteger(string prompt)
    {
        int number;
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            // Try parsing the input as an integer
            if (!int.TryParse(input, out number))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                continue; // This forces the loop to restart without running the rest of the code.
            }

            // Check if the number is greater than 0
            if (number > 0)
            {
                return number;
            }
            else
            {
                Console.WriteLine("The number must be greater than 0.");
            }
        }
    }

    public void PressAnyKeyToContinue()
    {
        Console.WriteLine("Please press any key to continue.");
        while (Console.KeyAvailable)
        {
            Console.ReadKey(true);
        }
        Console.ReadKey(true);
        Console.Clear();
    }

    public int GetValidGoalNumber()
    {
        if (_goals.Count <= 0)
        {
            Console.WriteLine("There are no Goals in your list.");
            return 0;
        }
        else while (true)
        {
            Console.WriteLine($"If you do not want to choose a Goal, please pick any number higher than the number of goals you have. (Any number higher than {_goals.Count})");
            int goalNumber = GetPositiveInteger("Goal Number: ");
            if (goalNumber <= _goals.Count)
            {
                return goalNumber;
            }
            else
            {
                return 0;
            }
        }
    }

    public void RecordEvent()
    {
        ListGoals();
        Console.WriteLine(_spacer);
        Console.WriteLine("What Goal Number from the list would you like to record an event to?");
        int goalToRecord = GetValidGoalNumber();
        if (goalToRecord > 0)
        {
            _score += _goals[goalToRecord - 1].RecordEventReturnPoints();
            Console.WriteLine("Event has been recorded and score has been added.");
            Console.WriteLine($"Current Score: {_score}");
            PressAnyKeyToContinue();
        }
        else
        {
            Console.WriteLine("You have chosen to skip recording a Goal event.");
            PressAnyKeyToContinue();
        }
    }
}