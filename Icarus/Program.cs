using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icarus
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int startIndex = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            int subtract = 1;            

            while (input != "Supernova")
            {
                string[] commands = input.Split();
                string direction = commands[0];
                int steps = int.Parse(commands[1]);

                switch (direction)
                {
                    case "left":

                        while (steps-- > 0)
                        {
                            if (startIndex == 0)
                            {
                                startIndex = numbers.Length - 1;
                                subtract++;                              
                            }
                            else
                            {
                                startIndex--;
                            }

                            numbers[startIndex] -= subtract;

                        }
                        break;

                    case "right":
                        while (steps-- > 0)
                        {
                            if (startIndex == numbers.Length - 1)
                            {
                                startIndex = 0;
                                subtract++;                                
                            }
                            else
                            {
                                startIndex++;
                            }

                            numbers[startIndex] -= subtract;
                        }
                        break;
                }
                    
                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
