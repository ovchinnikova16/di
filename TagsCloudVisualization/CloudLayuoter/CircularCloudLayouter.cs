using System;
using System.Drawing;

namespace TagsCloudVisualization
{
    public class CircularCloudLayouter : ICircularCloudLayouter
    {
        private readonly IRectangleLocator rectangleLocator;

        public CircularCloudLayouter(IRectangleLocator rectangleLocator)
        {
            this.rectangleLocator = rectangleLocator;
        }

        public Result<Rectangle> PutNextRectangle(Size rectangleSize)
        {
            if (rectangleSize.Width <= 0 || rectangleSize.Height <= 0)
                return Result.Fail<Rectangle>("Size of rectangle is negative");

            return Result.Ok(rectangleLocator.FindLocation(rectangleSize));
        }
    }
}
