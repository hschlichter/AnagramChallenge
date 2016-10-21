using System;
using System.IO;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string sentence = args[0];
            string validationHash = args[1];
            string[] lines = File.ReadAllLines(@"../wordlist");
            var wordlist = new List<string>(lines);
            Console.WriteLine($"Number of words in wordlist: {wordlist.Count}");

            // 1. Find unique characters in sentence.
            var characters = Anagram.Helper.FindUniqueCharacters(sentence);
            Console.WriteLine($"Unique characters in sentence: {characters.Count}");

            // 3. Filter words that has characters not part of the subset.
            wordlist = Anagram.Helper.FilterWordsByCharacterSet(wordlist, characters);
            Console.WriteLine($"wordlist size after filtering on unique character: {wordlist.Count}");

            // 4. Filter words character lengths outside the a maximum and minimum bounds.
            wordlist = Anagram.Helper.FilterWordsByCharacterLength(wordlist, 4, 3);
            Console.WriteLine($"wordlist size after filtering on length: {wordlist.Count}");

            // 5. Create map of per character availablility.
            var characterMap = Anagram.Helper.CreateCharacterMap(sentence);

            // 8. Create all permutations of words.
            var permutations = Anagram.Helper.CreateSentencePermutations(wordlist, characterMap);
            Console.WriteLine($"Permutations count: {permutations.Count}");

            // 9. Run hash validation on all.
            foreach (var p in permutations)
            {
                if (Anagram.Helper.SentenceHashValidation(p, validationHash))
                {
                    Console.WriteLine(p);
                    break;
                }
            }

            Console.WriteLine("Done!");
        }
    }
}
