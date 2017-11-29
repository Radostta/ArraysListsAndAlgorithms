using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayManipulator
{
    class ArrayManipulator
    {
        static void Main()
        {
            //Judge points: 100/100

            var arr = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string line = Console.ReadLine();

            while (line != "end")
            {
                string[] tokens = line.Split();
                string command = tokens[0];

                switch (command)
                {
                    case "exchange":
                        int index = int.Parse(tokens[1]);                        
                        arr = ExchangeArrayElements(arr, index);    
                        
                        break;

                    case "max":
                    case "min":
                        string maxOrMin = command;
                        string evenOrOdd = tokens[1];                        
                        FindMaxOrMinEvenOrOddElement(arr, maxOrMin, evenOrOdd);

                        break;

                    case "first":
                    case "last":
                        string firstOrLast = command;
                        int count = int.Parse(tokens[1]);
                        evenOrOdd = tokens[2];
                        FindFirstOrLastEvenOrOddElement(arr, firstOrLast, count, evenOrOdd);

                        break;
                }

                line = Console.ReadLine();
            }

            Console.WriteLine("[{0}]", string.Join(", ", arr));
        }


        private static void FindFirstOrLastEvenOrOddElement(int[] arr, string firstOrLast, int count, string evenOrOdd)
        {
            if (count > arr.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            int evenOrOddParity = evenOrOdd == "even" ? 0 : 1;
            var evenOrOddElements = arr.Where(x => x % 2 == evenOrOddParity);

            int[] foundElements;

            if (firstOrLast == "first")
            {
                foundElements = evenOrOddElements.Take(count).ToArray();
            }
            else
            {
                foundElements = evenOrOddElements.Reverse().Take(count).Reverse().ToArray();
            }

            Console.WriteLine("[{0}]", string.Join(", ", foundElements));
        }

        private static void FindMaxOrMinEvenOrOddElement(int[] arr, string maxOrMin, string evenOrOdd)
        {
            int evenOrOddParity = evenOrOdd == "even" ? 0 : 1;
            var evenOrOddElements = arr.Where(x => x % 2 == evenOrOddParity);

            if (!evenOrOddElements.Any())
            {
                Console.WriteLine("No matches");
                return;
            }

            int maxOrMinElement = 0;
            if (maxOrMin == "max")
            {
                maxOrMinElement = evenOrOddElements.Max();
            }
            else
            {
                maxOrMinElement = evenOrOddElements.Min();
            }

            int maxOrMinElementIndex = Array.LastIndexOf(arr, maxOrMinElement);
            Console.WriteLine(maxOrMinElementIndex);

        }

        static int[] ExchangeArrayElements(int[] arr, int index)
        {
            //return arr.Skip(index).Concat(arr.Take(3)).ToArray();

            bool isValidIndex = index >= 0 && index < arr.Length;
            if (!isValidIndex)
            {
                Console.WriteLine("Invalid index");
                return arr;
            }

            var leftPart = arr.Take(index + 1);
            var rightPart = arr.Skip(index + 1);

            var combinedArr = rightPart.Concat(leftPart).ToArray();
            return combinedArr;
        }
    }
}