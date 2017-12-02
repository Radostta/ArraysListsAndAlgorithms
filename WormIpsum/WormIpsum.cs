using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WormIpsum
{
    class WormIpsum
    {
        static void Main(string[] args)
        {
            var sentenceRegex = new Regex(@"^[A-Z][^\.]*\.$");
            var wordsRegex = new Regex(@"[^\s,\.]+");

            var sentence = Console.ReadLine();

            while (sentence != "Worm Ipsum")
            {
                var sentenceMatch = sentenceRegex.Match(sentence);

                if (sentenceMatch.Success)
                {
                    var wordMatches = wordsRegex.Matches(sentence);

                    foreach (Match word in wordMatches)
                    {
                        var currentWord = word.Value;

                        if (currentWord.Length != currentWord.Distinct().Count())
                        {
                            var symbol = currentWord.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;
                            //var newWord = string.Concat(Enumerable.Repeat(symbol, currentWord.Length));
                            var newWord = new string(symbol, currentWord.Length);

                            sentence = Regex.Replace(sentence, currentWord, newWord);
                        }
                    }

                    Console.WriteLine(sentence);
                }

                sentence = Console.ReadLine();
            }
        }
    }
}
