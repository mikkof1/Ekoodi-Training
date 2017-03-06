using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using WebApi.IbanNumbers;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class IbanController : ApiController
    {
       
        public string GetDefault()
        {
            return "Terve";
        }
        
        //  [Route("joku/blaah/{id}")]
        [HttpPost] // was GetIban whitout [httppost]
        public IHttpActionResult GenerateIban(string  id)// if id => iban/123456789 else => iban?txt=123456789
        {
             IbanNumberHandler iban = new IbanNumberHandler();
            var product =  iban.CalculateFinnishIbanNumber(id,true);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }


    }
}
