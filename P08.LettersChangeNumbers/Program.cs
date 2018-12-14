namespace P08.LettersChangeNumbers
{
    using System;
    using System.Linq;

    class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            char[] chars = input.ToCharArray();
            string numberStr = string.Empty;
            int number = 0;

            for (int i = 0; i < input.Length; i++)
            {
                int firstLetter = input[i];
                int lastLetter = input[i].ToString().Length - 1;

                if (firstLetter >= 65 && firstLetter <= 90)
                {
                    int divide = firstLetter - 64;
                }
                if (firstLetter >= 97 && firstLetter <= 122)
                {
                    int multiply = firstLetter - 97;
                }
                for (int j = 1; j < input[i].ToString().Length - 1; j++)
                {
                    numberStr += input[i + 1];
                }
                number = int.Parse(numberStr);
            }
        }
    }
}
