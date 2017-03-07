using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Iban
    {
        public Iban(string ibanNumber)
        {
            IbanNumber = ibanNumber;
        }

        public string IbanNumber { get; set; }

    }
}