using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;
using Syncfusion.Blazor.Inputs;

namespace DynamicTest.Core.Helper
{
    public static class FileWriter
    {
        public static async Task<string> Json(UploadFiles file)
        {
            var fileContent = FileReader.Json(file);
            var tempPath = Path.GetTempFileName();
            await File.WriteAllTextAsync(tempPath, fileContent);

            return tempPath;
        }
    }
}