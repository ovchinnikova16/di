using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Moq;

namespace TagsCloudVisualization.Tests
{
    [TestFixture]
    public class Parser_Should
    {
        private Mock<IWordsSelector> selector;
        private WordsParser parser;

        [SetUp]
        public void SetUp()
        {
            selector = new Mock<IWordsSelector>();
            parser = new WordsParser(2, selector.Object);
        }
        [Test]
        public void WordsParser_GetFreqency_SelectorCallsOnse()
        {
            var text = new Reader("text.txt").ReadFromFile();
            parser.GetFrequency(text);
            selector.Verify(r => r.SelectWords(text), Times.Once());
        }

        [Test]
        public void WordsParser_GetFreqency_CorrectInitialForm()
        {
            var words = new List<string>() {"test", "tests"}.AsEnumerable();
            selector.Setup(s => s.SelectWords(It.IsAny<IEnumerable<string>>()))
                .Returns<IEnumerable<string>>(w => w);

            var frequency = parser.GetFrequency(words);

            frequency.Count.Should().Be(1);
            frequency["test"].Should().Be(2);
        }

        [Test]
        public void WordsParser_GetFreqency_CorrectWordsNumber()
        {
            var words = new List<string>() { "test", "tests", "qwer", "zxcv" }.AsEnumerable();
            selector.Setup(s => s.SelectWords(It.IsAny<IEnumerable<string>>()))
                .Returns<IEnumerable<string>>(w => w);

            var frequency = parser.GetFrequency(words);

            frequency.Count.Should().Be(2);
            Assert.True(frequency.ContainsKey("test"));
        }

    }
}
