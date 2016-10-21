using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class TestUseWordIfPossible
    {
        Dictionary<char, int> characterMap;

        public TestUseWordIfPossible()
        {
            this.characterMap = new Dictionary<char, int>() {
                { 'h', 1 },
                { 'e', 1 },
                { 'l', 3 },
                { 'o', 2 },
                { 'w', 1 },
                { 'r', 1 },
                { 'd', 1 }
            };
        }

        [Fact]
        public void WordIsPossible()
        {
            var word = "hello";
            var expected = new Dictionary<char, int>() {
                { 'h', 0 },
                { 'e', 0 },
                { 'l', 1 },
                { 'o', 1 },
                { 'w', 1 },
                { 'r', 1 },
                { 'd', 1 }
            };

            Assert.True(Anagram.Helper.UseWordIfPossible(word, this.characterMap));
            Assert.Equal(this.characterMap, expected);
        }

        [Fact]
        public void WordIsNotPossible()
        {
            var word = "fubar";
            var expected = new Dictionary<char, int>() {
                { 'h', 1 },
                { 'e', 1 },
                { 'l', 3 },
                { 'o', 2 },
                { 'w', 1 },
                { 'r', 1 },
                { 'd', 1 }
            };

            Assert.False(Anagram.Helper.UseWordIfPossible(word, this.characterMap));
            Assert.Equal(this.characterMap, expected);
        }
    }
}
