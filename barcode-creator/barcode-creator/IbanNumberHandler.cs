using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barcode_creator
{
    class IbanNumberHandler
    {
        public string CalculateFinnishIbanNumber(string numberString, bool addSeparators = false)
        {
            string returnValue = "";

            string plainNumber = "";
            int letterCount = 0;
            foreach (char currentChar in numberString)
            {
                bool thisCharIsNumber = Char.IsNumber(currentChar);
                if (thisCharIsNumber)
                {
                    plainNumber += currentChar;
                }
                else
                {
                    bool thisIsLetter = Char.IsLetter(currentChar);
                    if (thisIsLetter)
                    {
                        letterCount++;
                        bool tooManyWrongChars = letterCount > 2;
                        if (tooManyWrongChars)
                        {
                            return returnValue;
                        }
                    }// (thisIsLetter)

                }// else

            }// foreach

            string zeroString = "";
            int zeroCount = 14 - plainNumber.Length;
            bool numberIsWrongSize = plainNumber.Length > 14 || plainNumber.Length < 8;
            if (numberIsWrongSize)
            {
                return returnValue;
            }
            else
            {
                for (int i = 0; i < zeroCount; i++)
                {
                    zeroString += "0";
                }
            }

            string zeroAddedString = "";
            string firstChar = plainNumber.Substring(0, 1);
            bool sevenNumberStart = firstChar == "4" || firstChar == "5";
            if (sevenNumberStart)
            {
                zeroAddedString = plainNumber.Substring(0, 7) + zeroString + plainNumber.Substring(7);
            }
            else // six number start
            {
                zeroAddedString = plainNumber.Substring(0, 6) + zeroString + plainNumber.Substring(6);
            }

            string FINNISH_BBAN_END = "151800";
            string bbanString = zeroAddedString + FINNISH_BBAN_END;
            decimal bbanNumber = 0;
            try
            {
                bbanNumber = decimal.Parse(bbanString);
            }
            catch
            {
                return returnValue;
            }
            decimal bbanRemainder = bbanNumber % 97;
            decimal ibanControlNumber = 98 - bbanRemainder;

            string ibanNumber = "";
            bool addExtraControlZero = ibanControlNumber < 10;
            if (addExtraControlZero)
            {
                ibanNumber = "FI0" + ibanControlNumber + zeroAddedString;
            }
            else
            {
                ibanNumber = "FI" + ibanControlNumber + zeroAddedString;
            }


            if (addSeparators)
            {
                int rowCounter = 0;
                string separateIbanNumber = "";
                foreach (char ibanChar in ibanNumber)
                {
                    separateIbanNumber += ibanChar;

                    rowCounter++;
                    if (rowCounter > 3)
                    {
                        rowCounter = 0;
                        separateIbanNumber += " ";
                    }
                }
                returnValue = separateIbanNumber;
            }
            else
            {
                returnValue = ibanNumber;
            }

            return returnValue;

        } // end CalculateFinishIbanNumber


        public bool CheckIbanNumber(string IbanNumber)
        {
            bool returnValue = false;

            string plainIbanNumber = "";
            int ibanLeterCount = 0;
            foreach (char ibanNumberChar in IbanNumber)
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

            bool IbanNumberIsNotValid = ibanLeterCount > 2 || plainIbanNumber.Length != 18;
            if (IbanNumberIsNotValid)
            {
                return returnValue;
            }

            string ibanNumberEnd = plainIbanNumber.Substring(4);
            string ibanControlNumber = plainIbanNumber.Substring(2, 2);

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

            string bbanNumber = ibanNumberEnd + firstCharNumber + secondCharNumber + ibanControlNumber;
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


    }
}
