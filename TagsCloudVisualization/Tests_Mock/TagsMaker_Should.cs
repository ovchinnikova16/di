using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace TagsCloudVisualization.Tests
{
    public class TagsMaker_Should
    {
        [Test]
        public void MakeTags_TagsInCorrectOrder()
        {
            var layouter = new Mock<ICircularCloudLayouter>();
            layouter.Setup(a => a.PutNextRectangle(It.IsAny<Size>()))
                .Returns<Size>(s => new Rectangle(new Point(), s));

            var tagsMaker = new TagsMaker(layouter.Object, new FontFamily("Arial"));
            var dict = new Dictionary<string, int> { { "a", 5 }, { "b", 1 }, { "c", 3 } };
            var dictRect = tagsMaker.MakeTags(dict);

            dictRect[0].Word.Should().Be("a");
            dictRect[2].Word.Should().Be("b");
        }
    }
}
