using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SoftUniKaraoke
{
    class SoftUniKaraoke
    {
        static void Main(string[] args)
        {
            var participantsInput = Console.ReadLine().Split(',').Select(x => x.Trim()).ToList();
            var songsInput = Console.ReadLine().Split(',').Select(x => x.Trim()).ToList();

            var result = new Dictionary<string, List<string>>();

            var line = Console.ReadLine();
            while (line != "dawn")
            {
                var performance = line.Split(',').Select(x => x.Trim()).ToList();

                var participant = performance[0];
                var song = performance[1];
                var award = performance[2];

                if (participantsInput.Contains(participant) && songsInput.Contains(song))
                {
                    if (!result.ContainsKey(participant))
                    {
                        result[participant] = new List<string>();
                    }

                    var awards = result[participant];
                    if (!awards.Contains(award))
                    {
                        awards.Add(award);
                    }
                }
                line = Console.ReadLine();
            }

            //Printing:
            
            if (result.Any())
            {
                foreach (var keyValuePair in result.OrderByDescending(p => p.Value.Count).ThenBy(n => n.Key))
                {
                    if (keyValuePair.Key.Any())
                    {
                        var participant = keyValuePair.Key;
                        var awards = keyValuePair.Value;

                        Console.WriteLine($"{participant}: {awards.Count} awards");
                        foreach (var award in awards.OrderBy(x => x))
                        {
                            Console.WriteLine($"--{award}");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("No awards");
            }
        }
    }
}
