using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;
using WebApi.Services;
//using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    public class IbanController : ApiController
    {
        private readonly IbanService _ibanService = new IbanService();

        [HttpPost]
        public Iban Post([FromBody]Iban id)
        {
            if (id == null || id.IbanNumber == null)
            {
                return null;
            }
            Iban iban = new Iban(id.IbanNumber);
            iban.CorrectNumber = _ibanService.CheckIbanNumber(iban.IbanNumber);
            return iban;
        }


       // [EnableCors(origins: "*", headers: "*", methods: "*")]
        public Iban Get(string id)
        {
            Iban uusi = new Iban("123456789");
            return uusi;
          //  return "Return this: " + id;
        }

        //public string Get(Iban id) // ei toimi
        //{
        //    if (id == null || id.IbanNumber == null)
        //    {
        //        return null;
        //    }
        //    return "Hello: " + id.IbanNumber + " : " + id.CorrectNumber;
        //}

        public string Delete(Iban id)
        {
            if (id == null || id.IbanNumber == null)
            {
                return null;
            }
            Iban iban = new Iban(id.IbanNumber);
            iban.CorrectNumber = _ibanService.CheckIbanNumber(iban.IbanNumber);
            return "Delete "+ iban.IbanNumber;
        }



    }

}
