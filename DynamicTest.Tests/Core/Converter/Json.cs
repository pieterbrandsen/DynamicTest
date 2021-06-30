using System.Collections.Generic;
using DynamicTest.Core.Converter;
using DynamicTest.Tests.MockData.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace DynamicTest.Tests.Core.Converter
{
    public class JsonTest
    {
        [Fact]
        public void IsObjectJObject()
        {
            var jObject = new JObject();
            Assert.True(Json.ObjectIsJsonObject(jObject));

            var jArray = new JArray();
            Assert.False(Json.ObjectIsJsonObject(jArray));
        }
        
        [Fact]
        public void IsArrayJArray()
        {
            var jArray = new JArray();
            Assert.True(Json.ObjectIsJsonArray(jArray));
            
            var jObject = new JObject();
            Assert.False(Json.ObjectIsJsonArray(jObject));
        }
        
        [Fact]
        public void TryToConvertJsonArray()
        {
            var json = JsonArray.GetJson;
            var jsonObject = Json.ConvertJsonStringToObject<JArray>(json);
            Assert.NotNull(jsonObject);
            Assert.IsType<JArray>(jsonObject);
        }

        [Fact]
        public void TryToConvertJsonObject()
        {
            var json = JsonObject.GetJson;
            var jsonObject = Json.ConvertJsonStringToObject<JObject>(json);
            Assert.NotNull(jsonObject);
            Assert.IsType<JObject>(jsonObject);
        }

        [Fact]
        public void TryToConvertNonValidJsonObject()
        {
            var json = JsonNonValid.GetJson;
            var jsonObject = Json.ConvertJsonStringToObject<JObject>(json);
            Assert.Null(jsonObject);

            var json2 = JsonNonValid.GetJson2;
            var jsonObject2 = Json.ConvertJsonStringToObject<JObject>(json2);
            Assert.Null(jsonObject2);
        }
    }
}