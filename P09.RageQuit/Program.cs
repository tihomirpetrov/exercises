namespace P09.RageQuit
{
    using System;
    using System.Text;

    class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine().ToUpper();
            string toAdd = string.Empty;
            StringBuilder sb = new StringBuilder();
            int repeat = 1;
            int counter = 0;
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i + 1] >= 48 && input[i + 1] <= 57)
                {
                    repeat = input[i + 1] - 48;
                }
                if (input[i] >= 65 && input[i] <= 90)
                {
                    toAdd += (input[i]).ToString();

                }
                for (int k = 0; k < toAdd.Length; k++)
                {
                    sb.Append(toAdd[k], repeat);
                }
                if (repeat > 0)
                {
                    counter++;
                    repeat--;
                }
            }
            Console.WriteLine($"Unique symbols used: {counter}");
            Console.WriteLine(sb);
        }
    }
}