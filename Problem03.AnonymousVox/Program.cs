namespace Problem03.AnonymousVox
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string[] change = Console.ReadLine().Split(new char[] {'{', '}'}, StringSplitOptions.RemoveEmptyEntries);

            string pattern = @"([A-Za-z]+)(.+)\1";
            
            MatchCollection match = Regex.Matches(input, pattern);

            int counter = 0;
            foreach (Match item in match)
            {
                if (counter >= change.Length)
                {
                    break;
                }
                int index = input.IndexOf(item.Groups[2].Value);
                int length = item.Groups[2].Value.Length;
                input = input.Replace(item.Groups[2].Value, change[counter]);
                counter++;
            }
            Console.WriteLine(input);
        }
    }
}