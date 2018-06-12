using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {

            // Prompts user for input
            Console.Out.WriteLine("Enter phrase to be translated:");
            // Stores input
            string input = Console.ReadLine();

            // Translates the input
            input = PigLatin.Translate(input);

            // Prints output
            Console.Out.WriteLine("Translation:\n" + input);

            // Pause
            Console.ReadLine();

        }
    }

    /// <summary>
    /// Stores methods for translating between English and Pig Latin.
    /// </summary>
    static class PigLatin
    {
        // Stores all vowels
        private static readonly string[] VOWELS      = { "A", "E", "I", "O", "U" };
        // Stores all punctuation
        private static readonly string[] PUNCTUATION = { ".", ",", "?", "!" };

        /// <summary>
        /// Translates a sentence into pig latin.
        /// </summary>
        /// <param name="phrase"></param>
        /// <returns></returns>
        public static string Translate(string phrase)
        {
            // Returns nothing if the input is nothing
            if (phrase == null || phrase.Equals(""))
                return "";

            // Splits the sentence into words by spaces and makes it lowercase
            string[] sentence = phrase.ToLower().Split(' ');
            // Creates a variable to store the output
            string output = "";

            // Runs through each word
            foreach (string w in sentence)
            {
                // Makes a copy of the word so it can be changed
                string word = (string)w.Clone();

                // Stores any punctuation that is found
                string punct = "";
                // If punctuation exists at the end of the word (this is the only place it will exist in a sentence)
                if (PUNCTUATION.Contains(word[word.Length - 1].ToString()))
                {
                    // Stores the punctuation
                    punct = word[word.Length - 1].ToString();
                    // Cuts out the punctuation from the word
                    word = word.Substring(0, word.Length - 1);
                }
                // Translates the word, then adds the punctuation (if any) and a space for the next word
                output += TranslateWord(word) + punct + " ";
            }

            return output.Substring(0, output.Length - 1);
        }

        /// <summary>
        /// Translates a single word into pig latin
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string TranslateWord(string input)
        {
            // Stores the first letter of the word
            string first = input.Substring(0, 1);

            // If the first letter is a vowel it just adds "yay" and returns
            if (VOWELS.Contains( first.ToUpper() ))
            {
                return input + "yay";
            }
            // This runs if the first letter is y or a consanant
            else
            {
                // Starts iterating at index 1
                int start = 1;
                // Finds the current letter
                string current = input.Substring(start, 1);

                // While the start is not past the end of the string, the current letter is not a vowel, and the current letter is not a "Y"
                while (start < input.Length
                       && !VOWELS.Contains(current.ToUpper())
                       && !current.ToUpper().Equals("Y"))
                {
                    // Iterates
                    start++;
                    // Finds the current letter if it is not too far
                    if (start < input.Length)
                        current = input.Substring(start, 1);
                }

                // If the iteration reached the end, the word is all consanants
                if (start == input.Length)
                {
                    // Takes all letter but the last and moves them to the end and then adding "ay"
                    return input[input.Length - 1] + input.Substring(0, input.Length - 1) + "ay";
                }
                // The iteration did not reach the end of the word
                else
                {
                    // Moves the whole block that was iterated thorugh to the end and adds "ay"
                    return input.Substring(start, input.Length - start) + input.Substring(0, start) + "ay";
                }
            }
        }

    }
}
