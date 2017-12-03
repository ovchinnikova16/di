using System.Drawing;
using Autofac;
using System.IO;

namespace TagsCloudVisualization
{
    class Program
    {
        static void Main(string[] args)
        {
            var cloudCenter = new Point(250, 250);
            var size = new Size(cloudCenter.X * 2, cloudCenter.Y * 2);

            var container = new ContainerBuilder();
            container.RegisterType<CircularCloudLayouter>()
                .As<ICircularCloudLayouter>()
                .WithParameter("cloudCenter", cloudCenter);
            container.RegisterType<Parser>()
                .As<IParser>();
            container.RegisterType<TagsMaker>()
                .As<ITagsMaker>();
            container.RegisterType<Drawer>()
                .As<IDrawer>();
            container.RegisterType<Creator>().AsSelf()
                .WithParameter("size", size);

            var build = container.Build();
            var creator = build.Resolve<Creator>();
            creator.CreateCloud("text.txt", "cloud.bmp");
        }
    }
}