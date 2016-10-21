using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class TestFilterWordsByCharacterSet
    {
        List<string> words;
        List<char> characters;

        public TestFilterWordsByCharacterSet()
        {
            words = new List<string> { "hello", "world", "hey", "you", "this", "is", "fubar" };
            characters = new List<char> { 'h', 'e', 'l', 'o', 'y', 'u' };
        }

        [Fact]
        public void Simple()
        {
            var expected = new List<string> { "hello", "hey", "you" };

            var result = Anagram.Helper.FilterWordsByCharacterSet(this.words, this.characters);
            Assert.Equal(result, expected);
        }
    }
}
