using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DynamicTest.Core.Converter;

namespace DynamicTest.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            using StreamReader r = new StreamReader("test.json");
            string json = r.ReadToEnd();
            var jsonObj = JsonConvert.DeserializeObject<object>(json);
            Json.ConvertJsonStringToObject(json);
            //try
            //{
            //    var jsonDictionary = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(json);
            //    var dictionary = new Dictionary<string, Dictionary<string, string>>();

            //    foreach (var itemGroup in jsonDictionary)
            //    {
            //        var items = JsonConvert.DeserializeObject<Dictionary<string, string>>(itemGroup.Value.ToString());
            //        dictionary.Add(itemGroup.Key, items);
            //    }
            //}
            //catch (Exception)
            //{
            //}

            //try
            //{
            //    var jsonArray = JsonConvert.DeserializeObject<dynamic[]>(json);
            //    var dictionary = new List<Dictionary<string, string>>();

            //    foreach (var itemGroup in jsonArray)
            //    {
            //        var a = itemGroup.ToString();
            //        var items = JsonConvert.DeserializeObject<Dictionary<string, string>>(a);
            //        dictionary.Add(items);
            //    }
            //}
            //catch (Exception)
            //{

            //}


            return null;
        }
    }
}
