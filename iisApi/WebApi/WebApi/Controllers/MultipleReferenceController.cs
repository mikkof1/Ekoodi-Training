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
    public class MultipleReferenceController : ApiController
    {
        private readonly ReferenceService _referenceService = new ReferenceService();

        [HttpPost]
        [Route("multi")]
        public List<string> Post(MultipleReferenceNumber id)
        {
            List<string> returnList = new List<string>();

            int countIndex = 1;
            for (int i = 0; i < id.Count; i++)
            {
                returnList.Add(_referenceService.MakeFinnishReferenceNumber(id.FirstReferenceNumber+countIndex));
                countIndex++;
            }

            return returnList;
        }


    }
}
