namespace Problem03.PostOffice
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string[] tokens = input.Split('|').ToArray();

            string firstPart = tokens[0];
            string secondPart = tokens[1];
            string thirdPart = tokens[2];

            StringBuilder sb = new StringBuilder();
            string pattern = $@"([#$%\*&])[A-Z]+\1";
            MatchCollection matchSentences = Regex.Matches(firstPart, pattern);
            foreach (Match item in matchSentences)
            {
                sb.Append(item);
            }

            pattern = $@"[0-9][0-9]:[0-9][0-9]";
            MatchCollection matchSentences1 = Regex.Matches(secondPart, pattern);

            List<int> list = new List<int>();
            for (int i = 1; i < sb.Length - 1; i++)
            {
                foreach (Match item in matchSentences1)
                {
                    string sentence = item.Value.Trim();
                    int[] part = sentence.Split(':').Select(int.Parse).ToArray();

                    if (sb[i] == part[0])
                    {
                        list.Add(part[0]);
                        list.Add(part[1]);
                    }
                }
            }

            List<string> words = thirdPart.Split(' ').ToList();
            for (int i = 0; i < list.Count; i += 2)
            {
                for (int j = 0; j < words.Count; j++)
                {
                    if ((char)list[i] == words[j][0] && list[i + 1] == words[j].Length - 1)
                    {
                        Console.WriteLine(words[j]);
                        words.RemoveAt(j);
                        j--;
                    }
                }
            }
        }
    }
}