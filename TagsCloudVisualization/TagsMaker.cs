using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TagsCloudVisualization
{
    class TagsMaker
    {
        public List<Tag> MakeTags(Dictionary<string, int> frequency, CircularCloudLayouter layout)
        {
            var tags = new List<Tag>();
            var minSize = 10;
            var rangeSize = 25;

            foreach (var word in frequency)
            {
                var frontsize = minSize + rangeSize *
                    ((float)word.Value / frequency.Values.Max());
                var font = new Font(new FontFamily("Arial"),
                                    frontsize, 
                                    FontStyle.Regular, 
                                    GraphicsUnit.Pixel);
                var rectangleSize = TextRenderer.MeasureText(word.Key, font);
                var rectangle = layout.PutNextRectangle(rectangleSize);
                tags.Add(new Tag(word.Key, font, rectangle));
            }

            return tags;
        }
    }
}
