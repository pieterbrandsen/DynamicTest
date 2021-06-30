using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DynamicTest.Core.Converter;
using Newtonsoft.Json.Linq;

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
            var obj = Json.ConvertJsonStringToObject<JObject>(r.ReadToEnd());

            return null;
        }
    }
}
