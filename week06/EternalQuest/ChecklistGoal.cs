using System;
using System.ComponentModel;

public class ChecklistGoal : Goal
{
    private int _numberCompleted;
    private int _numberTarget;
    private int _completedBonus;

    public ChecklistGoal(string name, string description, int points, int numberTarget, int completedBonus, int numberCompleted) : base(name, description, points)
    {
        _numberTarget = numberTarget;
        _completedBonus = completedBonus;
        _numberCompleted = numberCompleted;

        if (_numberCompleted >= _numberTarget)
        {
            IsComplete();
        }
    }

    public ChecklistGoal(string name, string description, int points, int numberTarget, int completedBonus) : base(name, description, points)
    {
        _numberTarget = numberTarget;
        _completedBonus = completedBonus;
        _numberCompleted = 0;

        if (_numberCompleted >= _numberTarget)
        {
            IsComplete();
        }
    }

    public override string GetStringRepresentation()
    {
        string representation = $"ChecklistGoal{_separator}{base.GetStringRepresentation()}{_separator}{_numberTarget}{_separator}{_completedBonus}{_separator}{_numberCompleted}";
        return representation;
    }

    public override string GetDetailsString()
    {
        string detailsString = $"{base.GetDetailsString()} -- Currently completed: {_numberCompleted}/{_numberTarget}";
        return detailsString;
    }

    public override int RecordEventReturnPoints()
    {
        int points = 0;
        if (_numberCompleted < _numberTarget)
        {
            _numberCompleted += 1;
            points = GetPoints();

            if (_numberCompleted >= _numberTarget)
            {
                IsComplete();
                points = _completedBonus;
            }
        }
        else
        {
            Console.WriteLine("The total number has already been completed for this goal.");
        }
        return points;
    }

}
