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
            var fileName = $"{RandomStringGenerator.RandomizedString()}.json";

            var directoryPath = "./json/";
            var fullPath = $"{directoryPath}{fileName}";
            Directory.CreateDirectory(directoryPath);
            await File.WriteAllTextAsync(fullPath, fileContent);

            return fullPath;
        } 
    }
}