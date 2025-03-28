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
            Console.Write("Введите название файла (без расширения): ");
            string fileName = Console.ReadLine();
            string filePath = fileName + ".txt";

            try
            {
                // Чтение формулы из файла
                string formula = File.ReadAllText(filePath).Trim();
                Console.WriteLine($"Считана формула: {formula}");

                // Вычисление результата
                int result = CalculateFormula(formula);
                Console.WriteLine($"Результат: {result}");

                // Запись результата обратно в файл
                File.WriteAllText(filePath, $"{formula}={result}");
                Console.WriteLine($"Результат записан в файл: {filePath}");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Файл {filePath} не найден.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
                    }
        }
    }
}
