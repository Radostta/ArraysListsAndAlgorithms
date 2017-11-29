using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entertrain
{
    class Entertrain
    {
        static void Main(string[] args)
        {
            int locomotivePower = int.Parse(Console.ReadLine());
            var trainSequence = new List<int>();

            double sum = 0;
            double average = 0;

            string input = Console.ReadLine();

            while (input != "All ofboard!")
            {
                trainSequence.Add(int.Parse(input));
                sum = trainSequence.Sum();

                if (sum > locomotivePower)
                {
                    average = trainSequence.Average();
                    double minDifference = average;
                    int closestElement = 0;

                    for (int i = 0; i < trainSequence.Count; i++)
                    {
                        double currentDifference = Math.Abs(average - trainSequence[i]);

                        if (currentDifference < minDifference )
                        {
                            minDifference = currentDifference;
                            closestElement = trainSequence[i];
                        }                        
                    }

                    int closestElementIndex = trainSequence.IndexOf(closestElement);
                    trainSequence.RemoveAt(closestElementIndex);                    
                }

                input = Console.ReadLine();
            }

            trainSequence.Reverse();
            trainSequence.Add(locomotivePower);

            Console.WriteLine(string.Join(" ", trainSequence));
            
        }
    }
}
