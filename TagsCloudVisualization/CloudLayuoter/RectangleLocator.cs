using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TagsCloudVisualization
{
    public class RectangleLocator : IRectangleLocator
    {
        private readonly Point cloudCenter;

        public RectangleLocator(Point cloudCenter)
        {
            this.cloudCenter = cloudCenter;
        }

        public Point FindLocation(Size rectangleSize, List<Rectangle> rectangles)
        {
            if (rectangles.Count == 0)
            {
                var shiftX = rectangleSize.Width / 2;
                var shiftY = rectangleSize.Height / 2;
                return new Point(cloudCenter.X - shiftX, cloudCenter.Y - shiftY);
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
            return points.Current;
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
