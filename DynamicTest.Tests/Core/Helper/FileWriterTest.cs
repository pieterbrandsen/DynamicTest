using System;
using System.IO;
using System.Threading;
using DynamicTest.Core.Helper;
using DynamicTest.Tests.MockData;
using Microsoft.AspNetCore.Components.Forms;
using Xunit;

namespace DynamicTest.Tests.Core.Helper
{
    public class FileWriterTest
    {
        [Fact]
        public async void TryToWriteFile()
        {
            var file = new BrowserFileMocked.File();
            var path = await FileWriter.Json(file);
            var fileContent = FileReader.Json(path);
            
            Assert.NotNull(path);
            Assert.Equal("",fileContent);
        }
    }
}