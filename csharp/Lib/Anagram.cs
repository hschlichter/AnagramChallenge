using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Security.Cryptography;
using System.Text;

namespace Anagram
{
    public class Helper
    {
        public static List<char> FindUniqueCharacters(string sentence)
        { 
            var characters = new List<char>();
            foreach (var c in sentence)
            {
                if (!char.IsWhiteSpace(c) && !characters.Contains(c))
                {
                    characters.Add(c);
                }
            }

            return characters;
        }

        public static ImmutableList<string> FilterWordsByCharacterSet(ImmutableList<string> words, List<char> characters)
        {
            var filteredWords = ImmutableList.CreateBuilder<string>();
            foreach (var w in words)
            {
                var shouldAdd = true;
                foreach (var c in w.ToCharArray())
                {
                    if (!characters.Contains(c))
                    {
                        shouldAdd = false;
                        break;
                    }
                }

                if (shouldAdd)
                {
                    filteredWords.Add(w);
                }
            }

            return filteredWords.ToImmutable();
        }

        public static ImmutableList<string> FilterWordsByCharacterLength(ImmutableList<string> words, int max, int min)
        {
            var filteredWords = ImmutableList.CreateBuilder<string>();

            foreach (var w in words)
            {
                if (w.Length <= max && w.Length >= min)
                {
                    filteredWords.Add(w);
                }
            }

            return filteredWords.ToImmutable();
        }

        public static Dictionary<char, int> CreateCharacterMap(string sentence)
        {
            var map = new Dictionary<char, int>();
            foreach (var c in sentence.ToCharArray())
            {
                if (char.IsWhiteSpace(c))
                {
                    continue;
                }

                if (map.ContainsKey(c))
                {
                    map[c] += 1;
                }
                else
                {
                    map.Add(c, 1);
                }
            }

            return map;
        }

        public static bool UseWordIfPossible(string word, Dictionary<char, int> characterMap)
        {
            var isPossible = true;
            foreach (var c in word)
            {
                if (!characterMap.ContainsKey(c) || characterMap[c] < 1)
                {
                    isPossible = false;
                }
            }

            if (isPossible)
            {
                foreach (var c in word)
                {
                    characterMap[c] -= 1;
                }

                return true;
            }

            return false;
        }

        public static bool IsCharacterMapEmpty(Dictionary<char, int> map)
        {
            var empty = true;
            foreach (var entry in map)
            {
                if (entry.Value != 0)
                {
                    empty = false;
                }
            }

            return empty;
        }

        private static List<char> GetAvailableCharacterSet(Dictionary<char, int> characterMap)
        {
            var characterSet = new List<char>();
            foreach (var entry in characterMap)
            {
                if (entry.Value > 0)
                {
                    characterSet.Add(entry.Key);
                }
            }

            return characterSet;
        }

        public static int IterationCounter = 0;

        private static void CreateSentencePermutationsNext(List<string> permutations, ImmutableList<string> sentence, ImmutableList<string> words, Dictionary<char, int> characterMap)
        {
            IterationCounter++;
            for (var i = 0; i < words.Count; i++)
            {
                var word = words[i];
                var localCharacterMap = new Dictionary<char, int>(characterMap);

                if (UseWordIfPossible(word, localCharacterMap))
                {
                    var newSentence = sentence.Add(word);
                    var newWords = words.RemoveAt(i);

                    if (IsCharacterMapEmpty(localCharacterMap))
                    {
                        permutations.Add(string.Join(" ", newSentence));
                    }
                    else if (newSentence.Count >= 4)
                    {
                        continue;
                    }

                    var localCharacterSet = GetAvailableCharacterSet(localCharacterMap);
                    newWords = FilterWordsByCharacterSet(newWords, localCharacterSet);

                    if (newWords.Count == 0)
                    {
                        continue;
                    }

                    CreateSentencePermutationsNext(
                        permutations,
                        newSentence,
                        newWords,
                        localCharacterMap
                    );
                }
            }
        }

        public static List<string> CreateSentencePermutations(ImmutableList<string> words, Dictionary<char, int> characterMap)
        {
            var permutations = new List<string>();

            CreateSentencePermutationsNext(
                permutations,
                ImmutableList.Create<string>(),
                words,
                characterMap
            );

            return permutations;
        }

        public static bool SentenceHashValidation(string sentence, string hash)
        {
            using (var md5 = MD5.Create())
            {
                var val = Encoding.UTF8.GetBytes(sentence);
                var data = md5.ComputeHash(val);

                var sb = new StringBuilder();
                for (var i = 0; i < data.Length; i++)
                {
                    sb.Append(data[i].ToString("x2"));
                }

                if (sb.ToString() == hash)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
