using System.Collections.Generic;
using System.Drawing;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace TagsCloudVisualization.Tests
{
    public class TagsMaker_Should
    {
        private TagsMaker tagsMaker;
        private Dictionary<string, int> dict;

        [SetUp]
        public void SetUp()
        {
            var layouter = new Mock<ICircularCloudLayouter>();
            layouter.Setup(a => a.PutNextRectangle(It.IsAny<Size>()))
                .Returns<Size>(s => new Rectangle(new Point(), s));

            tagsMaker = new TagsMaker(layouter.Object, new FontFamily("Arial"));
            dict = new Dictionary<string, int> { { "a", 5 }, { "b", 1 }, { "c", 3 } };
        }

        [Test]
        public void MakeTags_TagsInCorrectOrder()
        {
            var dictRect = tagsMaker.MakeTags(dict);

            dictRect[0].Word.Should().Be("a");
            dictRect[2].Word.Should().Be("b");
        }

        [Test]
        public void MakeTags_CorrectRectangleSize()
        {
            var dictRect = tagsMaker.MakeTags(dict);

            dictRect[0].Rectangle.Size.Height.Should()
                .BeGreaterThan(dictRect[1].Rectangle.Size.Height);
        }
    }
}
