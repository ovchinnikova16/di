using System.Collections.Generic;
using System.Linq;
using NHunspell;
using System;

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

        public Dictionary<string, int> GetFrequency(IEnumerable<string> words)

        {
            var hunspell = Result.Of(() => new Hunspell("en_US.aff", "en_US.dic"));
            if (!hunspell.IsSuccess)
                ErrorPrinter.PrintError(hunspell.Error);
            var notBoringWords = selector.SelectWords(words);
            return notBoringWords
                .Select(x =>
                {
                    var stems = hunspell.Value.Stem(x);
                    return stems.Any() ? stems[0] : x;
                })
                .GroupBy(w => w)
                .OrderByDescending(w => w.Count())
                .Take(wordsNumber)
                .ToDictionary(w => w.Key, w => w.Count());
        }
    }
}

