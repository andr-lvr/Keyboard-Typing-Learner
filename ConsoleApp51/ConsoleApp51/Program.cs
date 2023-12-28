using System;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class Fraction
{
    public int Numerator { get; set; }
    public int Denominator { get; set; }

    public Fraction() { }

    public Fraction(int numerator, int denominator)
    {
        Numerator = numerator;
        Denominator = denominator;
    }

    public override string ToString()
    {
        return $"{Numerator}/{Denominator}";
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the size of the fraction array:");
        int size = int.Parse(Console.ReadLine());

        Fraction[] fractions = new Fraction[size];

        // Input fractions from the keyboard
        for (int i = 0; i < size; i++)
        {
            Console.WriteLine($"Enter the numerator for fraction {i + 1}:");
            int numerator = int.Parse(Console.ReadLine());

            Console.WriteLine($"Enter the denominator for fraction {i + 1}:");
            int denominator = int.Parse(Console.ReadLine());

            fractions[i] = new Fraction(numerator, denominator);
        }

        // Serialization
        Console.WriteLine("Choose serialization format (xml/binary):");
        string serializationFormat = Console.ReadLine();

        SerializeAndSave(fractions, serializationFormat);

        // Load and Deserialize
        Fraction[] loadedFractions = LoadAndDeserialize(serializationFormat);

        // Display the deserialized result
        Console.WriteLine("\nDeserialized fraction array:");
        foreach (var fraction in loadedFractions)
        {
            Console.WriteLine(fraction);
        }
    }

    static void SerializeAndSave(Fraction[] fractions, string format)
    {
        switch (format.ToLower())
        {
            case "xml":
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Fraction[]));
                using (TextWriter writer = new StreamWriter("fractions.xml"))
                {
                    xmlSerializer.Serialize(writer, fractions);
                }
                break;
            case "binary":
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (Stream stream = new FileStream("fractions.dat", FileMode.Create, FileAccess.Write))
                {
                    binaryFormatter.Serialize(stream, fractions);
                }
                break;
            default:
                Console.WriteLine("Unknown serialization format.");
                break;
        }
    }

    static Fraction[] LoadAndDeserialize(string format)
    {
        switch (format.ToLower())
        {
            case "xml":
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Fraction[]));
                using (TextReader reader = new StreamReader("fractions.xml"))
                {
                    return (Fraction[])xmlSerializer.Deserialize(reader);
                }
            case "binary":
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (Stream stream = new FileStream("fractions.dat", FileMode.Open, FileAccess.Read))
                {
                    return (Fraction[])binaryFormatter.Deserialize(stream);
                }
            default:
                Console.WriteLine("Unknown deserialization format.");
                return null;
        }
    }
}
