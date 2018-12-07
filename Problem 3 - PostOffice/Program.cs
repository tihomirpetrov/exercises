namespace Problem03.PostOffice
{
    using System;
    using System.Linq;
    using System.Text;

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

            for (int i = 0; i < firstPart.Length; i++)
            {
                if (firstPart[i] == '#' || firstPart[i] == '$' || firstPart[i] == '%' || firstPart[i] == '*' || firstPart[i] == '&')
                {
                    char symbol = firstPart[i];
                    for (int j = i + 1; j < firstPart.Length; j++)
                    {

                        if (!((char)j == symbol))
                        {
                            if (firstPart[j] == symbol)
                            {
                                break;
                            }
                            else
                            {
                               sb.Append(firstPart[j]);
                            }
                        }                        
                    }
                }
            }

            for (int i = 0; i < secondPart.Length; i++)
            {
                if (secondPart[i] == )
                {

                }
            }

            Console.WriteLine(sb);
        }
    }
}