using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonDontGo
{
    class PokemonDontGo
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            int sum = 0;
            int value = 0;

            while (numbers.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());

                value = 0;

                if (index < 0)
                {
                    value = numbers[0];
                    var firstElement = numbers[numbers.Count - 1];
                    numbers.RemoveAt(0);
                    numbers.Insert(0, firstElement);                    
                }
                else if (index > numbers.Count - 1)
                {
                    value = numbers[numbers.Count - 1];
                    int lastElement = numbers[0];
                    numbers.RemoveAt(numbers.Count - 1);
                    numbers.Add(lastElement);
                }
                else
                {
                    value = numbers[index];
                    numbers.RemoveAt(index);
                }

                sum += value;

                numbers = IncreaseOrDecreaseElements(numbers, value);
            }

            Console.WriteLine(sum);
        }

        private static List<int> IncreaseOrDecreaseElements(List<int> numbers, int value)
        {           
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] <= value)
                {
                    numbers[i] += value;
                }
                else
                {
                    numbers[i] -= value;
                }

            }

            return numbers;
        }
    }
}
