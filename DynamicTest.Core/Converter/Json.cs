using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Json;

namespace DynamicTest.Core.Converter
{
    public static class Json
    {
        private static List<object> RecursiveArrayConverter(string json)
        {
            var jsonObj = JsonConvert.DeserializeObject<List<dynamic>>(json);
            var list = new List<object>();
            foreach (var item in jsonObj)
            {
                var itemString = item.ToString();
                if (!StringIsValidJson(itemString)) list.Add(item.ToString());
                else if (StringIsJsonObject(itemString)) list.Add(RecursiveObjectConverter(item.ToString()));
                else list.Add(RecursiveArrayConverter(item.ToString()));
            }
            return list;
        }
        private static Dictionary<string, object> RecursiveObjectConverter(string json)
        {
            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            var dictionary = new Dictionary<string, object>();
            foreach (var item in jsonObj)
            {
                var itemString = item.Value.ToString();
                if (!StringIsValidJson(itemString)) dictionary.Add(item.Key, itemString);
                else if (StringIsJsonObject(itemString)) dictionary.Add(item.Key, RecursiveObjectConverter(itemString));
                else dictionary.Add(item.Key, RecursiveArrayConverter(itemString));
            }
            return dictionary;
        }
        private static bool StringIsJsonObject(string jsonString)
        {
            try
            {
                JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private static bool StringIsValidJson(string jsonString)
        {
            try
            {
                if ((jsonString.StartsWith("{") && jsonString.EndsWith("}")) || //For object
    (jsonString.StartsWith("[") && jsonString.EndsWith("]"))) //For array
                {
                    JsonValue.Parse(jsonString);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static object ConvertJsonStringToObject(string jsonString)
        {
            object obj = jsonString;
            if (!StringIsValidJson(jsonString)) return obj;
            if (StringIsJsonObject(jsonString)) obj = RecursiveObjectConverter(jsonString);
            else obj = RecursiveArrayConverter(jsonString);
            return obj;
        }
    }
}
