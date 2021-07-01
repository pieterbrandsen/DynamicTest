using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DynamicTest.Core;
using DynamicTest.Core.Converter;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json.Linq;

namespace DynamicTest.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public async Task<JObject> Get(IBrowserFile file)
        {
            var obj = Json.ConvertJsonStringToObject<JObject>(FileLoader.Json("test"));

            await using var stream = file.OpenReadStream(int.MaxValue);
            using var reader = new StreamReader(stream);
            var obj2 = Json.ConvertJsonStringToObject<JObject>(await reader.ReadToEndAsync());
            return obj2;
        }
    }
}
