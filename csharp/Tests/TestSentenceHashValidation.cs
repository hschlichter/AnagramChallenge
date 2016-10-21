using Xunit;

namespace Tests
{
    public class TestSentenceHashValidation
    {
        [Fact]
        public void Simple1()
        {
            var sentence = "hello world fubar";
            var hash = "f45676fbab37ab336a3888eed0d8caf4";

            var result = Anagram.Helper.SentenceHashValidation(sentence, hash);
            Assert.True(result);
        }

        [Fact]
        public void Simple2()
        {
            var sentence = "hello world";
            var hash = "5eb63bbbe01eeed093cb22bb8f5acdc3";

            var result = Anagram.Helper.SentenceHashValidation(sentence, hash);
            Assert.True(result);
        }

        [Fact]
        public void Simple3()
        {
            var sentence = "this is hello world fubar yippie kay yay";
            var hash = "c6d1d339060f114aff2a7c551514dca2";

            var result = Anagram.Helper.SentenceHashValidation(sentence, hash);
            Assert.True(result);
        }
    }
}
