using System.Drawing;
using Moq;
using NUnit.Framework;

namespace TagsCloudVisualization.Tests
{
    [TestFixture]
    public class CircularCloudLayouter_Should
    {
        [Test]
        public void CircularCloudLayouter_PutOneRectangle()
        {
            var locator = new Mock<IRectangleLocator>();
            var layouter = new CircularCloudLayouter(locator.Object);
            layouter.PutNextRectangle(new Size(2, 2));
            locator.Verify(lw => lw.FindLocation(new Size(2, 2)), Times.Once());
        }

        [Test]
        public void CircularCloudLayouter_PutSeveralRectangles()
        {
            var locator = new Mock<IRectangleLocator>();
            var layouter = new CircularCloudLayouter(locator.Object);
            layouter.PutNextRectangle(new Size(2, 2));
            layouter.PutNextRectangle(new Size(2, 2));
            locator.Verify(loc => loc.FindLocation(new Size(2, 2)), Times.Exactly(2));

        }
    }
}
