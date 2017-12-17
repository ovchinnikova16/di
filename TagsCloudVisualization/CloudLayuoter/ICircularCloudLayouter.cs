using System.Drawing;

namespace TagsCloudVisualization
{
    public interface ICircularCloudLayouter
    {
        Result<Rectangle> PutNextRectangle(Size rectangleSize);
    }
}
