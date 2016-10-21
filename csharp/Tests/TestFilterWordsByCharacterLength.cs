using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class TestFilterWordsByCharacterLength
    {
        List<string> words;

        public TestFilterWordsByCharacterLength()
        {
            words = new List<string> { "hello", "world", "hey", "you", "this", "is", "fubar" };
        }

        [Fact]
        public void NoWordsCharacterLengthLargerThan4()
        {
            var expected = new List<string> { "hey", "you", "this", "is" };

            var result = Anagram.Helper.FilterWordsByCharacterLength(this.words, 4, 0);
            Assert.Equal(result, expected);
        }

        [Fact]
        public void NoWordsCharacterLengthLessThan4()
        {
            var expected = new List<string> { "hello", "world", "this", "fubar" };

            var result = Anagram.Helper.FilterWordsByCharacterLength(this.words, 100, 4);
            Assert.Equal(result, expected);
        }

        [Fact]
        public void WordsWithCharacterLengthBetween3and4()
        {
            var expected = new List<string> { "hey", "you", "this" };

            var result = Anagram.Helper.FilterWordsByCharacterLength(this.words, 4, 3);
            Assert.Equal(result, expected);
        }
    }
}
