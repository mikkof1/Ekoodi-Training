using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    public class IbanController : ApiController
    {
        private readonly IbanService _ibanService = new IbanService();

        [HttpPost]
        public Iban Post(Iban id)
        {
            if (id == null || id.IbanNumber == null)
            {
                return null;
            }
            Iban iban = new Iban(id.IbanNumber);
            iban.CorrectNumber = _ibanService.CheckIbanNumber(iban.IbanNumber);
            return iban;
        }
    }

}
