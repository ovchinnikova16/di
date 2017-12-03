using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloudVisualization
{
    public interface IParser
    {
        Dictionary<string, int> GetFrequency(IEnumerable<string> text, int wordsNumber);
    }
}
