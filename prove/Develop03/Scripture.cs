using System.Collections.Generic;

class Scripture{
    private List<Word> words;
    private ScriptureReference reference;
    public string FullReference => reference.ToString();

    public Scripture(string reference, string text)
    {
        this.reference = new ScriptureReference(reference);
        words = ParseScriptureText(text);

    }

    private List<Word> ParseScriptureText(string text)
    {
        string[] wordArray =text.Split(new char[] { ' ', '.', ',', ';', ':', '-', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        List<Word> wordList = new List<Word>();
        foreach (string word in wordArray)
        {
            wordList.Add(new Word(word));
        }
        return wordList;
    }

    public void HideRandomWord()
    {
        Random random = new Random();
        int randomIndex = random.Next(0, words.Count);
        words[randomIndex].Hide();
    }

    public bool AllWordsHidden()
    {
        return words.All(word => word.IsHidden);
    }

    public void Display()
    {
        Console.WriteLine($"{FullReference}\n");
        foreach (Word word in words)
        {
            Console.Write(word.ToString() + " ");
        }
        Console.WriteLine("\n");
    }
}

class ScriptureReference
{
    private string reference;

    public ScriptureReference(string reference)
    {
        this.reference = reference;
    }

    public override string ToString()
    {
        return reference;
    }

    // rest of the ScriptureReference class
}


class Word
{
    private string value;
    public bool IsHidden {get; private set; }

    public Word(string value)
    {
        this.value = value;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }

    public void Unhide()
    {
        IsHidden = false;
    }

    public override string ToString()
    {
        return IsHidden ? "-----" : value;

    }

    //rest of the Word class

}


