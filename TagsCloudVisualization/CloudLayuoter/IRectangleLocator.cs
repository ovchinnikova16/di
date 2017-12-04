using System.Collections.Generic;
using System.Drawing;

namespace TagsCloudVisualization
{
    public interface IRectangleLocator
    {
        Rectangle FindLocation(Size rectangleSize);
    }
}
