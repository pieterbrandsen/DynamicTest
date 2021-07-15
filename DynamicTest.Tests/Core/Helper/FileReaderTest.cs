using System.IO;
using System.Text;
using System.Threading.Tasks;
using DynamicTest.Core.Helper;
using DynamicTest.Tests.MockData;
using Syncfusion.Blazor.Inputs;
using Xunit;

namespace DynamicTest.Tests.Core.Helper
{
    public class FileReaderTest
    {
        [Fact]
        public async void ReadFileUsingFile()
        {
            var (file, path, expectedContent) = await UploadFileGenerator.WriteNewFile();
            var fileContent = FileReader.Json(file);
            
            Assert.NotNull(path);
            Assert.Equal(expectedContent,fileContent);
        }

        [Fact]
        public async void ReadFileUsingPath()
        {
            var (_, path, expectedContent) = await UploadFileGenerator.WriteNewFile();
            var fileContent = FileReader.Json(path);
            
            Assert.NotNull(path);
            Assert.Equal(expectedContent,fileContent);  
        }
    }
}