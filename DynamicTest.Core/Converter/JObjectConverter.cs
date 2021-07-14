using System;
using System.Collections.Generic;
using System.IO;
using DynamicTest.Core.Helper;
using DynamicTest.Core.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Syncfusion.Blazor.Inputs;

namespace DynamicTest.Core.Converter
{
    public static class JObjectConverter
    {
        /*private static List<object> RecursiveArrayConverter(dynamic obj)
        {
            var list = new List<object>();
            foreach (var item in obj)
            {
                list.Add(ObjectIsJsonObject(item)
                    ? RecursiveObjectConverter(item)
                    : ObjectIsJsonArray(item)
                        ? RecursiveArrayConverter(item)
                        : item
                );
            }

            return list;
        }

        private static Dictionary<string, object> RecursiveObjectConverter(dynamic obj)
        {
            var dictionary = new Dictionary<string, object>();
            foreach (var (key, value) in obj)
            {
                dictionary.Add(key, ObjectIsJsonObject(value)
                    ? RecursiveObjectConverter(value)
                    : ObjectIsJsonArray(value)
                        ? RecursiveArrayConverter(value)
                        : value
                );
            }

            return dictionary;
        }
        */
        public static bool ObjectIsJsonObject(object obj)
        {
            return obj.GetType() == typeof(JObject);
        }

        public static bool ObjectIsJsonArray(object obj)
        {
            return obj.GetType() == typeof(JArray);
        }

        public static JObject ConvertJsonStringToObject(string jsonString)
        {
            try
            {
                var obj = JsonConvert.DeserializeObject<JObject>(jsonString);
                return obj;
            }
            catch (Exception)
            {
                return default;
            }
        }

        public static JObject ConvertJsonStringToObject(Dictionary<string,UploadFiles> paths)
        {
            var headObj = new JObject();
            try
            {
                foreach (var path in paths)
                {
                    var content = FileReader.Json(path.Value);
                    var obj = JsonConvert.DeserializeObject<JObject>(content);
                    headObj.Merge(obj ?? new JObject());
                    headObj.
                }
                return headObj;
            }
            catch (Exception)
            {
                return default;
            }
        }
    }
}