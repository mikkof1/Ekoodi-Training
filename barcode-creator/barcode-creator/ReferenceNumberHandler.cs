﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barcode_creator
{
    class ReferenceNumberHandler
    {
        public string MakeFinnishReferenceNumber(string referenceNumberFirstPart, bool seperatedReferenceNumber = false)
        {
            string returnText = "Error";

            string plainReferenceNumber = MakePlainReferenceNumber(referenceNumberFirstPart);


            bool wrongSizeReferenceNumber = plainReferenceNumber.Length < 3 || plainReferenceNumber.Length > 19;
            if (wrongSizeReferenceNumber)
            {
                return returnText;
            }

            decimal referenceSummarium = CalculateReferenceSummarium(plainReferenceNumber);

            decimal referenceChekerNumber = 10 - (referenceSummarium % 10);
            string readyReferenceNumber = plainReferenceNumber + referenceChekerNumber;

            if (seperatedReferenceNumber)
            {
                string seperatedNumberText = "";
                int seperatedCounter = 5 - (readyReferenceNumber.Length % 5);
                int referenceIndex = 0;
                foreach (char referenceChar in readyReferenceNumber)
                {
                    referenceIndex++;
                    seperatedCounter++;
                    seperatedNumberText += referenceChar;

                    bool addNeededSeperator = seperatedCounter % 5 == 0 && referenceIndex < readyReferenceNumber.Length;
                    if (addNeededSeperator)
                    {
                        seperatedNumberText += " ";
                    }

                }
                returnText = seperatedNumberText;
            }
            else
            {
                returnText = readyReferenceNumber;
            }
            return returnText;

        } // end of MakeFinnishReferenceNumber


        public string MakePlainReferenceNumber(string originalReferenceNumber)
        {
            string plainReferenceNumber = "";
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
                        return "";
                    }
                }
            }
            return plainReferenceNumber;

        }// end MakePlainReferenceNumber


        private decimal CalculateReferenceSummarium(string plainReferenceNumber)
        {
            decimal referenceSummarium = 0;
            int weightCounter = 1;
            for (int plainNumberCharIndex = plainReferenceNumber.Length; plainNumberCharIndex > 0; plainNumberCharIndex--)
            {
                char numberChar = plainReferenceNumber[plainNumberCharIndex - 1];

                bool firstWeightFactor = weightCounter % 3 == 1;
                if (firstWeightFactor)
                {
                    referenceSummarium += decimal.Parse(numberChar.ToString()) * 7;
                }

                bool secondWeightFactor = weightCounter % 3 == 2;
                if (secondWeightFactor)
                {
                    referenceSummarium += decimal.Parse(numberChar.ToString()) * 3;
                }

                bool thirdWeightFactor = weightCounter % 3 == 0;
                if (thirdWeightFactor)
                {
                    referenceSummarium += decimal.Parse(numberChar.ToString()) * 1;
                }

                weightCounter++;
            }

            return referenceSummarium;
        }


        public bool CheckFinnishReferenceNumber(string referenceNumber)
        {
            bool referenceNumberIsEmpty = referenceNumber.Length <= 0;
            if (referenceNumberIsEmpty)
            {
                return false;
            }

            string plainReferenceNumber = "";
            foreach (char referenceNumberChar in referenceNumber)
            {
                if (char.IsDigit(referenceNumberChar))
                {
                    plainReferenceNumber += referenceNumberChar;
                }
                else
                {
                    bool wrongCharError = referenceNumberChar != ' ';
                    if (wrongCharError)
                    {
                        return false;
                    }
                }
            }

            string testFirstPart = plainReferenceNumber.Substring(0, plainReferenceNumber.Length - 1);
            string testReferenceNumber = MakeFinnishReferenceNumber(testFirstPart);

            bool colifiedReferenceNumber = testReferenceNumber == plainReferenceNumber;

            return colifiedReferenceNumber;

        } // end of CheckFinnishReferenceNumber


    }
}
