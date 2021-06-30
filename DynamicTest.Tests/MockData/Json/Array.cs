using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DynamicTest.Tests.MockData.Json
{
    public static class JsonArrayGenerator
    {
        private static readonly int[] Array;
        private static readonly int[][] Array2;
        private static readonly object[] Array3;

        static JsonArrayGenerator()
        {
            Array = new[] {0, 1, 2,3,4};
            Array2 = new[] {new[]{0, 1, 2},new[]{3, 4, 5}};
            Array3 = new object[] {new{A=0},new{B=1},new{C=2}};
        }

        public static string GetJsonArray => JsonConvert.SerializeObject(Array);
        public static string GetJsonArray2 => JsonConvert.SerializeObject(Array2);
        public static string GetJsonArray3 => JsonConvert.SerializeObject(Array3);
        public static string[] GetJsonArrayList => new[] {GetJsonArray, GetJsonArray2, GetJsonArray3};
    }
}