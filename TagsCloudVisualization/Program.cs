using System.Drawing;
using Autofac;
using System.IO;

namespace TagsCloudVisualization
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            var cloudFirst = new CircularCloudLayouter(new Point(250, 250));
            var rectangles = new List<Rectangle>();
            for (var i = 0; i < 100; i++)
                rectangles.Add(cloudFirst.PutNextRectangle(new Size(10, 10)));
            Drawer.DrawRectangles(rectangles, new Point(250, 250), "cloud1.bmp", new Size(500, 500));
            */

            var text = File.ReadLines("text.txt");
            var frequencyOfWords = new Parser().GetFrequency(text, 100);

            var cloudCenter = new Point(250, 250);
            var cloudLAtouter = new CircularCloudLayouter(cloudCenter);
            var tags = new TagsMaker().MakeTags(frequencyOfWords, cloudLAtouter);
            Drawer.DrawTags(tags, cloudCenter, "cloud.bmp", new Size(cloudCenter.X * 2, cloudCenter.Y * 2));
        }
    }
}