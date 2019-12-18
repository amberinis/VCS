using System;

namespace HomeWork1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World!");
        }

        static bool inRange(int testNumber, int firstNumber, int lastNumber)
        {
            return (testNumber >= firstNumber && testNumber <= lastNumber);
        }

        static bool isNumber(string testNumber)
        {
            for (int i = 0; i < testNumber.Length; i++)
            {
                char testSymbol = testNumber[i];
                if (!char.IsDigit(testSymbol))
                {
                    return false;
                    break;
                }

            }
            return true;
        }
    }
}
