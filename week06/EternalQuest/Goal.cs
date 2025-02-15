using System;

public abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;
    private bool _isComplete;
    protected string _separator = "/*/";

    public Goal(string name, string description, int points, bool isComplete)
    {
        _name = name;
        _description = description;
        _points = points;
        _isComplete = isComplete;
    }

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
        _isComplete = false;
    }

    public abstract int RecordEventReturnPoints();

    protected virtual int GetPoints()
    {
        return _points;
    }

    protected void IsComplete()
    {
        _isComplete = true;
    }

    public bool GetIsComplete()
    {
        return _isComplete;
    }

    public virtual string GetStringRepresentation() // This is what gets saved to the file.
    {
        string representation = $"{_name}{_separator}{_description}{_separator}{_points}{_separator}{_isComplete}";
        return representation;
    }

    public virtual string GetDetailsString() // This is how the Goal is displayed to the user.
    {
        string detailsString;
        if (_isComplete == true)
        {
            detailsString = "[X]";
        }
        else
        {
            detailsString = "[ ]";
        }

        detailsString = $"{detailsString} {_name} ({_description})";
        return detailsString;
    }


}