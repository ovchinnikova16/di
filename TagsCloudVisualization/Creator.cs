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
        private readonly ICircularCloudLayouter cloudLayouter;
        private readonly IDrawer drawer;
        private readonly ITagsMaker tagsMaker;
        private readonly IParser parser;
        private readonly Size size;

        public Creator(ICircularCloudLayouter cloudLayouter, IDrawer drawer, 
            ITagsMaker tagsMaker, IParser parser, Size size)
        {
            this.drawer = drawer;
            this.cloudLayouter = cloudLayouter;
            this.parser = parser;
            this.tagsMaker = tagsMaker;
            this.size = size;
        }

        public void CreateCloud(string textPath, string imagePath)
        {
            var frequencyOfWords = new Parser().GetFrequency(File.ReadLines(textPath), 100);
            var tags = tagsMaker.MakeTags(frequencyOfWords);
            drawer.DrawTags(tags, imagePath, size);
        }
    }
}
