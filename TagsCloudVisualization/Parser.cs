using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloudVisualization
{
    class Parser
    {
        public Dictionary<string, int> GetFrequency(IEnumerable<string> text, int wordsNumber)
        {
            return text.Where(w => w.Length > 3)
                .Select(w => w.ToLower())
                .GroupBy(w => w)
                .OrderByDescending(w => w.Count())
                .Take(wordsNumber)
                .ToDictionary(w => w.Key, w => w.Count());
        }
    }
}
