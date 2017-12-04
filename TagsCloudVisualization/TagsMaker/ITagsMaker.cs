using System.Collections.Generic;

namespace TagsCloudVisualization
{
    public interface ITagsMaker
    {
        List<Tag> MakeTags(Dictionary<string, int> frequency);
    }
}
