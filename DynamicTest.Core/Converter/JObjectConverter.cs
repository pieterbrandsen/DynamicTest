using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

        // public static JObject ConvertJsonStringToObject(string json)
        // {
        //     try
        //     {
        //         var obj = JsonConvert.DeserializeObject<JObject>(json);
        //         // var obj2 = JsonConvert.DeserializeObject<JObject>(json2);
        //         // if (obj2 != null) obj?.Merge(obj2);
        //         return obj;
        //     }
        //     catch (Exception)
        //     {
        //         return default;
        //     }
        // }
    }
}