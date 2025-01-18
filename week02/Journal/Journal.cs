using System;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach(Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string fileName)
    {

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.ReturnConvertedEntryToLine());
            }
        }

    }

    public void LoadFromFile(string fileName)
    {
        string[] lines = File.ReadAllLines(fileName);
        foreach (string line in lines)
        {
            Entry entry = new Entry();
            entry.ConvertLineToVariables(line);
            AddEntry(entry);
        }
    }
}