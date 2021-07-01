using Newtonsoft.Json;

namespace DynamicTest.Tests.MockData.Json
{
    public class JsonNonValidObjectGenerator
    {
        private static readonly string Object;
        private static readonly string Object2;
        private static readonly string Object3;

        static JsonNonValidObjectGenerator()
        {
            Object = "A:0";
            Object2 = "{A: }";
            Object2 = "{1: }";
            Object3 = "[A: }";
        }

        private static string GetJsonObject=> JsonConvert.SerializeObject(Object);
        private static string GetJsonObject2 => JsonConvert.SerializeObject(Object2);
        private static string GetJsonObject3 => JsonConvert.SerializeObject(Object3);
        public static string[] GetJsonArrayList => new[] {GetJsonObject, GetJsonObject2, GetJsonObject3};
    }
}