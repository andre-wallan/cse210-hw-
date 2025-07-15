using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    public Reference Reference { get; private set; }
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        _words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public void HideRandomWords(int count)
    {
        Random rand = new Random();
        var visibleWords = _words.Where(w => !w.IsHidden()).ToList();
        for (int i = 0; i < count && visibleWords.Count > 0; i++)
        {
            var word = visibleWords[rand.Next(visibleWords.Count)];
            word.Hide();
            visibleWords.Remove(word);
        }
    }

    public string GetDisplayText()
    {
        return $"{Reference.GetDisplayText()} - " + string.Join(" ", _words.Select(w => w.GetDisplayText()));
    }

    public bool AllWordsHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    public string GetHintText()
    {
        return $"{Reference.GetDisplayText()} - " + string.Join(" ", _words.Select(w =>
        {
            if (w.IsHidden())
                return w.FirstLetterHint();
            else
                return w.GetDisplayText();
        }));
    }
}
