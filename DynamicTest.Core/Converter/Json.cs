using System;
using System.Collections.Generic;
using System.Json;
using Newtonsoft.Json;

namespace DynamicTest.Core.Converter
{
    public static class Json
    {
        private static List<object> RecursiveArrayConverter(string json)
        {
            var jsonObj = JsonConvert.DeserializeObject<List<dynamic>>(json) ?? new List<dynamic>();
            var list = new List<object>();
            foreach (var item in jsonObj)
            {
                var itemString = item.ToString();
                if (StringIsJsonObject(itemString)) list.Add(RecursiveObjectConverter(itemString));
                else if (StringIsJsonArray(itemString)) list.Add(RecursiveArrayConverter(itemString));
                else list.Add(itemString);
            }

            return list;
        }

        private static Dictionary<string, object> RecursiveObjectConverter(string json)
        {
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(json) ??
                          new Dictionary<string, object>();
            var dictionary = new Dictionary<string, object>();
            foreach (var (key, value) in jsonObj)
            {
                var itemString = value.ToString();
                if (StringIsJsonObject(itemString)) dictionary.Add(key,RecursiveObjectConverter(itemString));
                else if (StringIsJsonArray(itemString)) dictionary.Add(key, RecursiveArrayConverter(itemString));
                else dictionary.Add(key, itemString);
            }

            return dictionary;
        }

        private static bool StringIsJsonObject(string jsonString)
        {
            return jsonString.StartsWith("{") && jsonString.EndsWith("}");
        }
        private static bool StringIsJsonArray(string jsonString)
        {
            return jsonString.StartsWith("[") && jsonString.EndsWith("]");
        }

        private static bool StringIsValidJson(string jsonString)
        {
            try
            {
                if (!StringIsJsonArray(jsonString) && !StringIsJsonObject(jsonString)) return false;
                JsonValue.Parse(jsonString);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static object ConvertJsonStringToObject(string jsonString)
        {
            if (!StringIsValidJson(jsonString)) return new object();
            if (StringIsJsonObject(jsonString)) return RecursiveObjectConverter(jsonString);
            return RecursiveArrayConverter(jsonString);
        }
    }
}