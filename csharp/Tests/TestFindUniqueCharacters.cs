using Xunit;

namespace Tests
{
    public class TestFindUniqueCharacters
    {
        [Fact]
        public void Whitespace() 
        {
            var sentence = "hello world";
            var expected = new char[] { 'h', 'e', 'l', 'o', 'w', 'r', 'd' };
            var result = Anagram.Helper.FindUniqueCharacters(sentence);
            Assert.Equal(result, expected);
        }

        [Fact]
        public void WhitespaceTab() 
        {
            var sentence = "hello   world";
            var expected = new char[] { 'h', 'e', 'l', 'o', 'w', 'r', 'd' };
            var result = Anagram.Helper.FindUniqueCharacters(sentence);
            Assert.Equal(result, expected);
        }

        [Fact]
        public void NoWhitespace() 
        {
            var sentence = "hello";
            var expected = new char[] { 'h', 'e', 'l', 'o' };
            var result = Anagram.Helper.FindUniqueCharacters(sentence);
            Assert.Equal(result, expected);
        }

        [Fact]
        public void MultipleWhitespaces() 
        {
            var sentence = "hello  world";
            var expected = new char[] { 'h', 'e', 'l', 'o', 'w', 'r', 'd' };
            var result = Anagram.Helper.FindUniqueCharacters(sentence);
            Assert.Equal(result, expected);
        }

        [Fact]
        public void LeadingWhitespaces() 
        {
            var sentence = "  hello";
            var expected = new char[] { 'h', 'e', 'l', 'o' };
            var result = Anagram.Helper.FindUniqueCharacters(sentence);
            Assert.Equal(result, expected);
        }

        [Fact]
        public void TrailingWhitepaces() 
        {
            var sentence = "hello   ";
            var expected = new char[] { 'h', 'e', 'l', 'o' };
            var result = Anagram.Helper.FindUniqueCharacters(sentence);
            Assert.Equal(result, expected);
        }

        [Fact]
        public void LeadingSpaces() 
        {
            var sentence = "hello";
            var expected = new char[] { 'h', 'e', 'l', 'o' };
            var result = Anagram.Helper.FindUniqueCharacters(sentence);
            Assert.Equal(result, expected);
        }
    }
}
