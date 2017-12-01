using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SpyGram
{
    class SpyGram
    {
        static void Main(string[] args)
        {
            string privateKey = Console.ReadLine();
            var messages = new Dictionary<string, List<string>>();
            int index = 0;

            Regex regex = new Regex(@"^TO:\s([A-Z]+);\sMESSAGE:\s(.+);$");
            string input = Console.ReadLine();

            while (input != "END")
            {
                if (regex.IsMatch(input))
                {
                    Match match = regex.Match(input);
                    string recipient = match.Groups[1].ToString();

                    if (!messages.ContainsKey(recipient))
                    {
                        messages.Add(recipient, new List<string>());
                    }

                    string convertedMessage = "";

                    for (int i = 0; i < match.Length; i++)
                    {
                        if (index > privateKey.Length - 1)
                        {
                            index = 0;
                        }

                        var x = int.Parse(privateKey[index].ToString());
                        char letter = (char)(match.ToString()[i] + x);
                        convertedMessage += letter;
                        index++;
                    }

                    index = 0;

                    messages[recipient].Add(convertedMessage);
                }

                input = Console.ReadLine();
            }

            //Print:

            foreach (var recipient in messages.OrderBy(x => x.Key))
            {
                foreach (var message in recipient.Value)
                {
                    Console.WriteLine(message);
                }
            }  
            
        }
    }
}
