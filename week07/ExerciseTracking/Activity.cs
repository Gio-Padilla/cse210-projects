using System;

public abstract class Activity
{
    private DateTime _date;
    private int _minutes;
    
    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public int GetMinutes()
    {
        return _minutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();
    public virtual string GetSummary()
    {
        //I had to look up how to get the name of the class in order to make this part easier.
        string summary = $"{_date:dd MMM yyyy} {this.GetType().Name} ({_minutes} min) - Distance: {GetDistance():F2} km, Speed: {GetSpeed():F2} kph, Pace: {GetPace():F2} min per km";
        return summary;
    }
}