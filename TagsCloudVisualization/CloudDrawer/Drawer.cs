using System;
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
            {
                var location = Result.Of(() => checkTagLocation(tag.Rectangle));
                if (!location.IsSuccess)
                    ErrorPrinter.PrintError(location.Error);

                g.DrawString(tag.Word, tag.Font, new SolidBrush(color), tag.Rectangle.X, tag.Rectangle.Y);
            }
            g.Dispose();
            bitmap.Save(imageName);
        }

        private bool checkTagLocation(Rectangle rectangle)
        {
            if (rectangle.Left < 0 || rectangle.Right > size.Width
                || rectangle.Top < 0 || rectangle.Bottom > size.Height)
                throw new Exception
                    ($"Tag location (x:{rectangle.X}, y:{rectangle.Y}) is out of image.");
            return true;
        }
    }
}
