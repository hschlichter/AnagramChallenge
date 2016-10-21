using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class TestCreateCharacterMap
    {
        [Fact]
        public void NoWhitespace()
        {
            var sentence = "helloworld";
            var expected = new Dictionary<char, int> {
                { 'h', 1 },
                { 'e', 1 },
                { 'l', 3 },
                { 'o', 2 },
                { 'w', 1 },
                { 'r', 1 },
                { 'd', 1 }
            };

            var result = Anagram.Helper.CreateCharacterMap(sentence);
            Assert.Equal(result, expected);
        }

        [Fact]
        public void WithWhitespace()
        {
            var sentence = "hello world";
            var expected = new Dictionary<char, int> {
                { 'h', 1 },
                { 'e', 1 },
                { 'l', 3 },
                { 'o', 2 },
                { 'w', 1 },
                { 'r', 1 },
                { 'd', 1 }
            };

            var result = Anagram.Helper.CreateCharacterMap(sentence);
            Assert.Equal(result, expected);
        }
    }
}
