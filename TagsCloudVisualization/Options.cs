using CommandLine;

namespace TagsCloudVisualization
{
    public class Options
    {
        [Option('t', "file", DefaultValue = "text.txt")]
        public string FileName { get; set; }

        [Option('i', "image", Required = true, DefaultValue = "cloud.png")]
        public string ImageName { get; set; }

        [Option('w', "width", DefaultValue = 500)]
        public int Width { get; set; }

        [Option('h', "height", DefaultValue = 500)]
        public int Height { get; set; }

        [Option('f', "font", DefaultValue = "Arial")]
        public string Font { get; set; }
    }
}
