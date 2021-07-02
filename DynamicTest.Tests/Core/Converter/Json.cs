using System;
using System.Collections.Generic;
using DynamicTest.Core.Converter;
using DynamicTest.Tests.MockData.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace DynamicTest.Tests.Core.Converter
{
    public class JsonTest
    {
        private readonly JObject _jObject = new ();
        private readonly JArray _jArray = new ();
        [Fact]
        public void IsObjectJObject()
        {
            Assert.True(JsonConverter.ObjectIsJsonObject(_jObject));

            Assert.False(JsonConverter.ObjectIsJsonObject(_jArray));
        }
        
        [Fact]
        public void IsArrayJArray()
        {
            Assert.True(JsonConverter.ObjectIsJsonArray(_jArray));
            
            Assert.False(JsonConverter.ObjectIsJsonArray(_jObject));
        }
        
        [Fact]
        public void TryToConvertJsonObject()
        {
            foreach (var json in JsonObjectGenerator.GetJsonObjectList)
            {
                Assert.NotEmpty(json);
                
                var jsonObject = JsonConverter.ConvertJsonStringToObject<JObject>(json);
                Assert.NotNull(jsonObject);
                Assert.IsType<JObject>(jsonObject); 
            }
        }  
        
        [Fact]
        public void TryToConvertJsonArray()
        {
            foreach (var json in JsonArrayGenerator.GetJsonArrayList)
            {
                Assert.NotEmpty(json);
                
                var jsonObject = JsonConverter.ConvertJsonStringToObject<JArray>(json);
                Assert.NotNull(jsonObject);
                Assert.IsType<JArray>(jsonObject); 
            }
        }

        [Fact]
        public void TryToConvertMultipleJsonObject()
        {
            var jsonArray = JsonObjectGenerator.GetJsonObjectList;
            for (var i = 0; i < jsonArray.Length -1; i++)
            {
                var json = jsonArray[i];
                var json2 = jsonArray[i+1];
                Assert.NotEmpty(json);
                Assert.NotEmpty(json2);
                
                var jsonObject = JsonConverter.ConvertJsonStringToObject<JObject>(json,json2);
                Assert.NotNull(jsonObject);
                Assert.IsType<JObject>(jsonObject);
            }
        }
        
        [Fact]
        public void TryToConvertMultipleJsonArrays()
        {
            var jsonArray = JsonArrayGenerator.GetJsonArrayList;
            for (var i = 0; i < jsonArray.Length -1; i++)
            {
                var json = jsonArray[i];
                var json2 = jsonArray[i+1];
                Assert.NotEmpty(json);
                Assert.NotEmpty(json2);
                
                var jsonObject = JsonConverter.ConvertJsonStringToObject<JArray>(json,json2);
                Assert.NotNull(jsonObject);
                Assert.IsType<JArray>(jsonObject);
            }
        }

        [Fact]
        public void TryToConvertNonValidJsonObject()
        {
            foreach (var json in JsonNonValidObjectGenerator.GetJsonArrayList)
            {
                Assert.NotEmpty(json);
                
                var jsonObject = JsonConverter.ConvertJsonStringToObject<JArray>(json);
                Assert.Null(jsonObject);
            }
        }

        [Fact]
        public void TryToConvert2DifferentJsonStringTypes()
        {
            var json = JsonArrayGenerator.GetJsonArrayList[0];
            var json2 = JsonObjectGenerator.GetJsonObjectList[0];
            Assert.NotEmpty(json);
            Assert.NotEmpty(json2);

            var jsonObject = JsonConverter.ConvertJsonStringToObject<JArray>(json, json2);
            Assert.Null(jsonObject);
        }
    }
}