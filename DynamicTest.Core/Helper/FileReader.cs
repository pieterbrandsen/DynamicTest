using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;

namespace DynamicTest.Core.Helper
{
    public static class FileReader
    {
        public static async Task<string> Json(IBrowserFile file)
        {
            await using var stream = file.OpenReadStream(int.MaxValue);
            using var reader = new StreamReader(stream);
            var content = await reader.ReadToEndAsync();
            return content;
        }

        public static string Json(string fileLocation)
        {
            var content = File.ReadAllText(fileLocation);
            return content;
        }
    }
}