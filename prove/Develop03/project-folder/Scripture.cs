using System;
using System.Collections.Generic;
using System.Linq;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void HideRandomWords(int count)
    {
        Random rand = new Random();

        List<Word> availableWords = _words.Where(word => !word.IsHidden()).ToList();

        for (int i = 0; i < count && availableWords.Count > 0; i++)
        {
            int index = rand.Next(availableWords.Count);
            availableWords[index].Hide();
            availableWords.RemoveAt(index);
        }
    }

    public bool AllWordsHidden()
    {
        return _words.All(word => word.IsHidden());
    }

    public string GetDisplayText()
    {
        return $"{_reference}\n{string.Join(" ", _words)}";
    }

    public string GetReferenceText()
    {
        return _reference.ToString();
    }
}