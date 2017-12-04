using System;
using System.Collections.Generic;
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

        public Rectangle PutNextRectangle(Size rectangleSize)
        {
            if (rectangleSize.Width <= 0 || rectangleSize.Height <= 0)
                throw new ArgumentException("Rectangle size is not positive");

            var rectangle = rectangleLocator.FindLocation(rectangleSize);
            return rectangle;
        }
    }
}
