﻿using System.Collections.Generic;
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
            Assert.True(Json.ObjectIsJsonObject(_jObject));

            Assert.False(Json.ObjectIsJsonObject(_jArray));
        }
        
        [Fact]
        public void IsArrayJArray()
        {
            Assert.True(Json.ObjectIsJsonArray(_jArray));
            
            Assert.False(Json.ObjectIsJsonArray(_jObject));
        }
        
        [Fact]
        public void TryToConvertJsonArray()
        {
            foreach (var json in JsonArrayGenerator.GetJsonArrayList)
            {
                Assert.NotEmpty(json);
                
                var jsonObject = Json.ConvertJsonStringToObject<JArray>(json);
                Assert.NotNull(jsonObject);
                Assert.IsType<JArray>(jsonObject); 
            }
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
        public void TryToConvertMultipleJsonObject()
        {
            var json = JsonObject.GetJson;
            var jsonObject = Json.ConvertJsonStringToObject<JObject>(json);
            Assert.NotNull(jsonObject);
            Assert.IsType<JObject>(jsonObject);
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
                
                var jsonObject = Json.ConvertJsonStringToObject<JArray>(json,json2);
                Assert.NotNull(jsonObject);
                Assert.IsType<JArray>(jsonObject);
            }
        }

        [Fact]
        public void TryToConvertNonValidJsonObject()
        {
            var json = JsonNonValid.GetJson;
            var jsonObject = Json.ConvertJsonStringToObject<JObject>(json);
            Assert.Null(jsonObject);

            var json2 = JsonNonValid.GetJson2;
            var jsonObject2 = Json.ConvertJsonStringToObject<JObject>(json,json2);
            Assert.Null(jsonObject2);
        }
    }
}