using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kewords_Typing_Learner
{
    internal class ConsoleOperation
    {
        static void ReadFromConsole(HashSet<string> _words)
        {
            Console.WriteLine("Enter new word:");
            string word = Console.ReadLine();

            if (!string.IsNullOrEmpty(word))
            {
                // Remove any leading or trailing punctuation
                string cleanedWord = word.Trim(new char[] { ' ', ',', '.', ';', ':', '!', '?' });

                // Add the cleaned word to the HashSet
                _words.Add(cleanedWord);

                // You can optionally display the unique words here
                Console.WriteLine("Unique words entered so far:");
                foreach (string uniqueWord in _words)
                {
                    Console.WriteLine(uniqueWord);
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid word.");
            }
        }
    }
}
