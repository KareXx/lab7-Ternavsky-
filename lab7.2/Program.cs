using System;
using System.Collections.Generic;


namespace lab7._2{
    class Program
    {
        static void Main()
        {
            FunctionCache<string, int> cache = new FunctionCache<string, int>();

            FunctionCache<string, int>.Func<string, int> stringLengthFunc = key => key.Length;

            int length1 = cache.GetOrAdd("Hello", stringLengthFunc, TimeSpan.FromSeconds(5));
            Console.WriteLine($"Length of 'Hello': {length1}");

            int length2 = cache.GetOrAdd("Hello", stringLengthFunc, TimeSpan.FromSeconds(5)); // Результат береться з кешу
            Console.WriteLine($"Length of 'Hello': {length2}");

            int length3 = cache.GetOrAdd("World", stringLengthFunc, TimeSpan.FromSeconds(5));
            Console.WriteLine($"Length of 'World': {length3}");
        }
    }
}
