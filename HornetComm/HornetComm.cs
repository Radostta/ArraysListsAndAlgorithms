using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HornetComm
{
    class HornetComm
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
        
            string messagePattern = @"^([0-9]+) <-> ([A-Za-z0-9]+)$";
            string broadcastPattern = @"^([^0-9]+) <-> ([A-Za-z0-9]+)$";

            var broadcasts = new List<string>();
            var messages = new List<string>();

            while (input != "Hornet is Green")
            {
                var messageMatch = Regex.Match(input, messagePattern);
                var broadcastMatch = Regex.Match(input, broadcastPattern);
                
                if (messageMatch.Success)
                {
                    var recipient = messageMatch.Groups[1].ToString();
                    var message = messageMatch.Groups[2].ToString();

                    recipient = ReverseString(recipient);
                                       
                        messages.Add($"{recipient} -> {message}");                    
                    
                }
                else if (broadcastMatch.Success)
                {
                    var message = broadcastMatch.Groups[1].ToString();
                    var frequency = broadcastMatch.Groups[2].ToString();

                    frequency = ExchangeLowerAndUpper(frequency);
                    
                        broadcasts.Add($"{frequency} -> {message}");                                        
                }
                
                input = Console.ReadLine();
            }

            Console.WriteLine("Broadcasts:");
            if (broadcasts.Count == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                Console.WriteLine(string.Join(Environment.NewLine, broadcasts));
            }

            Console.WriteLine("Messages:");

            if (messages.Count == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                Console.WriteLine(string.Join(Environment.NewLine, messages));
            }
        }

        static string ReverseString(string input)
        {
            char[] inputArr = input.ToCharArray();
            inputArr = inputArr.Reverse().ToArray();
          
            return new string(inputArr);
        }

        static string ExchangeLowerAndUpper(string input)
        {
            char[] inputArr = input.ToCharArray();
            for (int i = 0; i < inputArr.Length; i++)
            {
                if (char.IsLetter(inputArr[i]))
                {
                    if (char.IsLower(inputArr[i]))
                    {
                        inputArr[i] = char.ToUpper(inputArr[i]);
                    }
                    else if (char.IsUpper(inputArr[i]))
                    {
                        inputArr[i] = char.ToLower(inputArr[i]);
                    }
                }                
                else
                {
                    inputArr[i] = inputArr[i];
                }
            }
            return new string(inputArr);
        }
    }
}
