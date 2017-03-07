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
    public class ReferenceController : ApiController
    {
        private readonly ReferenceService _referenceService = new ReferenceService();

        [HttpPost]
        public Reference Post(Reference id)
        {
            if (id == null || id.ReferenceNumber == null)
            {
                return null;
            }
            Reference reference = new Reference(id.ReferenceNumber);
            reference.CorrectNumber = _referenceService.CheckFinnishReferenceNumber(reference.ReferenceNumber);
            return reference;
        }

    }
}
