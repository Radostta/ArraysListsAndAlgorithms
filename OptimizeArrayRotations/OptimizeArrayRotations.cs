using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizeArrayRotations
{
    class OptimizeArrayRotations
    {
        static void Main(string[] args)
        {
            //rotating right

            string[] array = Console.ReadLine().Split();
            int rotationsCount = int.Parse(Console.ReadLine());

            for (int r = 0; r < rotationsCount % array.Length; r++)
            {
                string temp = array[array.Length - 1];

                for (int i = array.Length - 1; i >= 1; i--)
                {
                    array[i] = array[i - 1];
                }

                array[0] = temp;               
            }

            Console.WriteLine(string.Join(" ", array));

        }
    }
}
