using System;
using System.Collections.Generic;
using DynamicTest.Core.Helper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Syncfusion.Blazor.Inputs;

namespace DynamicTest.Core.Converter
{
    public static class JObjectConverter
    {
        public static bool ObjectIsJObject(object obj)
        {
            return obj.GetType() == typeof(JObject);
        }

        public static bool ObjectIsJArray(object obj)
        {
            return obj.GetType() == typeof(JArray);
        }

        // public static JArray ConvertJsonStringToArray(string jsonString)
        // {
        //     var obj = JsonConvert.DeserializeObject<JArray>(jsonString);
        //     return obj;
        // }

        public static JObject ConvertFilesToObject(Dictionary<string, UploadFiles> files)
        {
            var headObj = new JObject();
                foreach (var file in files)
                {
                    var content = FileReader.Json(file.Value);
                    var obj = JsonConvert.DeserializeObject<JObject>(content);
                    headObj.Merge(obj ?? new JObject());
                }

                return headObj;
        }
    }
}