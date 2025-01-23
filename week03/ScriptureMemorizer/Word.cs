using System;
using System.Runtime.CompilerServices;

class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }
    public void Show()
    {
        _isHidden = false;
    }
    public bool IsHidden()
    {
        return _isHidden;
    }
    public string GetDisplayText()
    {
        string theDisplayText = "";
        if (_isHidden == false)
        {
            theDisplayText = _text;
        }
        else
        {
            int numberOfCharacters = _text.Length;
            theDisplayText = new string('_', numberOfCharacters);
        }

        return theDisplayText;
    }
}
