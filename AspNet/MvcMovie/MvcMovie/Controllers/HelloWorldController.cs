using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        //// GET: HelloWorld
        public ActionResult Index() // this is in the start
        {
            return View();
        }

        //public string Index() // http://localhost:xxx/HelloWorld
        //{
        //    return "This is my <b>default</b> action...<br>Terveisin Mikko :)";
        //}

        ////public string Welcome() // http://localhost:xxx/HelloWorld/Welcome
        ////{
        ////    return "This is my Welcome action method...<br>Ei sillä ettenkö epäilisi... ;)";
        ////}

        //public string Welcome(string name, int id=1) // http://localhost:xxx/HelloWorld/Welcome/3?name=Rick
        //{
        //    return HttpUtility.HtmlEncode("Terve " + name + ", ID: " + id);
        //}

        public ActionResult Welcome(string name, int numTimes = 1) // http://localhost:xxx/HelloWorld/Welcome/3?name=Rick
        {
            ViewBag.Message = "Terve " + name;
            ViewBag.NumTimes = numTimes;

            return View();
        }

    }
}