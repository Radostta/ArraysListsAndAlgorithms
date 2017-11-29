using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestNElements
{
    class LargestNElements
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int n = int.Parse(Console.ReadLine());

            var result = new List<int>();
            numbers.Sort();

            for (int i = numbers.Count - 1; i > numbers.Count - 1 - n; i--)
            {
                result.Add(numbers[i]);
            }

            //numbers.Sort((a, b) => (b - a));
            //result.AddRange(numbers.Take(n));

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
