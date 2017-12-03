using System.Collections.Generic;

namespace TagsCloudVisualization
{
    public interface IParser
    {
        Dictionary<string, int> GetFrequency(IEnumerable<string> text);
    }
}
