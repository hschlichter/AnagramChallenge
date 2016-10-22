using System.Collections.Generic;
using System.Collections.Immutable;
using Xunit;

namespace Tests
{
    public class TestFilterWordsByCharacterSet
    {
        ImmutableList<string> words;
        List<char> characters;

        public TestFilterWordsByCharacterSet()
        {
            words = ImmutableList.Create<string>("hello", "world", "hey", "you", "this", "is", "fubar");
            characters = new List<char> { 'h', 'e', 'l', 'o', 'y', 'u' };
        }

        [Fact]
        public void Simple()
        {
            var expected = ImmutableList.Create<string>("hello", "hey", "you");

            var result = Anagram.Helper.FilterWordsByCharacterSet(this.words, this.characters);
            Assert.Equal(result, expected);
        }
    }
}
