using System;
using System.Collections.Generic;
using System.Linq;

namespace kr4_v8
{
    class Program
    {
        static int CalculateFormula(string formula)
        {
            Stack<object> stack = new Stack<object>();
            for(int i= 0; i<formula.Length;i++)
            {
                char c = formula[i];
                if (char.IsDigit(c))
                {
                    stack.Push(int.Parse(c.ToString()));
                }
                else if (c=='M' || c == 'm')
                {
                    stack.Push(c);
                }
                else if (c==')')
                {
                    var operands = new List<int>();

                    while (stack.Count>0 && stack.Peek() is int)
                    {
                        operands.Add((int)stack.Pop());
                    }
                    char operation = (char)stack.Pop();
                    int result = operation == 'M' ? operands.Max() : operands.Min();
                    stack.Push(result);
                }
                    }
            return (int)stack.Pop();
        }
        static void Main(string[] args)
        {
            string[] test = { "5", "M(3,5)", "m(3,5)", "M(m(4,6),M(1,2))", "M(M(3,5),M(1,2))", "M(m(3,9),m(1,2))", "m(m(2,3),M(5,8))" };

            for (int i = 0; i < test.Length; i++)
            {
                Console.WriteLine($"Формула = {test[i]}\nРезультат = {CalculateFormula(test[i])}");
                    }
        }
    }
}
