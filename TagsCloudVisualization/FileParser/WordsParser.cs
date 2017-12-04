using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using NHunspell;

namespace TagsCloudVisualization
{
    public class WordsParser : IParser
    {
        private readonly int wordsNumber;
        private readonly IWordsSelector selector;

        public WordsParser(int wordsNumber, IWordsSelector selector)
        {
            this.wordsNumber = wordsNumber;
            this.selector = selector;
        }

        public Dictionary<string, int> GetFrequency(IEnumerable<string> text)
        {
            var hunspell = new Hunspell("FileParser/en_US.aff", "FileParser/en_US.dic");

            var words = getWords(text);
            var notBoringWords = selector.SelectWords(words);
            return notBoringWords
                .Select(x =>
                {
                    var stems = hunspell.Stem(x);
                    return stems.Any() ? stems[0] : x;
                })
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
                    yield return word.Value.ToLower();
            }
        }
    }
}
