using System.Collections.Generic;
using DynamicTest.Core.Converter;
using DynamicTest.Core.Models;
using DynamicTest.Tests.MockData;
using DynamicTest.Tests.MockData.Json;
using Newtonsoft.Json.Linq;
using Syncfusion.Blazor.Inputs;
using Xunit;

namespace DynamicTest.Tests.Core.Converter
{
    public class DynamicDictionaryConverterTest
    {
        [Fact]
        public async void TryToConvertJsonObject()
        {
            foreach (var json in JsonObjectGenerator.GetJsonObjectList)
            {
                Assert.NotEmpty(json);
                var dictionary = new Dictionary<string, UploadFiles>();

                var (file,path,_) =await UploadFileGenerator.WriteNewFile(json);
                Assert.NotNull(file);
                dictionary.Add(path,file);
                
                var jObject = JObjectConverter.ConvertFilesToObject(dictionary);
                Assert.IsType<JObject>(jObject);

                var dynamicDictionary = DynamicDictionaryConverter.DynamicDictionaryList(jObject);
                Assert.NotEmpty(dynamicDictionary);
                Assert.IsType<Dictionary<string,List<DynamicDictionary>>>(dynamicDictionary);
            }
        }
    }
}