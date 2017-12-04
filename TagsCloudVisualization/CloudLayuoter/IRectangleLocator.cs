using System.Drawing;

namespace TagsCloudVisualization
{
    public interface IRectangleLocator
    {
        Rectangle FindLocation(Size rectangleSize);
    }
}
