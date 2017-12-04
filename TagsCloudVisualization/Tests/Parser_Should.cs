using System.Linq;
using NUnit.Framework;
using Moq;

namespace TagsCloudVisualization.Tests
{
    [TestFixture]
    public class Parser_Should
    {
        [Test]
        public void WordsParser_GetFreqency()
        {
            var selector = new Mock<IWordsSelector>();
            var reader = new Mock<IReader>();
            var parser = new WordsParser(100, selector.Object);
            var text = new Reader("text.txt").ReadFromFile();
            parser.GetFrequency(text);
            selector.Verify(r => r.SelectWords(text), Times.Once());
        }
    }
}
