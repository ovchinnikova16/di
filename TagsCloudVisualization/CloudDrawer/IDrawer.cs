using System.Collections.Generic;

namespace TagsCloudVisualization
{
    public interface IDrawer
    {
        void DrawTags(List<Tag> tags);
    }
}
