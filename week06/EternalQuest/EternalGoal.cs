using System;

public class EternalGoal : Goal
{
    private int _numberCompleted;

    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
        _numberCompleted = 0;
    }

    public EternalGoal(string name, string description, int points, int numberCompleted) : base(name, description, points)
    {
        _numberCompleted = numberCompleted;
    }

    public override int RecordEventReturnPoints()
    {
        _numberCompleted += 1;
        return GetPoints();
    }

    public override string GetDetailsString()
    {
        string detailsString = $"{base.GetDetailsString()} -- Completed a total of {_numberCompleted} times";
        return detailsString;
    }

    public override string GetStringRepresentation()
    {
        string stringRepresentation = $"EternalGoal{_separator}{base.GetStringRepresentation()}{_separator}{_numberCompleted}";
        return stringRepresentation;
    }
}