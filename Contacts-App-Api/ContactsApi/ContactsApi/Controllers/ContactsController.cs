using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ContactsApi.Models;
using ContactsApi.Services;

namespace ContactsApi.Controllers
{
    public class ContactsController : ApiController
    {
        private readonly Contact _contact = new Contact();
        private readonly ContatsHandler _contantsHandler = new ContatsHandler();

        [HttpGet]
       // [Route("api/all")]
        public Contact[] GetWholeList()
        {
            return _contantsHandler.GetList().ToArray();
        }

        [HttpPut]
       // [Route("api/new")]
        public int PostNewContact([FromBody] Contact contact)
        {
            return _contantsHandler.AddNewContact(contact);
        }

        [HttpDelete]
       // [Route("api/del")]
        public bool PostDeleteContact([FromBody] Contact contact)
        {
            return _contantsHandler.DeleteContact(contact);
        }

        [HttpPost]
       // [Route("api/edit")]
        public bool PostEditContact([FromBody] Contact contact)
        {
            return _contantsHandler.EditContact(contact);
        }

    }
}
