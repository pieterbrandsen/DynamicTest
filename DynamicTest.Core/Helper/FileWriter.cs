using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
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