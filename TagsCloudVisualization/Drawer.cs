using System.Collections.Generic;
using System.Drawing;

namespace TagsCloudVisualization
{
    class Drawer
    {
        public static void DrawRectangles(List<Rectangle> rectangles, Point cloudCenter, string fileName, Size size)
        {
            var bitmap = new Bitmap(size.Width, size.Height);
            var g = Graphics.FromImage(bitmap);
            var pen = new Pen(Color.Blue);
            g.DrawEllipse(pen, cloudCenter.X-1, cloudCenter.Y-1, 2, 2);
            foreach (var rectangle in rectangles)
                g.DrawRectangle(pen, rectangle);

            g.Dispose();
            bitmap.Save(fileName);
        }

        public static void DrawTags(List<Tag> tags, Point cloudCenter, string fileName, Size size)
        {
            var bitmap = new Bitmap(size.Width, size.Height);
            var g = Graphics.FromImage(bitmap);
            foreach (var tag in tags)
                g.DrawString(tag.Word, tag.Font, new SolidBrush(Color.RoyalBlue),tag.Rectangle.X, tag.Rectangle.Y);

            g.Dispose();
            bitmap.Save(fileName);
        }
    }
}
