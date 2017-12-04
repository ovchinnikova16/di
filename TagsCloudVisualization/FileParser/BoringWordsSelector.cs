using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloudVisualization
{
    public class BoringWordsSelector : IWordsSelector
    {
        private readonly List<string> boringWords;

        public BoringWordsSelector(List<string> boringWords)
        {
            this.boringWords = boringWords;
        }

        public IEnumerable<string> SelectWords(IEnumerable<string> wordlist)
        {
            return wordlist.Where(w => !boringWords.Contains(w) && w.Length > 3);
        }
    }
}
