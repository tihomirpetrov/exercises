namespace P02.FinalExam
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string patternArtist = "(?<=[A-Z])([a-z' ]*)";
            string patternSong = "([A-Z ]+)";

            while (input != "end")
            {
                string[] tokens = input.Split(':').ToArray();

                Match matchArtist = Regex.Match(tokens[0], patternArtist);

                if (matchArtist.Success)
                {
                    int key = matchArtist.Length;
                    string artist = string.Empty;
                    for (int i = 0; i < matchArtist.Length; i++)
                    {
                        artist += matchArtist.ToString() + key;
                    }
                }

                Match matchSong = Regex.Match(tokens[1], patternSong);

                if (matchSong.Success)
                {


                }

                input = Console.ReadLine();
            }

        }
    }
}