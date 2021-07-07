using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;

namespace DynamicTest.Core.Helper
{
    public static class FileWriter
    {
        public static async Task<string> Json(IBrowserFile file)
        {
            var fileContent = await FileReader.Json(file);
            var tempPath = Path.GetTempFileName();
            await File.WriteAllTextAsync(tempPath, fileContent);

            return tempPath;
        }
    }
}