namespace TagsCloudVisualization
{
    public class CloudMaker
    {
        private readonly IDrawer drawer;
        private readonly ITagsMaker tagsMaker;
        private readonly IParser parser;
        private readonly IReader reader;

        public CloudMaker(IDrawer drawer, ITagsMaker tagsMaker, 
            IParser parser, IReader reader)
        {
            this.drawer = drawer;
            this.parser = parser;
            this.tagsMaker = tagsMaker;
            this.reader = reader;
        }

        public void CreateCloud()
        {
            var text = reader.ReadFromFile();
            var frequencyOfWords = parser.GetFrequency(text);
            var tags = tagsMaker.MakeTags(frequencyOfWords);
            drawer.DrawTags(tags);
        }
    }
}
