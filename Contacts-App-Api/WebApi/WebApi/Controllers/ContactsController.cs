using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace WebApi.Controllers
{
    [Route("api/contacts")]
    [EnableCors("CorsPolicy")]
    public class ContactsController : Controller
    {
        private readonly Contact _contact = new Contact();
        private readonly ContactsHandler _contactsHandler = new ContactsHandler();

        // GET api/values
        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return _contactsHandler.GetList();
        }

        [HttpPost]
        public int PostNewContact([FromBody] Contact contact)
        {
            return _contactsHandler.AddNewContact(contact);
        }

        [HttpDelete]
        public bool DeleteContact([FromBody] Contact contact)
        {
            return _contactsHandler.DeleteContact(contact);
        }

        [HttpPut]
        public bool PutEditContact([FromBody] Contact contact)
        {
            return _contactsHandler.EditContact(contact);
        }
    }
}
