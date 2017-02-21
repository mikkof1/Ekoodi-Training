using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barcode_creator
{
    class IbanNumberHandler
    {
        public bool CheckOldFinnishBankNumber(string bankNumber)
        {
            string plainBankNumber = MakePlainAccountNumber(bankNumber, true);

            bool noBankNumberSeperator = plainBankNumber.IndexOf('-') != 6;
            if (noBankNumberSeperator)
            {
                return false;
            }

            bool wrongBankNumberChar = CheckAccountCharErrors(plainBankNumber, 1);
            if (wrongBankNumberChar)
            {
                return false;
            }

            bool wrongBankNumberLenght = plainBankNumber.Length > 15 || plainBankNumber.Length < 8;
            if (wrongBankNumberLenght)
            {
                return false;
            }

            string[] bankNumberParts = plainBankNumber.Split('-');

            bool wrongFirstPartLenght = bankNumberParts[0].Length != 6;
            if (wrongFirstPartLenght)
            {
                return false;
            }

            bool wrongLastPartLenght = bankNumberParts[1].Length < 2 || bankNumberParts[1].Length > 8;
            if (wrongLastPartLenght)
            {
                return false;
            }

            return true;

        } // end CheckOldFinnishkBankNumber


        public string CalculateFinnishIbanNumber(string accountNumber, bool addSeparators = false)
        {
            string returnString = "error";

            string plainNumber = MakePlainAccountNumber(accountNumber, false);

            bool numberIsWrongSize = plainNumber.Length > 14 || plainNumber.Length < 8;
            if (numberIsWrongSize)
            {
                return returnString;
            }

            string zeroAddedBbanNumber = MakeZeroAddedBbanNumber(plainNumber);
            string FINNISH_BBAN_END = "151800";
            string bbanString = zeroAddedBbanNumber + FINNISH_BBAN_END;

            decimal bbanNumber;
            try
            {
                bbanNumber = decimal.Parse(bbanString);
            }
            catch
            {
                return returnString;
            }

            decimal bbanRemainder = bbanNumber % 97;
            decimal ibanControlNumber = 98 - bbanRemainder;

            string ibanNumber;
            bool addExtraControlZero = ibanControlNumber < 10;
            if (addExtraControlZero)
            {
                ibanNumber = "FI0" + ibanControlNumber + zeroAddedBbanNumber;
            }
            else
            {
                ibanNumber = "FI" + ibanControlNumber + zeroAddedBbanNumber;
            }

            returnString = addSeparators ? MakeSeparadetIbanNumber(ibanNumber) : ibanNumber;

            return returnString;

        } // end CalculateFinishIbanNumber


        private string MakePlainAccountNumber(string accountNumber, bool acceptHyphenChar)
        {
            string plainNumber = "";
            foreach (char currentChar in accountNumber)
            {
                bool thisCharIsNumber = Char.IsDigit(currentChar);
                if (thisCharIsNumber)
                {
                    plainNumber += currentChar;
                }
                else
                {
                    bool thisCharIsHyphen = acceptHyphenChar && currentChar == '-';
                    if (thisCharIsHyphen)
                    {
                        plainNumber += currentChar;
                    }
                    else
                    {
                        bool errorChar = currentChar != ' ' && currentChar != '-';
                        if (errorChar)
                        {
                            return "";
                        }
                    }
                }
            }

            return plainNumber;

        } // end MakePlainAccountNumber


        private bool CheckAccountCharErrors(string accountNumber, int maxLetterCount)
        {
            int charErrorCount = 0;
            foreach (char currentChar in accountNumber)
            {
                bool thisCharIsWrong = !Char.IsDigit(currentChar) && (currentChar != ' ');
                if (thisCharIsWrong)
                {
                    charErrorCount++;

                    bool tooManyErrors = charErrorCount > maxLetterCount;
                    if (tooManyErrors)
                    {
                        return true;
                    }
                }
            }

            return false;

        } // end AccountNumberCharErrors


        private string MakeSeparadetIbanNumber(string ibanNumber)
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

            return separateIbanNumber;

        }// end  MakeSeparadetIbanNumber


        private string MakeZeroAddedBbanNumber(string plainNumber)
        {

            string zeroString = "";
            int zeroCount = 14 - plainNumber.Length;
            for (int zeroCountIndex = 0; zeroCountIndex < zeroCount; zeroCountIndex++)
            {
                zeroString += "0";
            }

            string zeroAddedBbanNumber;
            string firstChar = plainNumber.Substring(0, 1);
            bool sevenNumberStart = firstChar == "4" || firstChar == "5";
            if (sevenNumberStart)
            {
                zeroAddedBbanNumber = plainNumber.Substring(0, 7) + zeroString + plainNumber.Substring(7);
            }
            else // six number start
            {
                zeroAddedBbanNumber = plainNumber.Substring(0, 6) + zeroString + plainNumber.Substring(6);
            }

            return zeroAddedBbanNumber;

        } // end MakeZeroAddedBbanNumber


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
