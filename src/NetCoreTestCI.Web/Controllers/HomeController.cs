using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreTestCI.Framework;

namespace NetCoreTestCI.Web.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        // GET api/home
        [HttpGet]
        public ContentResult Get()
        {
            return Content("Please pass a parameter like /Hello World");
        }

        // GET api/home/5
        [HttpGet("{word}")]
        public ContentResult Get(string word)
        {
            return Content($"{Text.Slugify(word)}-{new Random().Next(100000, 1000000)}");
        }
    }
}
