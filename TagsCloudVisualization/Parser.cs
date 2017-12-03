using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TagsCloudVisualization
{
    public class Parser : IParser
    {
        private readonly int wordsNumber;

        public Parser(int wordsNumber)
        {
            this.wordsNumber = wordsNumber;
        }

        public Dictionary<string, int> GetFrequency(IEnumerable<string> text)
        {
            var words = getWords(text);
            return words.Where(w => w.Length > 3)
                .Select(w => w.ToLower())
                .GroupBy(w => w)
                .OrderByDescending(w => w.Count())
                .Take(wordsNumber)
                .ToDictionary(w => w.Key, w => w.Count());
        }

        private IEnumerable<string> getWords(IEnumerable<string> text)
        {
            foreach (var line in text)
            {
                var reg = new Regex(@"[A-Za-z']*");
                var words = reg.Matches(line);
                foreach (Match word in words)
                    yield return word.Value;
            }
        }
    }
}
