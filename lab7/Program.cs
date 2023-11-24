using System;

namespace lab7 {

    class Program
    {
        static void Main()
        {
            Console.WriteLine("int:");
            Calculator<int> intCalculator = new Calculator<int>();
            intCalculator.PerformOperations(5, 3);

            Console.WriteLine("float:");
            Calculator<double> doubleCalculator = new Calculator<double>();
            doubleCalculator.PerformOperations(5.5, 3.2);
        }
    }
}
