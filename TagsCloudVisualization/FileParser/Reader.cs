using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace TagsCloudVisualization
{
    public class Reader : IReader
    {
        private readonly string fileName;

        public Reader(string fileName)
        {
            this.fileName = fileName;
        }

        public IEnumerable<string> ReadFromFile()
        {
            var text = File.ReadLines(fileName);
            return GetWords(text);
        }

        private IEnumerable<string> GetWords(IEnumerable<string> text)
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
