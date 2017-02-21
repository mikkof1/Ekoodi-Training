using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barcode_creator
{
    class InternationalReferenceNumberHandler
    {
        public string CalculateInternationalReferenceNumber(string referenceNumber, bool addSeparators = false)
        {
            string returnText = "Not colified number";

            string plainNumber = MakePlainReferenceNumber(referenceNumber, 0);
            bool referenceNumberWrongLenght = plainNumber.Length < 4 || plainNumber.Length > 20;
            if (referenceNumberWrongLenght)
            {
                return returnText;
            }

            string RF_CODE_NUMBER = "271500";
            string calculateNumberString = plainNumber + RF_CODE_NUMBER;
            decimal calculateNumber;
            try
            {
                calculateNumber = decimal.Parse(calculateNumberString);
            }
            catch
            {
                return returnText;
            }

            decimal controlNumber = 98 - (calculateNumber % 97);
            string internationalReferenceNumber = "RF" + controlNumber + plainNumber;

            if (addSeparators)
            {
                string seperatedNumber = "";
                int charIndex = 1;
                foreach (char numberChar in internationalReferenceNumber)
                {
                    seperatedNumber += numberChar;
                    bool addSeparator = charIndex % 4 == 0 && charIndex < internationalReferenceNumber.Length;
                    if (addSeparator)
                    {
                        seperatedNumber += " ";
                    }

                    charIndex++;

                }// foreach

                returnText = seperatedNumber;
            }
            else
            {
                returnText = internationalReferenceNumber;
            }

            return returnText;

        } // end CalculateInternationalReferenceNumber


        public bool CheckReferenceNumber(string referenceNumber)
        {
            bool returnValue = false;

            string plainNumber = MakePlainReferenceNumber(referenceNumber, 2);
            bool referenceNumberWrongLenght = plainNumber.Length < 8 || plainNumber.Length > 24;
            if (referenceNumberWrongLenght)
            {
                return false;
            }

            string referenceLastPart = plainNumber.Substring(4);
            string referenceControlNumber = plainNumber.Substring(2, 2);
            string referenceCodeNumber = plainNumber.Substring(0, 2).ToUpper();

            string firstCharNumber = "";
            string secondCharNumber = "";
            string abcList = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            int abcListNumber = 10;
            foreach (char letter in abcList)
            {
                bool thisIsFirstLetter = letter == referenceCodeNumber[0];
                if (thisIsFirstLetter)
                {
                    firstCharNumber = abcListNumber.ToString();
                }

                bool thisIsSecondLetter = letter == referenceCodeNumber[1];
                if (thisIsSecondLetter)
                {
                    secondCharNumber = abcListNumber.ToString();
                }

                abcListNumber++;
            }

            string testReferenceNumber = referenceLastPart + firstCharNumber + secondCharNumber + referenceControlNumber;

            decimal testResult = decimal.Parse(testReferenceNumber) % 97;

            bool testIsColified = testResult == 1;
            if (testIsColified)
            {
                returnValue = true;
            }

            return returnValue;

        } // end CheckInternationalReferenceNumber


        public string MakePlainReferenceNumber(string originalReferenceNumber, int letterCount)
        {
            string plainReferenceNumber = "";
            int errorCount = 0;
            foreach (char numberChar in originalReferenceNumber)
            {
                bool colifiedNumberChar = char.IsDigit(numberChar);
                if (colifiedNumberChar)
                {
                    plainReferenceNumber += numberChar;
                }
                else
                {
                    bool wrongCharError = numberChar != ' ';
                    if (wrongCharError)
                    {
                        plainReferenceNumber += numberChar;
                        errorCount++;
                    }

                } // else

            } // foreach

            bool tooManyErrorChars = errorCount > letterCount;
            if (tooManyErrorChars)
            {
                return "Error";
            }

            return plainReferenceNumber;

        } // end MakePlainReferenceNumber



    }
}
