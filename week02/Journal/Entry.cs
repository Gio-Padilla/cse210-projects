using System;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"{_promptText}");
        Console.WriteLine($"{_entryText}");
        Console.WriteLine("");
    }

    public string ReturnConvertedEntryToLine()
    {
        string dataLine = $"{_date} *|||* {_promptText} *|||* {_entryText}";
        return dataLine;
    }

    public void ConvertLineToVariables(string lineString)
    {
        List<string> parts = new List<string>(lineString.Split(" *|||* "));

        _date = parts[0];
        _promptText = parts[1];
        _entryText = parts[2];
    }
}