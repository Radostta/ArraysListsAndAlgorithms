using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainer_MyExam
{
    class Rainer_MyExam
    {
        static void Main(string[] args)
        {
            var integers = Console.ReadLine();

            var lastInteger = int.Parse(integers.Substring(integers.Length - 1));
            integers = integers.Remove(integers.Length - 1);

            var sequence = integers.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int initialIndex = lastInteger;

            var initialSequence = new int[sequence.Length];
            for (int i = 0; i < sequence.Length; i++)
            {
                initialSequence[i] = sequence[i];
            }

            bool isWet = false;
            int steps = 0;

            while (true)
            {
                for (int i = 0; i < sequence.Length; i++)
                {
                    sequence[i]--;
                }

                if (initialIndex < 0 || initialIndex > sequence.Length - 1)
                {
                    break;
                }

                if (sequence[initialIndex] == 0)
                {
                    isWet = true;
                    break;
                }

                steps++;

                for (int i = 0; i < initialSequence.Length; i++)
                {
                    if (sequence[i] == 0)
                    {
                        sequence[i] = initialSequence[i];
                    }
                }


                initialIndex = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(string.Join(" ", sequence));
            Console.WriteLine(steps);
        }
    }
}
