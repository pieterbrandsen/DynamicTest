using System.IO;

namespace DynamicTest.Core
{
    public static class FileLoader
    {
        public static string Json(string fileLocation)
        {
            using StreamReader r = new StreamReader($"{fileLocation}.json");
            return r.ReadToEnd();
        }
    }
}