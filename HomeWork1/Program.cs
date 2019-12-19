using System;
using System.Collections.Generic;

namespace HomeWork1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(ChangeNumberToText(GetIntNumberInput(-999999999, 999999999)));
        }

        static bool InRange(int testNumber, int firstNumber, int lastNumber)
        {
            return (testNumber >= firstNumber && testNumber <= lastNumber);
        }

        static bool IsNumber(string testNumber)
        {
            int numberLength = testNumber.Length;
            if (string.IsNullOrEmpty(testNumber))
            {
                return false;
            }

            int i = 0;
            char testSymbol = testNumber[i];

            if ((testSymbol != '-' && !char.IsDigit(testSymbol)) || (testSymbol == '-' && numberLength == 1))
            {
                return false;
            }

            for (i = 1; i < numberLength; i++)
            {
                testSymbol = testNumber[i];
                if (!char.IsDigit(testSymbol))
                {
                    return false;
                }
            }
            return true;
        }

        static int GetIntNumberInput(int min, int max)
        {
            int inputNumber;
            string inputString;
            do
            {
                Console.Write($"Please enter number from {min} to {max}: ");
                inputString = Console.ReadLine();
                while (!IsNumber(inputString))
                {
                    Console.Write($"Please enter correct number!: ");
                    inputString = Console.ReadLine();
                }

                inputNumber = Convert.ToInt32(inputString);
            } while (!InRange(inputNumber, min, max));

            return inputNumber;
        }

        static string ChangeNumberToText(int inputNumber)
        {
            if (inputNumber == 0)
                return "nulis";

            if (inputNumber < 0)
                return "minus " + ChangeNumberToText(-inputNumber);

            List<string> unitsList = new List<string>() { "nulis", "vienas", "du", "trys", "keturi", "penki", "šeši", "septyni", "aštuoni", "devyni", "dešimt", "vienuolika", "dvilika", "trylika", "keturiolika", "penkiolika", "šešiolika", "septyniolika", "aštuoniolika", "devyniolika" };
            List<string> tensList = new List<string>() { "nulis", "dešimt", "dvidešimt ", "trysdešimt ", "keturiasdešimt ", "penkiasdešimt ", "šešiasdešimt ", "septyniasdešimt ", "aštuoniasdešimt ", "devyniasdešimt " };

            string stringNumber = "";

            if ((inputNumber % 1000000) == 1 || (((inputNumber / 1000000) % 10) == 1 && (inputNumber / 1000000) > 20) || (((inputNumber / 1000000) % 100 % 10) == 1 && ((inputNumber / 1000000) % 100) > 20))
            {
                stringNumber += ChangeNumberToText(inputNumber / 1000000) + " milijonas ";
                inputNumber %= 1000000;
            }
            if (((inputNumber / 1000000) > 1 && (inputNumber / 1000000) < 10) || (((inputNumber / 1000000) % 10) > 1 && ((inputNumber / 1000000) % 10) < 10) || (((inputNumber / 1000000) % 100 % 10) > 1 && ((inputNumber / 1000000) % 100) < 10))
            {
                stringNumber += ChangeNumberToText(inputNumber / 1000000) + " milijonai ";
                inputNumber %= 1000000;
            }
            if ((inputNumber / 1000000) >= 10 && ((inputNumber / 1000000) % 10) == 0)
            {
                stringNumber += ChangeNumberToText(inputNumber / 1000000) + " milijonų ";
                inputNumber %= 1000000;
            }

            if ((inputNumber % 1000) == 1 || (((inputNumber / 1000) % 10) == 1 && (inputNumber / 1000) > 20))
            {
                stringNumber += ChangeNumberToText(inputNumber / 1000) + " tūkstantis ";
                inputNumber %= 1000;
            }
            if (((inputNumber / 1000) > 1 && (inputNumber / 1000) < 10) || (((inputNumber / 1000) % 10) > 1 && ((inputNumber / 1000) % 10) < 10))
            {
                stringNumber += ChangeNumberToText(inputNumber / 1000) + " tūkstančiai ";
                inputNumber %= 1000;
            }
            if ((inputNumber / 1000) >= 10 && ((inputNumber / 1000) % 10) == 0)
            {
                stringNumber += ChangeNumberToText(inputNumber / 1000000) + " tūkstančių ";
                inputNumber %= 1000;
            }

            if ((inputNumber / 100) == 1)
            {
                stringNumber += ChangeNumberToText(inputNumber / 100) + " šimtas ";
                inputNumber %= 100;
            }
            if ((inputNumber / 100) > 1 && (inputNumber / 100) < 10)
            {
                stringNumber += ChangeNumberToText(inputNumber / 100) + " šimtai ";
                inputNumber %= 100;
            }
            if (inputNumber > 0)
            {
                if (inputNumber < 20)
                    stringNumber += unitsList[inputNumber];
                else
                {
                    stringNumber += tensList[inputNumber / 10];
                    if ((inputNumber % 10) > 0)
                        stringNumber += unitsList[inputNumber % 10];
                }
            }
            return stringNumber;
        }
    }
}
