using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactsApi.Models
{
    public class Contact
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }
        public string adress { get; set; }
        public string city { get; set; }
    }
}