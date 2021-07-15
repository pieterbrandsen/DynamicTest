using System.Collections.Generic;
using System.Linq;
using DynamicTest.Core.Converter;
using DynamicTest.Tests.MockData;
using DynamicTest.Tests.MockData.Json;
using Newtonsoft.Json.Linq;
using Syncfusion.Blazor.Inputs;
using Xunit;

namespace DynamicTest.Tests.Core.Converter
{
    public class JObjectConverterTest
    {
        private readonly JArray _jArray = new();
        private readonly JObject _jObject = new();
        
        [Fact]
        public void IsObjectJObject()
        {
            var resultObject = JObjectConverter.ObjectIsJObject(_jObject);
            var resultArray = JObjectConverter.ObjectIsJObject(_jArray);
            
            Assert.True(resultObject);
            Assert.False(resultArray);
        }
        
        [Fact]
        public void IsObjectJArray()
        {
            var resultObject = JObjectConverter.ObjectIsJArray(_jObject);
            var resultArray = JObjectConverter.ObjectIsJArray(_jArray);
            
            Assert.False(resultObject);
            Assert.True(resultArray);
        }

        [Fact]
        public async void ConvertFilesToObject()
        {
            var files = new Dictionary<string, UploadFiles>();
            var fileContents = new Dictionary<string, string>();
            for (int i = 0; i < 5; i++)
            {
                var (file, path, content) = await UploadFileGenerator.WriteNewFile();
                files.Add(path,file);
                fileContents.Add(path,content);
            }

            var jObject = JObjectConverter.ConvertFilesToObject(files);
            var charsToRemove = new string[] { "\r\n", " ", "{", "}"};
            var jObjectString = charsToRemove.Aggregate(jObject.ToString(), (current, c) => current.Replace(c, string.Empty));
            foreach (var (path, content) in fileContents)
            {
                var expectedSubString = charsToRemove.Aggregate(content, (current, c) => current.Replace(c, string.Empty));
                Assert.Contains(expectedSubString, jObjectString);
            }
            Assert.NotNull(jObject);
        }
    }
}