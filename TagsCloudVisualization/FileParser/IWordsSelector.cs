using System.Collections.Generic;

namespace TagsCloudVisualization
{
    public interface IWordsSelector
    {
        IEnumerable<string> SelectWords(IEnumerable<string> wordlist);
    }
}
