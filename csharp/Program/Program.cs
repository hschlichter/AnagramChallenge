using System;
using System.IO;
using System.Collections.Immutable;

namespace ConsoleApplication
{
    public class Program
    {
        public const int WordMaxCharacterLength = 8;
        public const int WordMinCharacterLength = 4;
        public const int SentenceMaxWords = 3;

        public static void Main(string[] args)
        {
            string sentence = args[0];
            string validationHash = args[1];
            string[] lines = File.ReadAllLines(@"../wordlist");
            var wordlist = ImmutableList.Create<string>(lines);
            Console.WriteLine($"Number of words in wordlist: {wordlist.Count}");

            // 1. Find unique characters in sentence.
            var characters = Anagram.Helper.FindUniqueCharacters(sentence);
            Console.WriteLine($"Unique characters in sentence: {characters.Count}");

            // 3. Filter words that has characters not part of the subset.
            wordlist = Anagram.Helper.FilterWordsByCharacterSet(wordlist, characters);
            Console.WriteLine($"wordlist size after filtering on unique character: {wordlist.Count}");

            // 4. Filter words character lengths outside the a maximum and minimum bounds.
            wordlist = Anagram.Helper.FilterWordsByCharacterLength(wordlist, WordMaxCharacterLength, WordMinCharacterLength);
            Console.WriteLine($"wordlist size after filtering on length: {wordlist.Count}");

            // 5. Create map of per character availablility.
            var characterMap = Anagram.Helper.CreateCharacterMap(sentence);

            // 8. Create all permutations of words.
            // var permutations = Anagram.Helper.CreateSentencePermutations(wordlist, characterMap, SentenceMaxWords);
            var permutations = Anagram.Helper.CreateSentencePermutationsParallel(wordlist, characterMap, SentenceMaxWords, 8);
            Console.WriteLine($"Permutations count: {permutations.Count}");

            // 9. Run hash validation on all.
            foreach (var p in permutations)
            {
                if (Anagram.Helper.SentenceHashValidation(p, validationHash))
                {
                    Console.WriteLine($"Found match!! - {p}");
                    break;
                }
            }

            Console.WriteLine("Done!");
        }
    }
}
