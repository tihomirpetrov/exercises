namespace Problem02.Deciphering
{
    using System;
    using System.Linq;
    using System.Text;

    class Program
    {
        public static void Main()
        {
            string firstInput = Console.ReadLine();
            string[] secondInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            string firstSubstring = secondInput[0];
            string secondSubstring = secondInput[1];
            string output = string.Empty;

            for (int i = 0; i < firstInput.Length; i++)
            {
                if (!(firstInput[i] >= 100 && firstInput[i] <= 122 || firstInput[i] == 44 || firstInput[i] == 124 || firstInput[i] == 35))
                {
                    Console.WriteLine("This is not the book you are looking for.");
                    return;
                }               
            }

            for (int i = 0; i < firstInput.Length; i++)
            {
                output += ((char)(firstInput[i] - 3));
            }
            output = output.Replace(firstSubstring, secondSubstring);         

            Console.WriteLine(output);
        }
    }
}