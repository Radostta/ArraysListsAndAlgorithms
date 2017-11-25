using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine().Split();

            string input;

            while ((input = Console.ReadLine()) != "3:1")
            {
                var commandArgs = input.Split();

                switch (commandArgs[0])
                {
                    case "merge":
                        line = Merge(line, int.Parse(commandArgs[1]), int.Parse(commandArgs[2]));
                        break;

                    case "divide":
                        line = Divide(line, int.Parse(commandArgs[1]), int.Parse(commandArgs[2]));
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", line));
        }

        private static string[] Divide(string[] line, int index, int partitions)
        {
            string element = line[index];
            int partitionLength = element.Length / partitions;

            var divided = new string[partitions];

            for (int i = 0; element.Length > partitionLength; i++)
            {
                divided[i] = element.Substring(0, partitionLength);
                element = element.Substring(partitionLength);
            }

            divided[partitions - 1] += element;

            return line.Take(index).Concat(divided).Concat(line.Skip(index + 1)).ToArray();

        }
        
        private static string[] Merge(string[] line, int startIndex, int endIndex)
        {
            string merged = string.Empty;
            if (startIndex < 0) startIndex = 0;
            if (endIndex >= line.Length) endIndex = line.Length - 1;

            for (int i = startIndex; i <= endIndex; i++)
            {
                merged += line[i];
            }

            return line.Take(startIndex).Concat(new[] { merged }).Concat(line.Skip(endIndex + 1)).ToArray();
        }
    }
}
