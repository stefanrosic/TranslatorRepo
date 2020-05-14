using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace TranslatorToolApp.Controllers
{
    public class HomeController : Controller
    {
        [Route("api/get")]
        [HttpGet]
        public String Index()
        {
            return "eeeeeeeeeeeeeeeeeeee breeeee";
        }
    }
}
