using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P03.TreasureFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sequence = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string command = Console.ReadLine();
            string decryptedCharLine = string.Empty;
            StringBuilder sb = new StringBuilder();
            List<string> lines = new List<string>();

            while (command != "find")
            {
                char[] tokens = command.ToCharArray();

                for (int i = 0; i < tokens.Length; i++)
                {
                    sb.Append(tokens[i] - (sequence[i]));
                    //decryptedCharLine += (char.Parse(tokens[i])) - sequence[i];

                }


                command = Console.ReadLine();
            }
            Console.WriteLine(sb);
        }
    }
}
