using System.Collections;

public class Painting
{
    public string author;
    public string name;
    public string description;

    public Painting (string name, string author, string description)
    {
        this.name = name;
        this.author = author;
        this.description = description;
    }

    public string GetFormattedDescription ()
    {
        return string.Format("{0}\nAuthor: {1}\nDescription:\n{2}", name, author, description);
    }
}
