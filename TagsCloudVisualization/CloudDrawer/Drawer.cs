using System.Collections.Generic;
using System.Drawing;

namespace TagsCloudVisualization
{
    class Drawer : IDrawer
    {
        private readonly Size size;
        private readonly string imageName;
        private readonly Color color;

        public Drawer(Size size, string imageName, Color color)
        {
            this.size = size;
            this.imageName = imageName;
            this.color = color;
        }

        public void DrawTags(List<Tag> tags)
        {
            var bitmap = new Bitmap(size.Width, size.Height);
            var g = Graphics.FromImage(bitmap);
            foreach (var tag in tags)
                g.DrawString(tag.Word, tag.Font, new SolidBrush(color),tag.Rectangle.X, tag.Rectangle.Y);

            g.Dispose();
            bitmap.Save(imageName);
        }
    }
}
