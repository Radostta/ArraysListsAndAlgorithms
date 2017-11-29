using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortNumbers
{
    class SortNumbers
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(double.Parse).ToList();

            numbers.Sort();
            //numbers.Sort((a, b) => (a - b)); //sort by descending

            Console.WriteLine(string.Join(" <= ", numbers));
        }
    }
}
