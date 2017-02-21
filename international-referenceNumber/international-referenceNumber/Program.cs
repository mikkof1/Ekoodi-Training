using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace international_referenceNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            ReferenceNumberHandler test = new ReferenceNumberHandler();
            Console.WriteLine(test.CalculateInternationalReferenceNumber(" 23 48 236 "));
            Console.WriteLine(test.CalculateInternationalReferenceNumber(" 123456 ",true));
            Console.WriteLine(test.CheckReferenceNumber("Rf 97 123 456 "));

            Console.ReadKey();

        }
    }
}
