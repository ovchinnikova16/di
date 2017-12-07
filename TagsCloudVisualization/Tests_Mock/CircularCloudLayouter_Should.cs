using System.Drawing;
using Moq;
using NUnit.Framework;

namespace TagsCloudVisualization.Tests
{
    [TestFixture]
    public class CircularCloudLayouter_Should
    {
        private Mock<IRectangleLocator> locator;
        private CircularCloudLayouter layouter;

        [SetUp]
        public void SetUp()
        {
            locator = new Mock<IRectangleLocator>();
            layouter = new CircularCloudLayouter(locator.Object);
        }

        [Test]
        public void CircularCloudLayouter_PutOneRectangle()
        {
            layouter.PutNextRectangle(new Size(2, 2));
            locator.Verify(lw => lw.FindLocation(new Size(2, 2)), Times.Once());
        }

        [Test]
        public void CircularCloudLayouter_PutSeveralRectangles()
        {
            layouter.PutNextRectangle(new Size(2, 2));
            layouter.PutNextRectangle(new Size(2, 2));
            locator.Verify(loc => loc.FindLocation(new Size(2, 2)), Times.Exactly(2));

        }
    }
}
