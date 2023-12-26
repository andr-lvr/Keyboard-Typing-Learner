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
        // Use meaningful names and follow camelCase convention
        private HashSet<string> words = new HashSet<string>();

        // Use a more descriptive method name
        public void ReadFileFromPath()
        {
            Console.WriteLine("Enter the path to the file:");
            string filePath = Console.ReadLine();

            // Clear existing words before reading new ones
            words.Clear();
            words = ReadWordsFromFile(filePath, words);

            Console.WriteLine("Words read from the file:");
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }

        private HashSet<string> ReadWordsFromFile(string filePath, HashSet<string> lineWords)
        {
            HashSet<string> uniqueWords = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            try
            {
                // Use File.ReadAllLines to read all lines from a file
                string[] wordsFromFile = File.ReadAllLines(filePath);

                foreach (string word in wordsFromFile)
                {
                    // Remove any leading or trailing punctuation
                    string cleanedWord = word.Trim(new char[] { ' ', ',', '.', ';', ':', '!', '?' });

                    // Add the cleaned word to the HashSet if it's not empty
                    if (!string.IsNullOrEmpty(cleanedWord))
                    {
                        // Use HashSet.Add directly instead of checking Contains
                        if (uniqueWords.Add(cleanedWord))
                        {
                            // Handle repeated word (you can log or take any other action)
                            Console.WriteLine($"Repeated word: {cleanedWord}");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
                // You may choose to handle the exception differently based on your requirements.
            }

            return uniqueWords;
        }


        public void WriteWordsToFile()
        {
            string downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Documents";
            string filePath = Path.Combine(downloadsFolder, "output.txt");

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (string word in words)
                    {
                        writer.WriteLine(word);
                    }
                }

                Console.WriteLine($"File written successfully to: {filePath}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
                // You may choose to handle the exception differently based on your requirements.
            }
        }

        

        // add own words

        // check for repeats





        // learn typing 
        // score 
        // time count






    }
}
