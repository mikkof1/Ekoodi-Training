using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        //// GET: /<controller>/            // This was in first
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }

        // GET: /HelloWorld/
        //public string Index()
        //{
        //    return "This is default action... (I think)";
        //}

        // GET: /HelloWorld/Welcome/
        //public string Welcome(string name, int id=1)
        //{
        //    //  return "This is the Welcome action method... (I think)";
        //    //  return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
        //    return HtmlEncoder.Default.Encode("Hello "+name+ ", NumTimes is: "+id);
        //}


    }



}
