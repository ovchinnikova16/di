using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace TagsCloudVisualization
{
    public class CircularCloudLayouter : ICircularCloudLayouter
    {
        private Point cloudCenter;
        private readonly List<Rectangle> rectangles;
        private readonly IRectangleLocator rectangleLocator;

        public CircularCloudLayouter(IRectangleLocator rectangleLocator, Point cloudCenter)
        {
            this.cloudCenter = cloudCenter;
            rectangles = new List<Rectangle>();
            this.rectangleLocator = rectangleLocator;
        }

        public Rectangle PutNextRectangle(Size rectangleSize)
        {
            if (rectangleSize.Width <= 0 || rectangleSize.Height <= 0)
                throw new ArgumentException("Rectangle size is not positive");

            var rectangle = new Rectangle(rectangleLocator.FindLocation(rectangleSize, rectangles), rectangleSize);
            rectangles.Add(rectangle);
            return rectangle;
        }
    }
}
