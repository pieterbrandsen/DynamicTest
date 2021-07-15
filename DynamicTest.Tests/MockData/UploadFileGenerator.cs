using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicTest.Core.Helper;
using Syncfusion.Blazor.Inputs;

namespace DynamicTest.Tests.MockData
{
    public static class UploadFileGenerator
    {
        private static Random random = new Random();
        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        
        private static (UploadFiles file, string content) NewFile()
        {
            var content = "{" + "\"" + RandomString(10) + "\"" +": " + "\"" +RandomString(10) + "\"" +"}";
            var file = new UploadFiles {Stream = new MemoryStream(Encoding.ASCII.GetBytes(content))};
            return (file, content);
        }
        
        private static (UploadFiles file, string content) NewFile(string content)
        {
            var file = new UploadFiles {Stream = new MemoryStream(Encoding.ASCII.GetBytes(content))};
            return (file, content);
        }

        
        public static async Task<(UploadFiles, string, string)> WriteNewFile()
        {
            var (file, content) = NewFile();
            var path = await FileWriter.Json(file);
            return (file, path, content);
        }
        
        public static async Task<(UploadFiles, string, string)> WriteNewFile(string inputContent)
        {
            var (file, content) = NewFile(inputContent);
            var path = await FileWriter.Json(file);
            return (file, path, content);
        }
    }
}