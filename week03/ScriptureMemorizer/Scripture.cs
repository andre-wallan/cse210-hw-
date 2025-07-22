using System.Diagnostics;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _rand = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public void HideRandomWords(int count = 3)
    {
        var visibleWords = _words.Where(w => !w.IsHidden).ToList();
        if (visibleWords.Count == 0) return;

        for (int i = 0; i < count && visibleWords.Count > 0; i++)
        {
            var word = visibleWords[_rand.Next(visibleWords.Count)];
            word.Hide();
            visibleWords.Remove(word);
        }
    }

    public bool AllWordsHidden() => _words.All(w => w.IsHidden);

    public string GetDisplayText()
    {
        return $"{_reference}\n\n" + string.Join(" ", _words.Select(w => w.GetDisplay()));
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}