using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecodeRadioFrequences
{
    class DecodeRadioFrequences
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine().Split().ToList();
            
            List<char> parsedNumbers = new List<char>();

            for (int i = 0; i < numbers.Count; i++)
            {
                string[] elementParts = numbers[i].Split('.');

                int leftPart = int.Parse(elementParts[0]);
                if (leftPart != 0)
                {
                    parsedNumbers.Insert(i, (char)leftPart);
                }
            }

            int leftLength = parsedNumbers.Count;

            for (int i = 0; i < numbers.Count; i++)
            {
                string[] elementParts = numbers[i].Split('.');

                int rightPart = int.Parse(elementParts[1]);
                if (rightPart != 0)
                {
                    parsedNumbers.Insert(leftLength, (char)rightPart);
                }
            }

            Console.WriteLine(string.Join("", parsedNumbers));
        }
    }
}
