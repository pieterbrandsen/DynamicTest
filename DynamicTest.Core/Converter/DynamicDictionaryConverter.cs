using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Transactions;
using DynamicTest.Core.Models;
using Newtonsoft.Json.Linq;

namespace DynamicTest.Core.Converter
{
    public static class DynamicDictionaryConverter
    {
        private enum ObjectTypes
        {
            Value,
            Object,
            Array
        }


        private static DynamicDictionary RecursiveDynamicDictionary(object data, ObjectTypes objType, string parentKey = null)
        {
            dynamic d = new DynamicDictionary();

            var dataType = data.GetType();
            var propertyNameList = dataType.GetProperties().Select(s=>s.Name).ToList();
            
            foreach (var name in propertyNameList)
            {
                var value = dataType.GetProperty(name).GetValue(data);
                var valueType = JObjectConverter.ObjectIsJsonObject(value)
                    ? ObjectTypes.Object
                    : JObjectConverter.ObjectIsJsonArray(value)
                        ? ObjectTypes.Array
                        : ObjectTypes.Value;

                if (valueType == ObjectTypes.Object)
                {
                    d[name] = RecursiveDynamicDictionary(value, objType);
                }
                else if (valueType == ObjectTypes.Array)
                {
                    d[name] = RecursiveDynamicDictionary(value, objType);
                }
                else
                {
                    d.a = "a";
                    d[name] = value;
                }
            }

            return d as DynamicDictionary;
        }

    public static List<DynamicDictionary> GetDynamicDictionary(JObject data)
    {
        var dictionaryList = new List<DynamicDictionary>();
            foreach (var item in data)
            {
                var valueType = JObjectConverter.ObjectIsJsonObject(item.Value)
                    ? ObjectTypes.Object
                    : JObjectConverter.ObjectIsJsonArray(item.Value)
                        ? ObjectTypes.Array : ObjectTypes.Value;

                dictionaryList.Add(RecursiveDynamicDictionary(item.Value, valueType, item.Key));
            }
            
            return dictionaryList;
        }
    }
}