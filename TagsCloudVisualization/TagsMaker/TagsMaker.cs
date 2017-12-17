using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TagsCloudVisualization
{
    public class TagsMaker : ITagsMaker
    {
        private readonly ICircularCloudLayouter cloudLayouter;
        private readonly FontFamily fontFamily; 

        public TagsMaker(ICircularCloudLayouter cloudLayouter, FontFamily fontFamily)
        {
            this.cloudLayouter = cloudLayouter;
            this.fontFamily = fontFamily;
        }

        public List<Tag> MakeTags(Dictionary<string, int> frequency)
        {
            var tags = new List<Tag>();
            var minSize = 10;
            var rangeSize = 25;
            var freq = frequency.OrderByDescending(x => x.Value);
            foreach (var word in freq)
            {
                var frontsize = minSize + rangeSize *
                    ((float)word.Value / freq.First().Value);
                var font = new Font(fontFamily,
                                    frontsize, 
                                    FontStyle.Regular, 
                                    GraphicsUnit.Pixel);
                var rectangleSize = TextRenderer.MeasureText(word.Key, font);
                var rectangle = cloudLayouter.PutNextRectangle(rectangleSize);
                if (rectangle.IsSuccess)
                    tags.Add(new Tag(word.Key, font, rectangle.Value));
            }

            return tags;
        }
    }
}
