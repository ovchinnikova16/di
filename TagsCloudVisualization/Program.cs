using System.Drawing;
using Autofac;

namespace TagsCloudVisualization
{
    class Program
    {
        static void Main(string[] args)
        {
            var cloudCenter = new Point(250, 250);
            var size = new Size(cloudCenter.X * 2, cloudCenter.Y * 2);
            var fileName = "text.txt";
            var imageName = "cloud.bmp";
            var wordsNumber = 100;
            var wordsColor = Color.RoyalBlue;
            var fontFamily = new FontFamily("Arial");

            var container = new ContainerBuilder();
            container.RegisterType<CircularCloudLayouter>()
                .As<ICircularCloudLayouter>()
                .WithParameter("cloudCenter", cloudCenter);
            container.RegisterType<Reader>()
                .As<IReader>()
                .WithParameter("fileName", fileName);
            container.RegisterType<Parser>()
                .As<IParser>()
                .WithParameter("wordsNumber", wordsNumber);
            container.RegisterType<TagsMaker>()
                .As<ITagsMaker>()
                .WithParameter("fontFamily", fontFamily);
            container.RegisterType<Drawer>()
                .As<IDrawer>()
                .WithParameter("size", size)
                .WithParameter("imageName", imageName)
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