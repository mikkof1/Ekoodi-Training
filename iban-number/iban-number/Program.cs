using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iban_number
{
    class Program
    {
        static void Main(string[] args)
        {
            IbanNumberHandler test = new IbanNumberHandler();
            string testNumber = " 159 030 - 776 ";

            Console.WriteLine("Colified number: " + test.CheckOldFinnishBankNumber(testNumber));
            Console.WriteLine(test.CalculateFinnishIbanNumber(testNumber));
            Console.WriteLine(test.CalculateFinnishIbanNumber(testNumber, true));

            Console.WriteLine("-------------------------------");
            Console.WriteLine("Colified IBAN number: "+test.CheckIbanNumber(" FI42 5000  1510 0000 23 "));

            Console.ReadKey();

        }
    }
}
