using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Xunit;

namespace Tests
{
    public class TestCreateSentencePermutations
    {
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
            var words = ImmutableList.Create("hello", "world", "fubar");
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
        public void OnlyUseAvailableCharacters()
        {
            var words = ImmutableList.Create("hello", "world", "fubar", "this" );
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
            var words = ImmutableList.Create("hello", "world", "fubar", "this");
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
