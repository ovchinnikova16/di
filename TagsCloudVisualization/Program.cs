using System.Collections.Generic;
using System.Drawing;
using Autofac;
using CommandLine;

namespace TagsCloudVisualization
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new Options();
            Parser.Default.ParseArguments(args, options);


            var cloudCenter = new Point(250, 250);
            var size = new Size(options.Width, options.Height);
            var wordsNumber = 100;
            var wordsColor = Color.RoyalBlue;
            var fontFamily = new FontFamily(options.Font);
            var boringWords = new List<string>() {"that", "this", "with"};

            var container = new ContainerBuilder();
            container.RegisterType<CircularCloudLayouter>()
                .As<ICircularCloudLayouter>()
                .WithParameter("cloudCenter", cloudCenter);
            container.RegisterType<RectangleLocator>()
                .As<IRectangleLocator>()
                .WithParameter("cloudCenter", cloudCenter);
            container.RegisterType<Reader>()
                .As<IReader>()
                .WithParameter("fileName", options.FileName);
            container.RegisterType<BoringWordsSelector>()
                .As<IWordsSelector>()
                .WithParameter("boringWords", boringWords);
            container.RegisterType<WordsParser>()
                .As<IParser>()
                .WithParameter("wordsNumber", wordsNumber);
            container.RegisterType<TagsMaker>()
                .As<ITagsMaker>()
                .WithParameter("fontFamily", fontFamily);
            container.RegisterType<Drawer>()
                .As<IDrawer>()
                .WithParameter("size", size)
                .WithParameter("imageName", options.ImageName)
                .WithParameter("color", wordsColor);
            container.RegisterType<CloudMaker>()
                .AsSelf()
                .WithParameter("size", size);

            var build = container.Build();
            var creator = build.Resolve<CloudMaker>();
            creator.CreateCloud();
        }
    }
}