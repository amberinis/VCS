using System;

namespace HomeWork1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World!");
        }

        static bool testRange(int testNumber, int firstNumber, int lastNumber)
        {
            return (testNumber >= firstNumber && testNumber <= lastNumber);
        }
    }
}
