using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloudVisualization
{
    public class Creator
    {
        private readonly IDrawer drawer;
        private readonly ITagsMaker tagsMaker;
        private readonly IParser parser;
        private readonly Size size;

        public Creator(IDrawer drawer, 
            ITagsMaker tagsMaker, IParser parser, Size size)
        {
            this.drawer = drawer;
            this.parser = parser;
            this.tagsMaker = tagsMaker;
            this.size = size;
        }

        public void CreateCloud(string textPath, string imagePath)
        {
            var frequencyOfWords = parser.GetFrequency(File.ReadLines(textPath), 100);
            var tags = tagsMaker.MakeTags(frequencyOfWords);
            drawer.DrawTags(tags, imagePath, size);
        }
    }
}
