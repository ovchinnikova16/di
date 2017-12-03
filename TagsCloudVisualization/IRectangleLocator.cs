using System.Collections.Generic;
using System.Drawing;

namespace TagsCloudVisualization
{
    public interface IRectangleLocator
    {
        Point FindLocation(Size rectangleSize, List<Rectangle> rectangles);
    }
}
