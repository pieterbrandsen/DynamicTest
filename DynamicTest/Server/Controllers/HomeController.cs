using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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
            var dictionary = JsonConvert.DeserializeObject<IDictionary<string, object>>(json);

            foreach (var itemGroup in dictionary)
            {
                foreach (var item in itemGroup.Value)
                {
                }
            }

            return null;
        }
    }
}
