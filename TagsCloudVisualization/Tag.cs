using System.Drawing;


namespace TagsCloudVisualization
{
    public class Tag
    {
        public string Word;
        public Font Font;
        public Rectangle Rectangle;

        public Tag(string word, Font font, Rectangle rectangle)
        {
            Word = word;
            Font = font;
            Rectangle = rectangle;
        }
    }
}
