using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayContainsElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int element = int.Parse(Console.ReadLine());

            Console.WriteLine(array.Contains(element) ? "yes" : "no");
                      
            //bool isInArray = false;

            //for (int i = 0; i < array.Length; i++)
            //{
            //    if (array[i] == element)
            //    {
            //        isInArray = true;
            //        break;
            //    }
            //}

            //if (isInArray)
            //{
            //    Console.WriteLine("yes");
            //}
            //else
            //{
            //    Console.WriteLine("no");
            //}
        }
    }
}
