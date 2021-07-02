using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DynamicTest.Core.Converter
{
    public static class JsonConverter
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

        public static T ConvertJsonStringToObject<T>(string jsonString) where T : JContainer
        {
            try
            {
                var obj = JsonConvert.DeserializeObject<T>(jsonString);
                return obj;
            }
            catch (Exception)
            {
                return default;
            }
        }

        public static T ConvertJsonStringToObject<T>(string json, string json2) where T : JContainer
        {
            try
            {
                var obj = JsonConvert.DeserializeObject<T>(json);
                var obj2 = JsonConvert.DeserializeObject<T>(json2);
                if (obj2 != null) obj?.Merge(obj2);
                return obj;
            }
            catch (Exception)
            {
                return default;
            }
        }
    }
}