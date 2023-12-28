using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kewords_Typing_Learner
{
     internal static class FileOperation {

        // READ FROM FILE
        public static void ReadFileFromPath(General general)

        {
            HashSet<string> _words = general.GetWords();
            Console.WriteLine("Enter the path to the file:");
            string filePath = Console.ReadLine();
            filePath = filePath.Trim(new char[] { '"', '?', '<', '>', '|' }) ;

            // Clear existing words before reading new ones
            _words.Clear();
            _words = ReadWordsFromFile(filePath, _words);

            Console.WriteLine("Words read from the file:");
            foreach (string word in _words)
            {
                Console.WriteLine(word);
            }
        }
        private static HashSet<string> ReadWordsFromFile(string filePath, HashSet<string> lineWords)
        {
            HashSet<string> uniqueWords = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            try
            {
                // Use File.ReadAllLines to read all lines from a file
                string[] wordsFromFile = File.ReadAllLines(filePath);

                foreach (string word in wordsFromFile)
                {
                    // Remove any leading or trailing punctuation
                    char[] charsToRemove = { ' ', '"', ',', '.', ';', ':', '!', '\\', '/', '(', ')', '@', '#', '$', '%', '^', '&', '*', '_', '-', '+', '=', '~', '`', ']', '[', '{', '}', '?', '>', '<' };

                    string cleanedWord = new string(word.Where(c => !charsToRemove.Contains(c)).ToArray());

                    // Add the cleaned word to the HashSet if it's not empty
                    if (!string.IsNullOrEmpty(cleanedWord))
                    {
                        // Use HashSet.Add directly instead of checking Contains
                        uniqueWords.Add(cleanedWord);
                        
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


        // WRITE TO FILE
        public static void WriteWordsToFile(General general)
        {
            HashSet<string> _words = general.GetWords();
            string downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Documents";
            string filePath = Path.Combine(downloadsFolder, "output.txt");

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (string word in _words)
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

    }
}
