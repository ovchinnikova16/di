using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloudVisualization
{
    class ErrorPrinter
    {
        public static void PrintError(string errorText)
        {
            Console.WriteLine(errorText);
            Console.ReadKey();
            Environment.Exit(1);
        }
    }
}
