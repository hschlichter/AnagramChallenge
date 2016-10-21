using System;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class TestCreateSentencePermutations
    {
        List<string> words;
        Dictionary<char, int> characterMap;

        public TestCreateSentencePermutations()
        {
            this.characterMap = new Dictionary<char, int>() {
                { 'h', 1 },
                { 'e', 1 },
                { 'l', 3 },
                { 'o', 2 },
                { 'w', 1 },
                { 'r', 2 },
                { 'd', 1 },
                { 'f', 1 },
                { 'u', 1 },
                { 'b', 1 },
                { 'a', 1 }
            };
        }

        [Fact]
        public void FindAllPermutations()
        {
            this.words = new List<string> { "hello", "world", "fubar" };
            var expected = new List<string> {
                "hello world fubar",
                "hello fubar world",
                "world hello fubar",
                "world fubar hello",
                "fubar hello world",
                "fubar world hello"
            };

            var result = Anagram.Helper.CreateSentencePermutations(this.words, this.characterMap);
            Assert.Equal(result, expected);
        }

        [Fact]
        public void OnlyUseAvailableCharacters()
        {
            var words = new List<string> { "hello", "world", "fubar", "this" };
            var expected = new List<string> {
                "hello world fubar",
                "hello fubar world",
                "world hello fubar",
                "world fubar hello",
                "fubar hello world",
                "fubar world hello"
            };

            var result = Anagram.Helper.CreateSentencePermutations(words, this.characterMap);
            Assert.Equal(result, expected);
        }

        [Fact]
        public void ThatItTerminatesWhenCharacterMapIsntEmpty()
        {
            var words = new List<string> { "hello", "world", "fubar", "this" };
            this.characterMap = new Dictionary<char, int>() {
                { 'h', 2 },
                { 'e', 2 },
                { 'l', 3 },
                { 'o', 2 },
                { 'w', 1 },
                { 'r', 2 },
                { 'd', 1 },
                { 'f', 1 },
                { 'u', 1 },
                { 'b', 1 },
                { 'a', 1 }
            };
            var expected = new List<string>();

            var result = Anagram.Helper.CreateSentencePermutations(words, this.characterMap);
            Assert.Equal(result, expected);
        }
    }
}
