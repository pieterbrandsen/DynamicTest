using System;
using System.Collections.Generic;
using System.Json;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DynamicTest.Core.Converter
{
    public static class Json
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

        public static T ConvertJsonStringToObject<T>(string jsonString)
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
    }
}