using System;

public class SimpleGoal : Goal
{

    public SimpleGoal(string name, string description, int points) : base(name, description, points){}
    public SimpleGoal(string name, string description, int points, bool isComplete) : base(name, description, points, isComplete){}

    public override int RecordEventReturnPoints()
    {
        int points = 0;
        if (GetIsComplete() == false)
        {
            IsComplete();
            points = GetPoints();
        }
        else
        {
            Console.WriteLine("This Goal has already been completed.");
        }

        return points;
    }

    public override string GetStringRepresentation()
    {
        string stringRepresentation = $"SimpleGoal{_separator}{base.GetStringRepresentation()}";
        return stringRepresentation;
    }

}