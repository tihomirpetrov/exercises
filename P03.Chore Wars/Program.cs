namespace P03.ChoreWars
{
    using System;
    using System.Text.RegularExpressions;

    class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string patternDishes = @"(?<=<)[a-z0-9]+(?=>)";
            string patternCleaning = @"(?<=\[)[A-Z0-9]+(?=\])";
            string patternLaundry = @"(?<=\{)[\S]+(?=\})";

            int sumDishes = 0;
            int sumCleaning = 0;
            int sumLaundry = 0;

            while (input != "wife is happy")
            {
                Match matchDishes = Regex.Match(input, patternDishes);
                if (matchDishes.Success)
                {
                    string word = matchDishes.ToString();
                    for (int i = 0; i < matchDishes.Length; i++)
                    {
                        if (char.IsDigit(word[i]))
                        {
                            sumDishes += (int)(word[i] - 48);
                        }
                    }                    
                }

                Match matchCleaning = Regex.Match(input, patternCleaning);
                if (matchCleaning.Success)
                {
                    string word = matchCleaning.ToString();
                    for (int i = 0; i < matchCleaning.Length; i++)
                    {
                        if (char.IsDigit(word[i]))
                        {
                            sumCleaning += (int)(word[i] - 48);
                        }
                    }
                }

                Match matchLaundry = Regex.Match(input, patternLaundry);
                if (matchLaundry.Success)
                {
                    string word = matchLaundry.ToString();
                    for (int i = 0; i < matchLaundry.Length; i++)
                    {
                        if (char.IsDigit(word[i]))
                        {
                            sumLaundry += (int)(word[i] - 48);
                        }
                    }
                }
                input = Console.ReadLine();
            }

            int totalTime = sumDishes + sumCleaning + sumLaundry;
            Console.WriteLine($"Doing the dishes - {sumDishes} min.");
            Console.WriteLine($"Cleaning the house - {sumCleaning} min.");
            Console.WriteLine($"Doing the laundry - {sumLaundry} min.");
            Console.WriteLine($"Total - {totalTime} min.");
        }
    }
}