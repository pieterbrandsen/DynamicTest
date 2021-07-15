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
                    d[key] = value.ToString();
            }
        
            return d;
        }
        
        private static DynamicDictionary DynamicDictionaryCreator(JArray data, string key)
        {
            dynamic d = new DynamicDictionary();
            d[key] = data.ToString();
            
            return d;
        }
        
        private static DynamicDictionary DynamicDictionaryCreator(JValue data, string key)
        {
            dynamic d = new DynamicDictionary();
            d[key] = data.ToString();
            
            return d;
        }

    public static Dictionary<string,List<DynamicDictionary>> DynamicDictionaryList(JObject data)
    {
        var dictionary = new Dictionary<string, List<DynamicDictionary>>();

        foreach (var (key,value) in data)
        {
            var dictionaryList = new List<DynamicDictionary>();
            var valueType = JObjectConverter.ObjectIsJObject(value)
                ? ObjectTypes.Object
                : JObjectConverter.ObjectIsJArray(value)
                    ? ObjectTypes.Array : ObjectTypes.Value;
            
            switch (valueType)
            {
                case ObjectTypes.Object:
                {
                    foreach (var (keyOfValue, valueOfValue) in (JObject) value)
                    {
                        valueType = JObjectConverter.ObjectIsJObject(valueOfValue)
                            ? ObjectTypes.Object
                            : JObjectConverter.ObjectIsJArray(valueOfValue)
                                ? ObjectTypes.Array : ObjectTypes.Value;

                        switch (valueType)
                        {
                            case ObjectTypes.Object when valueOfValue.HasValues:
                                dictionaryList.Add(DynamicDictionaryCreator(valueOfValue as JObject));
                                break;
                            case ObjectTypes.Array when valueOfValue.HasValues:
                                dictionaryList.Add(DynamicDictionaryCreator(valueOfValue as JArray, keyOfValue));
                                break;
                            case ObjectTypes.Value:
                                dictionaryList.Add(DynamicDictionaryCreator(valueOfValue as JValue, keyOfValue));
                                break;
                        }
                    }

                    break;
                }
                case ObjectTypes.Array:
                {
                    foreach (var itemOfValue in (JArray) value)
                    {
                        valueType = JObjectConverter.ObjectIsJObject(itemOfValue)
                            ? ObjectTypes.Object
                            : JObjectConverter.ObjectIsJArray(itemOfValue)
                                ? ObjectTypes.Array : ObjectTypes.Value;

                        switch (valueType)
                        {
                            case ObjectTypes.Object when itemOfValue.HasValues:
                                dictionaryList.Add(DynamicDictionaryCreator(itemOfValue as JObject));
                                break;
                            case ObjectTypes.Value:
                                dictionaryList.Add(DynamicDictionaryCreator(itemOfValue as JValue, key));
                                break;
                        }
                    }

                    break;
                }
                case ObjectTypes.Value:
                {
                    dictionaryList.Add(DynamicDictionaryCreator(value as JValue, key));
                    break;
                }
            }
            
            if (dictionaryList.Count > 0) dictionary.Add(key, dictionaryList);
        }
            
            return dictionary;
        }
    }
}