using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TagsCloudVisualization
{
    public class RectangleLocator : IRectangleLocator
    {
        private readonly Point cloudCenter;
        private readonly List<Rectangle> rectangles;

        public RectangleLocator(Point cloudCenter)
        {
            this.cloudCenter = cloudCenter;
            rectangles = new List<Rectangle>();
        }

        public Rectangle FindLocation(Size rectangleSize)
        {
            if (rectangles.Count == 0)
            {
                var shiftX = rectangleSize.Width / 2;
                var shiftY = rectangleSize.Height / 2;
                var location = new Point(cloudCenter.X - shiftX, cloudCenter.Y - shiftY);
                var firstRectangle = new Rectangle(location, rectangleSize);
                rectangles.Add(firstRectangle);
                return firstRectangle;
            }

            var points = GetTop().GetEnumerator();
            points.MoveNext();
            var rectangle = new Rectangle(points.Current, rectangleSize);
            while (rectangles.Any(rect => rect.IntersectsWith(rectangle)))
            {
                points.MoveNext();
                rectangle.X = points.Current.X;
                rectangle.Y = points.Current.Y;
            }

            var newRectangle = new Rectangle(points.Current, rectangleSize);
            rectangles.Add(rectangle);
            return newRectangle;
        }

        private IEnumerable<Point> GetTop()
        {
            var distance = 0;
            while (true)
            {
                for (int i = 0; i < 360; i += 10)
                {
                    yield return
                        new Point(
                            cloudCenter.X + Convert.ToInt32(distance * Math.Cos(i / Math.PI * 180)),
                            cloudCenter.Y + Convert.ToInt32(distance * Math.Sin(i / Math.PI * 180))
                        );
                }
                distance += 1;
            }
        }
    }
}
