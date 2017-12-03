using System;
using System.Collections.Generic;
using System.IO;

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
            return File.ReadLines(fileName);
        }
    }
}
