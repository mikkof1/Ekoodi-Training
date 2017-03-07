using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class MultipleReferenceNumber
    {
        public MultipleReferenceNumber(string firstReferenceNumber, int count)
        {
            FirstReferenceNumber = firstReferenceNumber;
            Count = count;
        }

        public string FirstReferenceNumber { get; set; }
        public int Count { get; set; }
    }
}