using Microsoft.Extensions.Logging;
using StudentSystemExtended.Helpers;

namespace StudentSystemExtended.Others
{
    internal class Delegates
    {
        public static readonly ILogger logger = LoggerHelper.GetLogger("Hello");

        public static void Log(string error)
        {
            logger.LogError(error);
        }

        public static void Log2(string error)
        {
            Console.WriteLine(" -DELEGATES- ");
            Console.WriteLine($"{error}");
            Console.WriteLine(" -DELEGATES- ");
        }
    }
}
