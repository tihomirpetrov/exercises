namespace Problem01.Dictionary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        public static void Main()
        {
            string firstInput = Console.ReadLine();
            string secondInput = Console.ReadLine();
            string thirdInput = Console.ReadLine();
            Dictionary<string, List<string>> wordDefinitions = new Dictionary<string, List<string>>();

            string[] tokensFromFirstInput = firstInput.Split(" | ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            for (int i = 0; i < tokensFromFirstInput.Length; i++)
            {
                string temp = tokensFromFirstInput[i];
                string[] wordsDefinitions = temp.Split(": ").ToArray();
                string word = wordsDefinitions[0];
                string definition = wordsDefinitions[1];

                if (!wordDefinitions.ContainsKey(word))
                {
                    wordDefinitions.Add(word, new List<string>());
                }
                wordDefinitions[word].Add(definition);
            }

            string[] tokensFromSecondInput = secondInput.Split(" | ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            if (thirdInput == "List")
            {
                foreach (var item in wordDefinitions.OrderBy(x => x.Key))
                {
                    Console.Write(item.Key + " ");
                }
                Console.WriteLine();
            }

            if (thirdInput == "End")
            {
                for (int i = 0; i < tokensFromSecondInput.Length; i++)
                {
                    string word = tokensFromSecondInput[i];

                    if (wordDefinitions.ContainsKey(word))
                    {
                        Console.WriteLine($"{word}");

                        foreach (var item in wordDefinitions[word].OrderByDescending(x=>x.Length))
                        {
                            Console.WriteLine($" -{item}");
                        }
                    }
                }
            }
        }
    }
}