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

        private static DynamicDictionary DynamicDictionaryCreator(JObject data)
        {
            dynamic d = new DynamicDictionary();
            foreach (var (key, value) in data)
            {
                // var valueType = JObjectConverter.ObjectIsJsonObject(value)
                //     ? ObjectTypes.Object
                //     : JObjectConverter.ObjectIsJsonArray(value)
                //         ? ObjectTypes.Array
                //         : ObjectTypes.Value;
                    d[key] = value;
            }
        
            return d;
        }
        
        private static DynamicDictionary DynamicDictionaryCreator(JArray data, string key)
        {
            dynamic d = new DynamicDictionary();
            d[key] = data;
            
            return d;
        }
        
        private static DynamicDictionary DynamicDictionaryCreator(JValue data, string key)
        {
            dynamic d = new DynamicDictionary();
            d[key] = data;
            
            return d;
        }

    public static Dictionary<string,List<DynamicDictionary>> GetDynamicDictionaryList(JObject data)
    {
        var dictionary = new Dictionary<string, List<DynamicDictionary>>();

        foreach (var (key,value) in data)
        {
            var dictionaryList = new List<DynamicDictionary>();
            var valueType = JObjectConverter.ObjectIsJsonObject(value)
                ? ObjectTypes.Object
                : JObjectConverter.ObjectIsJsonArray(value)
                    ? ObjectTypes.Array : ObjectTypes.Value;
            
            if (valueType == ObjectTypes.Object)
            {
                foreach (var (keyOfValue, valueOfValue) in (JObject) value)
                {
                    valueType = JObjectConverter.ObjectIsJsonObject(valueOfValue)
                        ? ObjectTypes.Object
                        : JObjectConverter.ObjectIsJsonArray(valueOfValue)
                            ? ObjectTypes.Array : ObjectTypes.Value;

                    if (valueType == ObjectTypes.Object)
                    {
                        dictionaryList.Add(DynamicDictionaryCreator(valueOfValue as JObject));
                    }
                    else if (valueType == ObjectTypes.Array)
                    {
                        dictionaryList.Add(DynamicDictionaryCreator(valueOfValue as JArray, keyOfValue));
                    }
                }
            }
            else if (valueType == ObjectTypes.Array)
            {
                foreach (var itemOfValue in (JArray) value)
                {
                    valueType = JObjectConverter.ObjectIsJsonObject(itemOfValue)
                        ? ObjectTypes.Object
                        : JObjectConverter.ObjectIsJsonArray(itemOfValue)
                            ? ObjectTypes.Array : ObjectTypes.Value;

                    if (valueType == ObjectTypes.Object)
                    {
                        dictionaryList.Add(DynamicDictionaryCreator(itemOfValue as JObject));
                    }
                    // else if (valueType == ObjectTypes.Array)
                    // {
                    //     dictionaryList.Add(DynamicDictionaryCreator(item as JArray));
                    // }
                    else if (valueType == ObjectTypes.Value)
                    {
                        dictionaryList.Add(DynamicDictionaryCreator(itemOfValue as JValue, key));
                    }
                }
            }
            
            dictionary.Add(key, dictionaryList);
        }
            
            return dictionary;
        }
    }
}