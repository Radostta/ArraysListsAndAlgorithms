using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddNumbersAtOddPositions
{
    class OddNumbersAtOddPositions
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 1; i < input.Length; i += 2)
            {
                if (input[i] % 2 != 0)
                {
                    Console.WriteLine($"Index {i} -> {input[i]}");
                }
            }
        }
    }
}
