using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;
using Syncfusion.Blazor.Inputs;

namespace DynamicTest.Core.Helper
{
    public static class FileReader
    {
        public static string Json(UploadFiles file)
        {
            var content = Encoding.ASCII.GetString(file.Stream.ToArray());
            return content;
        }

        public static string Json(string path)
        {
            var content = File.ReadAllText(path);
            return content;
        }
    }
}