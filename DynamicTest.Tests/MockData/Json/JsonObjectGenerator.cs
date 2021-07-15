using System;
using Newtonsoft.Json;

namespace DynamicTest.Tests.MockData.Json
{
    public static class JsonObjectGenerator
    {
        private static readonly object Object;
        private static readonly object Object2;
        private static readonly object Object3;

        static JsonObjectGenerator()
        {
            Object = new {A = 0, B = 1, C = 2, D = 3, E = 4};
            Object2 = new {A = new[] {0, 1, 2}, B = new[] {3, 4, 5}, C=new[] {new object(), new { Foo = "foo" }}, D=new {arr = Array.Empty<string>(), arr2 = new []{1,2,3}}};
            Object3 = new {A = new {AA = new {AAA = new {AAAA = new {AAAAA = 0}}}}, B = new {BA = 1}, C = new {CA = 2}};
        }

        private static string GetJsonObject => JsonConvert.SerializeObject(Object);
        private static string GetJsonObject2 => JsonConvert.SerializeObject(Object2);
        private static string GetJsonObject3 => JsonConvert.SerializeObject(Object3);
        public static string[] GetJsonObjectList => new[] {GetJsonObject, GetJsonObject2, GetJsonObject3};
    }
}