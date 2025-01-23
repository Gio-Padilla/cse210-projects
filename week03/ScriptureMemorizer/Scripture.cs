using System;
using System.Security.AccessControl;

class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();
    private List<int> _wordsChosen = new List<int>();
    private Random _random = new Random();
    private List<string> _splitText;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _splitText = new List<string>(text.Split(" "));

        int i = 0;
        foreach (string word in _splitText)
        {
            _words.Add(new Word(word));
            _wordsChosen.Add(i);
            i += 1;
        }
    }

    public void Reset()
    {
        _wordsChosen.Clear();
        int i = 0;
        foreach (string word in _splitText)
        {
            _words[i].Show();
            _wordsChosen.Add(i);
            i += 1;
        }
    }

    private void HideOneRandomWord()
    {
        int randomNumber = _random.Next(_wordsChosen.Count);
        int wordPosition = _wordsChosen[randomNumber];
        _wordsChosen.RemoveAt(randomNumber);
        _words[wordPosition].Hide();
    }

    public void HideRandomWords(int numberToHide)
    {
        int hiding = numberToHide;
        if (hiding > _wordsChosen.Count)
        {
            hiding = _wordsChosen.Count;
        }

        if (_wordsChosen.Count > 0)
        {
            for (int i = 0; i < hiding; i ++)
            {
                HideOneRandomWord();
            }
        }
    }

    public string GetDisplayText()
    {
        string displayText = _reference.GetDisplayText() + " ";
        foreach(Word word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }
        return displayText;
    }

    public bool AreAllHidden()
    {
        if (_wordsChosen.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}