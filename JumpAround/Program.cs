using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpAround
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var jumpIndex = 0;
            //var sum = numbers[0];     
            var sum = 0;

            while (true)
            {
                sum += numbers[jumpIndex];

                if ((jumpIndex + numbers[jumpIndex]) < numbers.Length)
                {
                    jumpIndex += numbers[jumpIndex];   
                    //sum += numbers[jumpIndex];                
                }
                else if ((jumpIndex - numbers[jumpIndex]) >= 0)
                {
                    jumpIndex -= numbers[jumpIndex];   
                    //sum += numbers[jumpIndex];
                }
                else
                {                    
                    break;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
