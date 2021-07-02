using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DynamicTest.Core;
using DynamicTest.Core.Converter;
using DynamicTest.Core.Helper;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Hosting;

namespace DynamicTest.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string fileLocation)
        {
            var fileContent = FileReader.Json(fileLocation);
            var obj2 = Json.ConvertJsonStringToObject<JObject>(fileContent);
            return Ok(obj2);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Stream content)
        {
            return Ok("Good");
        } 
    }
}
