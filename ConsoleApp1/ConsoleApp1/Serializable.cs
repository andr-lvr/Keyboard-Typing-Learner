using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

// Task 1: Fraction Array Serialization
[Serializable]
public class Fraction
{
    public int Numerator { get; set; }
    public int Denominator { get; set; }
}

class Serializable
{
    static void Main()
    {
        // Task 1
        List<Fraction> fractions = new List<Fraction>();
        fractions = InputFractions();
        SerializeAndSave(fractions, "fractions.xml");
        List<Fraction> loadedFractions = LoadAndDeserialize<List<Fraction>>("fractions.xml");

        // Task 2: Journal Serialization
        Journal journal = InputJournalInfo();
        SerializeAndSave(journal, "journal.xml");
        Journal loadedJournal = LoadAndDeserialize<Journal>("journal.xml");

        // Task 3: Add Articles to Journal
        Article article1 = InputArticleInfo();
        Article article2 = InputArticleInfo();
        journal.Articles = new List<Article> { article1, article2 };

        // Task 3 continued: Serialize Journal with Articles
        SerializeAndSave(journal, "journal_with_articles.xml");
        Journal loadedJournalWithArticles = LoadAndDeserialize<Journal>("journal_with_articles.xml");

        // Task 4: Create Array of Journals
        Journal[] journalArray = new Journal[] { journal, loadedJournalWithArticles };
        SerializeAndSave(journalArray, "journals_array.xml");
        Journal[] loadedJournalsArray = LoadAndDeserialize<Journal[]>("journals_array.xml");

        Console.WriteLine("Operations completed successfully.");
    }

    // Helper methods
    static List<Fraction> InputFractions()
    {
        Console.WriteLine("Enter the number of fractions:");
        int count = int.Parse(Console.ReadLine());
        List<Fraction> fractions = new List<Fraction>();

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"Enter numerator for fraction {i + 1}:");
            int numerator = int.Parse(Console.ReadLine());

            Console.WriteLine($"Enter denominator for fraction {i + 1}:");
            int denominator = int.Parse(Console.ReadLine());

            fractions.Add(new Fraction { Numerator = numerator, Denominator = denominator });
        }

        return fractions;
    }

    static T LoadAndDeserialize<T>(string fileName)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));

        using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
        {
            return (T)serializer.Deserialize(fileStream);
        }
    }

    static void SerializeAndSave<T>(T data, string fileName)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));

        using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
        {
            serializer.Serialize(fileStream, data);
        }
    }

    static Journal InputJournalInfo()
    {
        Console.WriteLine("Enter journal information:");
        Console.Write("Title: ");
        string title = Console.ReadLine();
        Console.Write("Publisher: ");
        string publisher = Console.ReadLine();
        Console.Write("Publication Date: ");
        DateTime publicationDate = DateTime.Parse(Console.ReadLine());
        Console.Write("Number of Pages: ");
        int pageCount = int.Parse(Console.ReadLine());

        return new Journal { Title = title, Publisher = publisher, PublicationDate = publicationDate, PageCount = pageCount };
    }

    static Article InputArticleInfo()
    {
        Console.WriteLine("Enter article information:");
        Console.Write("Title: ");
        string title = Console.ReadLine();
        Console.Write("Character Count: ");
        int characterCount = int.Parse(Console.ReadLine());
        Console.Write("Preview: ");
        string preview = Console.ReadLine();

        return new Article { Title = title, CharacterCount = characterCount, Preview = preview };
    }
}

[Serializable]
public class Journal
{
    public string Title { get; set; }
    public string Publisher { get; set; }
    public DateTime PublicationDate { get; set; }
    public int PageCount { get; set; }
    public List<Article> Articles { get; set; }
}

[Serializable]
public class Article
{
    public string Title { get; set; }
    public int CharacterCount { get; set; }
    public string Preview { get; set; }
}
