namespace Problem03.StarEnigma
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> attackedPlanets = new Dictionary<string, int>();
            Dictionary<string, int> destroyedPlanets = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                int counter = 0;
                List<int> orderCheck = new List<int>();
                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j] == 's' || input[j] == 'S' || input[j] == 't' || input[j] == 'T' || input[j] == 'a' || input[j] == 'A' || input[j] == 'r' || input[j] == 'R')
                    {
                        counter++;
                    }
                }
                StringBuilder sb = new StringBuilder();

                for (int k = 0; k < input.Length; k++)
                {
                    sb.Append((char)(input[k] - counter));
                }

                StringBuilder planetName = new StringBuilder();
                StringBuilder population = new StringBuilder();
                string attackType = string.Empty;
                StringBuilder soldierCount = new StringBuilder();

                for (int j = 0; j < sb.Length; j++)
                {
                    if (sb[j] == '@')
                    {
                        int count = 0;
                        for (int k = j + 1; k < sb.Length; k++)
                        {
                            if (count == 0 && sb[k] >= 65 && sb[k] <= 90)
                            {
                                planetName.Append(sb[k]);
                            }
                            else if (count > 0 && sb[k] >= 97 && sb[k] <= 122)
                            {
                                planetName.Append(sb[k]);
                            }
                            else
                            {
                                orderCheck.Add(0);
                                break;
                            }
                            count++;
                        }
                    }
                    else if (sb[j] == ':')
                    {
                        for (int k = j + 1; k < sb.Length; k++)
                        {
                            if (sb[k] >= 48 && sb[k] <= 57)
                            {
                                population.Append(sb[k]);
                            }
                            else
                            {
                                orderCheck.Add(1);
                                break;
                            }
                        }
                    }
                    else if (sb[j] == '!' && sb[j + 2] == '!' && (sb[j+1] == 'A' || sb[j+1] == 'D') && j < input.Length - 2)
                    {
                        attackType = sb[j + 1].ToString();
                        orderCheck.Add(2);
                    }
                    else if (sb[j] == '-' && sb[j + 1] == '>' && j < input.Length - 1)
                    {
                        for (int k = j + 2; k < sb.Length; k++)
                        {
                            if (sb[k] >= 48 && sb[k] <= 57)
                            {
                                soldierCount.Append(sb[k]);
                            }
                            else if (j == sb.Length - 1)
                            {
                                orderCheck.Add(3);
                            }
                            else
                            {
                                orderCheck.Add(3);
                                break;
                            }
                        }
                    }
                }
                bool isValid = true;
                for (int k = 0; k < orderCheck.Count; k++)
                {
                    if (orderCheck[k] != k)
                    {
                        isValid = false;
                    }
                }
                if (attackType == "A" && soldierCount.Length > 0 && population.Length > 0 && isValid)
                {
                    attackedPlanets.Add(planetName.ToString(), int.Parse(population.ToString()));
                }
                else if (attackType == "D" && soldierCount.Length > 0 && population.Length > 0 && isValid)
                {
                    destroyedPlanets.Add(planetName.ToString(), int.Parse(population.ToString()));
                }
            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            foreach (var item in attackedPlanets.OrderBy(x => x.Key))
            {
                Console.WriteLine($"-> {item.Key}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            foreach (var item in destroyedPlanets.OrderBy(x => x.Key))
            {
                Console.WriteLine($"-> {item.Key}");
            }
        }
    }
}