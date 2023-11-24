using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    internal class Calculator<T>
    {
        public T Add(T x, T y) => (dynamic)x + (dynamic)y;
        public T Subtract(T x, T y) => (dynamic)x - (dynamic)y;
        public T Multiply(T x, T y) => (dynamic)x * (dynamic)y;
        public T Divide(T x, T y) => (dynamic)x / (dynamic)y;

        public void PerformOperations(T x, T y)
        {
            Console.WriteLine($"Результат додавання: {Add(x, y)}");
            Console.WriteLine($"Результат віднімання: {Subtract(x, y)}");
            Console.WriteLine($"Результат множення: {Multiply(x, y)}");
            Console.WriteLine($"Результат ділення: {Divide(x, y)}");
        }
    }
}
