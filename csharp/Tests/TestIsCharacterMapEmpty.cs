using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class TestIsCharacterMapEmpty
    {
        [Fact]
        public void Empty()
        {
            var map = new Dictionary<char, int> {
                { 'h', 0 },
                { 'e', 0 },
                { 'l', 0 },
                { 'o', 0 },
                { 'w', 0 },
                { 'r', 0 },
                { 'd', 0 }
            };

            var result = Anagram.Helper.IsCharacterMapEmpty(map);
            Assert.True(result);
        }

        [Fact]
        public void NonEmpty()
        {
            var map = new Dictionary<char, int> {
                { 'h', 1 },
                { 'e', 1 },
                { 'l', 3 },
                { 'o', 2 },
                { 'w', 1 },
                { 'r', 1 },
                { 'd', 1 }
            };

            var result = Anagram.Helper.IsCharacterMapEmpty(map);
            Assert.False(result);
        }
    }
}
