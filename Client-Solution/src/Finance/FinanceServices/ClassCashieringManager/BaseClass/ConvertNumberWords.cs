using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceServices
{
    internal class ConvertNumberWords
    {
        #region Class Properties Declaration
        private string _strNum;
        public string NumberString
        {
            get
            {
                return _strNum;
            }
        }
        #endregion

        #region Class Constructos
        public ConvertNumberWords()
        {
            _strNum = String.Empty;
        }
        #endregion

        #region Programmers-Defined Functions
        // this procedure is used to process the number
        public void ProcessNumber(long inputNumber, int decNum)
        {
            long wholeNumber;
            long remNumber;
            
            _strNum = "";

            if (inputNumber != 0)
            {
                if (((inputNumber >= 100000000) && (inputNumber <= 999999999)))
                {
                    wholeNumber = DivWholeNumber(inputNumber, 100000000);
                    remNumber = DivRemainder(inputNumber, 100000000);
                    inputNumber = remNumber;
                    NumberWords(wholeNumber, 0, 0, 100);
                    if ((remNumber == 0))
                    {
                        // Ex. 900,000,000; 300,000,000
                        NumberWords(0, 0, 0, 1000000);
                    }
                }

                // Range from 10,000,000 - 99,999,999
                if (((inputNumber >= 10000000) && (inputNumber <= 99999999)))
                {
                    wholeNumber = DivWholeNumber(inputNumber, 10000000);
                    remNumber = DivRemainder(inputNumber, 10000000);
                    inputNumber = remNumber;
                    if ((remNumber < 1000000))
                    {
                        // Ex. 40,000,000; 50,000,000; 60,534,000
                        NumberWords(0, wholeNumber, 0, 1000000);
                    }
                    else if ((wholeNumber == 1))
                    {
                        // Ex. 19,000,000; 15,000,000; 11,467,000
                        wholeNumber = DivWholeNumber(inputNumber, 1000000);
                        remNumber = DivRemainder(inputNumber, 1000000);
                        inputNumber = remNumber;
                        NumberWords(0, 0, wholeNumber, 1000000);
                    }
                    else
                    {
                        // Ex 43,500; 38,267; 99,234
                        NumberWords(0, wholeNumber, 0, 0);
                    }
                }

                // Range from 1,000,000 - 9,999,999
                if (((inputNumber >= 1000000) && (inputNumber <= 9999999)))
                {
                    wholeNumber = DivWholeNumber(inputNumber, 1000000);
                    remNumber = DivRemainder(inputNumber, 1000000);
                    inputNumber = remNumber;
                    NumberWords(wholeNumber, 0, 0, 1000000);
                }

                // Range from 100,000 - 999,999
                if (((inputNumber >= 100000) && (inputNumber <= 999999)))
                {
                    wholeNumber = DivWholeNumber(inputNumber, 100000);
                    remNumber = DivRemainder(inputNumber, 100000);
                    inputNumber = remNumber;
                    NumberWords(wholeNumber, 0, 0, 100);
                    if ((remNumber == 0))
                    {
                        // Ex. 200,000; 500,000; 700,00
                        NumberWords(0, 0, 0, 1000);
                    }
                }

                // Range from 10,000 - 99,999
                if (((inputNumber >= 10000) && (inputNumber <= 99999)))
                {
                    wholeNumber = DivWholeNumber(inputNumber, 10000);
                    remNumber = DivRemainder(inputNumber, 10000);
                    inputNumber = remNumber;
                    if ((remNumber < 1000))
                    {
                        // Ex. 40,000; 50,000; 60,534
                        NumberWords(0, wholeNumber, 0, 1000);
                    }
                    else if ((wholeNumber == 1))
                    {
                        // Ex. 19,000; 15,000; 11,467
                        wholeNumber = DivWholeNumber(inputNumber, 1000);
                        remNumber = DivRemainder(inputNumber, 1000);
                        inputNumber = remNumber;
                        NumberWords(0, 0, wholeNumber, 1000);
                    }
                    else
                    {
                        // Ex 43,500; 38,267; 99,234
                        NumberWords(0, wholeNumber, 0, 0);
                    }
                }

                // Range from 1,000 - 9,999
                if (((inputNumber >= 1000) && (inputNumber <= 9999)))
                {
                    wholeNumber = DivWholeNumber(inputNumber, 1000);
                    remNumber = DivRemainder(inputNumber, 1000);
                    inputNumber = remNumber;
                    NumberWords(wholeNumber, 0, 0, 1000);
                }

                // Range from 100 - 999
                if (((inputNumber >= 100) && (inputNumber <= 999)))
                {
                    wholeNumber = DivWholeNumber(inputNumber, 100);
                    remNumber = DivRemainder(inputNumber, 100);
                    inputNumber = remNumber;
                    NumberWords(wholeNumber, 0, 0, 100);
                }

                // Range from 10 - 99
                if (((inputNumber < 100) && (inputNumber >= 10)))
                {
                    wholeNumber = DivWholeNumber(inputNumber, 10);
                    remNumber = DivRemainder(inputNumber, 10);
                    // Range from 11 - 19
                    if (((inputNumber > 10)
                                && (inputNumber < 20)))
                    {
                        NumberWords(0, 0, remNumber, 0);
                    }
                    else
                    {
                        // range above 20 above
                        if ((remNumber == 0))
                        {
                            NumberWords(0, wholeNumber, 0, 0);
                        }
                        else
                        {
                            NumberWords(0, wholeNumber, 0, 0);
                            NumberWords(remNumber, 0, 0, 0);
                        }
                    }
                }
                else
                {
                    // range from 1 - 9
                    NumberWords(inputNumber, 0, 0, 0);
                }

                // calls the procedure that will process the decimal
                ProcessDecimal(decNum);
                // --------------------
            }          
        }//-----------------------------

        // this procedure processes the decimal
        private void ProcessDecimal(int decNum)
        {
            if (decNum != 0)
            {
                _strNum += "and " + (decNum.ToString() + "/100 Pesos");
            }
            else
            {
                _strNum += "Pesos";
            }
        }//---------------------------

        // this procedure gets the equivalent number to words
        private void NumberWords(long numFirst, long numSecond, long numThird, int numPlace)
        {
            switch (numFirst)
            {
                case 1:
                    _strNum = (_strNum + "One ");
                    break;
                case 2:
                    _strNum = (_strNum + "Two ");
                    break;
                case 3:
                    _strNum = (_strNum + "Three ");
                    break;
                case 4:
                    _strNum = (_strNum + "Four ");
                    break;
                case 5:
                    _strNum = (_strNum + "Five ");
                    break;
                case 6:
                    _strNum = (_strNum + "Six ");
                    break;
                case 7:
                    _strNum = (_strNum + "Seven ");
                    break;
                case 8:
                    _strNum = (_strNum + "Eight ");
                    break;
                case 9:
                    _strNum = (_strNum + "Nine ");
                    break;
            }
            switch (numSecond)
            {
                case 1:
                    _strNum = (_strNum + "Ten ");
                    break;
                case 2:
                    _strNum = (_strNum + "Twenty ");
                    break;
                case 3:
                    _strNum = (_strNum + "Thirty ");
                    break;
                case 4:
                    _strNum = (_strNum + "Forty ");
                    break;
                case 5:
                    _strNum = (_strNum + "Fifty ");
                    break;
                case 6:
                    _strNum = (_strNum + "Sixty ");
                    break;
                case 7:
                    _strNum = (_strNum + "Seventy ");
                    break;
                case 8:
                    _strNum = (_strNum + "Eighty ");
                    break;
                case 9:
                    _strNum = (_strNum + "Ninety ");
                    break;
            }
            switch (numThird)
            {
                case 1:
                    _strNum = (_strNum + "Eleven ");
                    break;
                case 2:
                    _strNum = (_strNum + "Twelve ");
                    break;
                case 3:
                    _strNum = (_strNum + "Thirteen ");
                    break;
                case 4:
                    _strNum = (_strNum + "Forteen ");
                    break;
                case 5:
                    _strNum = (_strNum + "Fifteen ");
                    break;
                case 6:
                    _strNum = (_strNum + "Sixteen ");
                    break;
                case 7:
                    _strNum = (_strNum + "Seventeen ");
                    break;
                case 8:
                    _strNum = (_strNum + "Eighteen ");
                    break;
                case 9:
                    _strNum = (_strNum + "Nineteen ");
                    break;
            }
            switch (numPlace)
            {
                case 100:
                    _strNum = (_strNum + "Hundred ");
                    break;
                case 1000:
                    _strNum = (_strNum + "Thousand ");
                    break;
                case 1000000:
                    _strNum = (_strNum + "Million ");
                    break;
            }
        }//----------------------------

        // this function divides a whole number
        private long DivWholeNumber(long number, int divisor)
        {
            return (number / divisor);
        }//-------------------------

        // this function gets the remainder of the whole number
        private long DivRemainder(long number, int divisor)
        {
            return (number % divisor);
        }//--------------------------
        #endregion
    }
}
