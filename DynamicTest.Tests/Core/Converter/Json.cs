using DynamicTest.Core.Converter;
using DynamicTest.Tests.MockData.Json;
using Xunit;

namespace DynamicTest.Tests.Core.Converter
{
    public class JsonTest
    {
        [Fact]
        public void TryToConvertJsonValue()
        {
            var json = JsonValue.GetJson;
            var jsonObject = Json.ConvertJsonStringToObject(json);
            Assert.NotNull(jsonObject);
        }

        [Fact]
        public void TryToConvertJsonArray()
        {
            var json = JsonArray.GetJson;
            var jsonObject = Json.ConvertJsonStringToObject(json);
            Assert.NotNull(jsonObject);
        }

        [Fact]
        public void TryToConvertJsonObject()
        {
            var json = JsonObject.GetJson;
            var jsonObject = Json.ConvertJsonStringToObject(json);
            Assert.NotNull(jsonObject);
        }

        [Fact]
        public void TryToConvertHighJsonNesting()
        {
            var json = JsonNesting.GetJson;
            var jsonObject = Json.ConvertJsonStringToObject(json);
            Assert.NotNull(jsonObject);
        }

        [Fact]
        public void TryToConvertNonValidJsonObject()
        {
            var json = JsonNonValid.GetJson;
            var jsonObject = Json.ConvertJsonStringToObject(json);
            Assert.NotNull(jsonObject);

            var json2 = JsonNonValid.GetJson2;
            var jsonObject2 = Json.ConvertJsonStringToObject(json2);
            Assert.NotNull(jsonObject2);
        }
    }
}