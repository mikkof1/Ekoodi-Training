using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reference_number
{
    class Program
    {
        static void Main(string[] args)
        {

            ReferenceNumberHandler test = new ReferenceNumberHandler();

            Console.WriteLine(test.MakeFinnishReferenceNumber(" 12 345 6 ", true));//1
            Console.WriteLine(test.MakeFinnishReferenceNumber(" 3075 ", true));//3
            Console.WriteLine(test.MakeFinnishReferenceNumber(" 9907 124020 300325 ")); //1
            Console.WriteLine(test.MakeFinnishReferenceNumber(" 9907 124020 300325 ", true)); //1

            Console.WriteLine("---------------------------------");

            Console.WriteLine("Colified number: " + test.CheckFinnishReferenceNumber(" 12 3456 1 "));

            Console.ReadKey();

        }
    }
}
