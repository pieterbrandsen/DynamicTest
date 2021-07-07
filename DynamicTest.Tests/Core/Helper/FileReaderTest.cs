using System.Threading.Tasks;
using DynamicTest.Core.Helper;
using DynamicTest.Tests.MockData;
using Xunit;

namespace DynamicTest.Tests.Core.Helper
{
    public class FileReaderTest
    {
        private async Task<(BrowserFileMocked.File, string)> WriteEmptyFile()
        {
            var file = new BrowserFileMocked.File();
            var path = await FileWriter.Json(file);
            return (file, path);
        }
        
        [Fact]
        public async void ReadFileUsingFile()
        {
            var (file, path) = await WriteEmptyFile();
            var fileContent = await FileReader.Json(file);
            
            Assert.NotNull(path);
            Assert.Equal("",fileContent);
        }

        [Fact]
        public async void ReadFileUsingPath()
        {
            var (file, path) = await WriteEmptyFile();
            var fileContent = FileReader.Json(path);
            
            Assert.NotNull(path);
            Assert.Equal("",fileContent);  
        }
    }
}