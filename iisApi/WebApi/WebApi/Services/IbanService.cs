using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Services
{
    public class IbanService
    {

        public bool CheckIbanNumber(string ibanNumber)
        {
            bool returnValue = false;

            string plainIbanNumber = "";
            int ibanLeterCount = 0;
            foreach (char ibanNumberChar in ibanNumber)
            {
                if (char.IsLetterOrDigit(ibanNumberChar))
                {
                    plainIbanNumber += ibanNumberChar;
                }
                if (char.IsLetter(ibanNumberChar))
                {
                    ibanLeterCount++;
                }
            }
            
            bool ibanNumberIsNotValid = ibanLeterCount > 2 || plainIbanNumber.Length != 18;
            if (ibanNumberIsNotValid)
            {
                return false;
            }

            string ibanNumberEnd = plainIbanNumber.Substring(4);
            string ibanControlNumber = plainIbanNumber.Substring(2, 2);
            string complitedCountryCode = GetCountryCode(plainIbanNumber);

            string bbanNumber = ibanNumberEnd + complitedCountryCode + ibanControlNumber;
            try
            {
                bool ibanNumberIsValited = decimal.Parse(bbanNumber) % 97 == 1;
                if (ibanNumberIsValited)
                {
                    returnValue = true;
                }
            }
            catch
            {
                return returnValue;
            }

            return returnValue;

        }// end CheckIbanNumber


        private string GetCountryCode(string plainIbanNumber)
        {
            char[] countryChars = plainIbanNumber.Substring(0, 2).ToUpper().ToCharArray();
            string firstCharNumber = "";
            string secondCharNumber = "";
            string abcList = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            int abcListNumber = 10;
            foreach (char letter in abcList)
            {
                bool thisIsFirstLetter = letter == countryChars[0];
                if (thisIsFirstLetter)
                {
                    firstCharNumber = abcListNumber.ToString();
                }

                bool thisIsSecondLetter = letter == countryChars[1];
                if (thisIsSecondLetter)
                {
                    secondCharNumber = abcListNumber.ToString();
                }

                abcListNumber++;
            }

            string compliteCountryCode = firstCharNumber + secondCharNumber;
            return compliteCountryCode;

        } // end GetCountryCode


    }
}