using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kewords_Typing_Learner
{
    internal class App
    {
        // variables

        // general 
        private void ReadFileFromPath()
        {
            Console.WriteLine("Enter the path to the file:");
            string filePath = Console.ReadLine();

            List<string> words = ReadWordsFromFile(filePath);

            Console.WriteLine("Words read from the file:");
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }

        }

        static List<string> ReadWordsFromFile(string filePath)
        {
            List<string> words = new List<string>();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] lineWords = line.Split(' ');

                        foreach (string word in lineWords)
                        {
                            // Remove any leading or trailing punctuation
                            string cleanedWord = word.Trim(new char[] { ' ', ',', '.', ';', ':', '!', '?' });

                            // Add the cleaned word to the list if it's not empty
                            if (!string.IsNullOrEmpty(cleanedWord))
                            {
                                words.Add(cleanedWord);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
                // You may choose to handle the exception differently based on your requirements.
            }

            return words;
        }

        static void WriteWordsToFile(List<string> words, string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (string word in words)
                    {
                        writer.WriteLine(word);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
                // You may choose to handle the exception differently based on your requirements.
            }
        }

        // read from file

        // push into arr

        // add own words
        // save into file
        // check for repeats


        static void Main()
        {
            

           
        }

        


        // learn typing 
        // score 
        // time count






    }
}
