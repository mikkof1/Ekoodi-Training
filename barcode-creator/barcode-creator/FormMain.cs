using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace barcode_creator
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

        }


        private void MakeVirtualBarcode()
        {
            string paymentEuros = GetPaymentEuros();
            bool endMakeingBarcode = paymentEuros.Length != 8;
            if (endMakeingBarcode) return;

            string paymentDate = GetPaymentDate();
            endMakeingBarcode = paymentDate.Length != 6;
            if (endMakeingBarcode) return;

            string accountIbanNumber = GetAccountIbanNumber();
            endMakeingBarcode = accountIbanNumber.Length != 16;
            if (endMakeingBarcode) return;

            string virtualBarCode = "";
            string versionNumber = "4";

            bool internationalVirtualBarcode = cbxInternational.Checked;
            if (internationalVirtualBarcode)
            {
                versionNumber = "5";

                string referenceNumber = GetReferenceNumber();
                endMakeingBarcode = referenceNumber.Length != 20;
                if (endMakeingBarcode) return;

                

            } 

            else
            {

                string referenceNumber = GetReferenceNumber();
                endMakeingBarcode = referenceNumber.Length != 20;
                if (endMakeingBarcode) return;

                string backUpSpace = "000";

                virtualBarCode = versionNumber + accountIbanNumber + paymentEuros + backUpSpace + referenceNumber +
                                 paymentDate;

            }

            txbVirtualBarcode.Text = virtualBarCode;

            string firstEmptySpace = "";
            string firstMark = "";
            string examine2 = "";
            string endMark = "";
            string emptySpace2 = "";











        } //end MakeVirtualBarcode



        private string GetPaymentDate()
        {
            bool earlyPaymentDay = dtpPaymentDate.Value.Date <= DateTime.Today;
            if (earlyPaymentDay)
            {
                DialogResult dateQuestion = MessageBox.Show("Eräpäiväksi on merkitty " + dtpPaymentDate.Value.ToShortDateString() + "\n\rHaluatko jatkaa?", "Eräpäivä ristiriita", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                bool endMakeingBarcode = dateQuestion == DialogResult.No;
                if (endMakeingBarcode)
                {
                    return "";
                }

            }

            string paymentDateYear = dtpPaymentDate.Value.Year.ToString().Substring(2, 2);

            string paymentDateMonth = dtpPaymentDate.Value.Month.ToString();
            bool shortDateMonth = paymentDateMonth.Length < 2;
            if (shortDateMonth) { paymentDateMonth = "0" + paymentDateMonth; }

            string paymentDateDay = dtpPaymentDate.Value.Day.ToString();
            bool shortDateDay = paymentDateDay.Length < 2;
            if (shortDateDay) { paymentDateDay = "0" + paymentDateDay; }

            string paymentDate = paymentDateYear + paymentDateMonth + paymentDateDay;

            return paymentDate;

        } // end GetPaymentDate()



        private string GetPaymentEuros()
        {

            bool paymentIsEmpty = txbMoneySummarium.Text == string.Empty;
            if (paymentIsEmpty)
            {
                DialogResult dateQuestion = MessageBox.Show("Summa on jätetty tyhjäksi " + "\n\rHaluatko jatkaa?", "Tyhjä summa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                bool endMakeingBarcode = dateQuestion == DialogResult.No;
                return (endMakeingBarcode) ? "" : "00000000";
            }

            decimal paymentSummarium = 0;
            try
            {
                paymentSummarium = decimal.Parse(txbMoneySummarium.Text);
            }
            catch
            {
                MessageBox.Show("Summa on merkitty väärin", "Väärä summa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }

            string returnValue = "";
            bool paymentIsBigerThenZero = paymentSummarium > 0;
            returnValue = paymentIsBigerThenZero ? MakeMoneyString(paymentSummarium) : "00000000";

            return returnValue;

        } // end GetPaymentEuros()


        private string MakeMoneyString(decimal paymentSummarium)
        {
            string[] paymentSplit = paymentSummarium.ToString().Split(',');
            string euros = paymentSplit[0];

            decimal MAX_PAYMENT = 999999;
            bool paymentIsTooBig = euros.Length > 6 || paymentSummarium > MAX_PAYMENT;
            if (paymentIsTooBig)
            {
                DialogResult dateQuestion = MessageBox.Show("Summa on liian suuri " + "\n\rHaluatko jatkaa?", "Liian iso summa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                bool endMakeingBarcode = dateQuestion == DialogResult.No;
                return (endMakeingBarcode) ? "" : "00000000";
            }

            string paymentFirstZeros = "";
            for (int firstZeroIndex = 0; firstZeroIndex < 6 - euros.Length; firstZeroIndex++)
            {
                paymentFirstZeros += "0";
            }

            string cents = "";
            bool centsAreMarked = paymentSplit.Length > 1;
            if (centsAreMarked)
            {
                bool centsAreMarkedShort = paymentSplit[1].Length < 2;
                if (centsAreMarkedShort)
                {
                    bool onlyCommaMarked = paymentSplit[1] == string.Empty;
                    cents = (onlyCommaMarked) ? "00" : paymentSplit[1] + "0";
                }
                else
                {
                    cents = paymentSplit[1].Substring(0, 2);
                }

            }
            else
            {
                cents = "00";
            }

            return paymentFirstZeros + euros + cents;

        } // end MakeMoneyString


        private string GetAccountIbanNumber()
        {
            string returnValue = "";
            string originalAccountNumber = txbAccountNumber.Text;

            bool accountNumberIsEmpty = originalAccountNumber == string.Empty;
            if (accountNumberIsEmpty)
            {
                MessageBox.Show("Tilinumero puuttuu", "Puutteellinen tieto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return returnValue;
            }

            string plainNumber = GetPlainAccountNumber(originalAccountNumber);


            bool correctLenghtIbanNumber = CorrectIbanNumberTest(plainNumber);
            if (correctLenghtIbanNumber)
            {
                IbanNumberHandler ibanNumberTest = new IbanNumberHandler();
                bool correctIbanNumber = ibanNumberTest.CheckIbanNumber(plainNumber);
                if (correctIbanNumber)
                {
                    returnValue = plainNumber.Substring(2);
                    return returnValue;
                }
                else
                {
                    MessageBox.Show("Tilinumero on väärin", "Virheellinen tieto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return returnValue;
                }
            }
            else // new IBAN number
            {
                IbanNumberHandler newIbanNumber = new IbanNumberHandler();
                string accountNumber = newIbanNumber.CalculateFinnishIbanNumber(plainNumber);

                bool ibanNumberIsCorrect = accountNumber.Length == 18;
                if (ibanNumberIsCorrect)
                {
                    MessageBox.Show("Tilinumero muutetaan IBAN muotoon", "Virheellinen tieto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    returnValue = accountNumber.Substring(2);
                    return returnValue;
                }
                else
                {
                    MessageBox.Show("Tilinumero on väärin", "Virheellinen tieto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return returnValue;
                }
            }

        } // end GetAccountIbanNumber()

        private bool CorrectIbanNumberTest(string plainNumber)
        {
            bool wrongIbanLenght = plainNumber.Length != 18;
            if (wrongIbanLenght) return false;

            string ibanCountryMarks = plainNumber.Substring(0, 2).ToUpper();

            bool firstMarkIsWrong = !char.IsLetter(ibanCountryMarks[0]);
            if (firstMarkIsWrong) return false;

            bool secondMarkIsWrong = !char.IsLetter(ibanCountryMarks[1]);
            if (secondMarkIsWrong) return false;

            return true;

        } // end CorrectIbanNumber



        private string GetPlainAccountNumber(string originalAccountNumber)
        {
            string plainNumber = "";
            int letterCount = 0;
            foreach (char currentChar in originalAccountNumber)
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
                        plainNumber += currentChar;
                        bool tooManyWrongChars = letterCount > 2;
                        if (tooManyWrongChars)
                        {
                            return "";
                        }
                    }
                }
            }

            return plainNumber;

        }// end GetPlainAccountNumber


        private string GetReferenceNumber()
        {
            string returnValue = "";
            string originalReferenceNumber = txbReferenceNumber.Text;

            bool referenceNumberIsEmpty = CheckEmptyReferenceNumber(originalReferenceNumber);
            if (referenceNumberIsEmpty) return returnValue;

            ReferenceNumberHandler referenceNumberTest = new ReferenceNumberHandler();
            string plainReferenceNumber = referenceNumberTest.MakePlainReferenceNumber(originalReferenceNumber);

            bool correctReferenceNumber = referenceNumberTest.CheckFinnishReferenceNumber(plainReferenceNumber);
            if (correctReferenceNumber)
            {
                string firstZeros = ReferenceNumberFirstZeros(plainReferenceNumber);
                returnValue = firstZeros + plainReferenceNumber;
                return returnValue;
            }
            else
            {
                ReferenceNumberHandler newReferenceNumberHandler = new ReferenceNumberHandler();
                string newReferenceNumber = newReferenceNumberHandler.MakeFinnishReferenceNumber(plainReferenceNumber);

                bool correctNewReferenceNumber = referenceNumberTest.CheckFinnishReferenceNumber(newReferenceNumber);
                if (correctNewReferenceNumber)
                {
                    DialogResult wrongReferenceDialog = MessageBox.Show(
                        "Haluatko laskea viitenumeron tarkisteen uudelleen?", "Virheellinen viitenumero",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (wrongReferenceDialog == DialogResult.No)
                    {
                        return returnValue;
                    }
                    else
                    {
                        string firstZeros = ReferenceNumberFirstZeros(plainReferenceNumber);
                        returnValue = firstZeros + newReferenceNumber;
                        return returnValue;
                    }
                }
                else
                {
                    MessageBox.Show("Viitenumero on virheellinen", "Virheellinen tieto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return returnValue;
                }
            }


        } // end GetReferenceNumber


        private bool CheckEmptyReferenceNumber(string originalReferenceNumber)
        {
            bool referenceNumberIsEmpty = originalReferenceNumber == string.Empty;
            if (referenceNumberIsEmpty)
            {
                MessageBox.Show("Viitenumero puuttuu", "Puutteellinen tieto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            return false;

        } // end CheckFillReferenceNumber


        private string ReferenceNumberFirstZeros(string referenceNumber)
        {
            string firstZeros = "";
            int zeroCount = 20 - referenceNumber.Length;
            for (int i = 0; i < zeroCount; i++)
            {
                firstZeros += "0";
            }
            return firstZeros;

        } // end ReferenceNumberFirstZeros


        private string GetInternationalreferenceNumber()
        {
            string returnValue = "";
            string originalReferenceNumber = txbReferenceNumber.Text;

            bool referenceNumberIsEmpty = CheckEmptyReferenceNumber(originalReferenceNumber);
            if (referenceNumberIsEmpty) return returnValue;

            InternationalReferenceNumberHandler referenceNumberTest = new InternationalReferenceNumberHandler();
            string plainReferenceNumber = referenceNumberTest.MakePlainReferenceNumber(originalReferenceNumber, 2);

            bool correctReferenceNumber = referenceNumberTest.CheckReferenceNumber(plainReferenceNumber);
            if (correctReferenceNumber)
            {
                returnValue = plainReferenceNumber.Substring(2);
                return returnValue;
            }

            else
            {
                InternationalReferenceNumberHandler newReferenceNumberHandler = new InternationalReferenceNumberHandler();
                string newReferenceNumber = newReferenceNumberHandler.CalculateInternationalReferenceNumber(plainReferenceNumber);

                bool correctNewReferenceNumber = referenceNumberTest.CheckReferenceNumber(newReferenceNumber);
                if (correctNewReferenceNumber)
                {
                    DialogResult wrongReferenceDialog = MessageBox.Show(
                        "Haluatko laskea viitenumeron tarkisteen uudelleen?", "Virheellinen viitenumero",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (wrongReferenceDialog == DialogResult.No)
                    {
                        return returnValue;
                    }
                    else
                    {
                        returnValue = newReferenceNumber.Substring(2);
                        return returnValue;
                    }
                }
                else
                {
                    MessageBox.Show("Viitenumero on virheellinen", "Virheellinen tieto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return returnValue;
                }
            }

        } // end GetInternationalreferenceNumber


        private void DrawBarcode()
        {
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile("D:\\Resources\\code128.ttf");
            int tt = pfc.Families.Length;

            string codeString = txbVirtualBarcode.Text;
            Bitmap barBitmap = new Bitmap(codeString.Length * 40, 80);
            using (Graphics graphis = Graphics.FromImage(barBitmap))
            {
                Font barFont = new Font(pfc.Families[0], 40); //new System.Drawing.Font("Arial", 20);
                PointF barPoint = new PointF(2f, 10f);
                SolidBrush blackBruch = new SolidBrush(Color.Black);
                SolidBrush whiteBruch = new SolidBrush(Color.White);
                graphis.FillRectangle(whiteBruch, 0, 0, barBitmap.Width, barBitmap.Height);
                graphis.DrawString("" + codeString + "", barFont, blackBruch, barPoint);

            }
            using (MemoryStream ms = new MemoryStream())
            {
                barBitmap.Save(ms, ImageFormat.Png);
                picBarcodeDraw.Image = barBitmap;
                picBarcodeDraw.Height = barBitmap.Height;
                picBarcodeDraw.Width = barBitmap.Width;

            }

        }



        // *******************************************************************************************
        // Form Events
        // *******************************************************************************************

        private void btnMakeVirtualBarcode_Click(object sender, EventArgs e)
        {
            //  DrawBarcode();
              MakeVirtualBarcode();
            //  GetPaymentEuros();
            // string rr=    GetPaymentDate();
            //   string dd = GetAccountIbanNumber();
            // string rr = GetReferenceNumber();
           // string ff = GetInternationalreferenceNumber();
        }



        private void txbMoneySummarium_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool acceptNumbersAndComma = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',');
            if (acceptNumbersAndComma)
            {
                e.Handled = true;
            }

            bool acceptOnlyOneComma = (e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1);
            if (acceptOnlyOneComma)
            {
                e.Handled = true;
            }

        } // end of txbMoneySummarium_KeyPress



    }
}
