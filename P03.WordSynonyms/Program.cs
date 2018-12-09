namespace P03.WordSynonyms
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        public static void Main()
        {
            int numbers = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> wordSynonyms = new Dictionary<string, List<string>>();

            for (int i = 0; i < numbers; i++)
            {
                string word = Console.ReadLine(); 
                string synonym = Console.ReadLine();
                if (!wordSynonyms.ContainsKey(word))
                {
                    wordSynonyms.Add(word, new List<string>());                    
                }
                wordSynonyms[word].Add(synonym);
            }

            foreach (var item in wordSynonyms)
            {
                Console.Write($"{item.Key} - ");
                Console.WriteLine(string.Join(", ", item.Value));
            }
        }
    }
}