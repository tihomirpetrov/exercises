namespace P03.LegendaryFarming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        public static void Main()
        {
            Dictionary<string, int> materialsQuantity = new Dictionary<string, int>();
            Dictionary<string, int> junk = new Dictionary<string, int>();
            materialsQuantity.Add("shards", 0);
            materialsQuantity.Add("fragments", 0);
            materialsQuantity.Add("motes", 0);

            string input = Console.ReadLine();

            while (true)
            {
                string[] tokens = input.Split().ToArray();

                for (int i = 0; i < tokens.Length; i += 2)
                {
                    int quantity = int.Parse(tokens[i]);
                    string material = tokens[i + 1].ToLower();

                    if (material == "shards" || material == "fragments" || material == "motes")
                    {
                        materialsQuantity[material] += quantity;
                        if (materialsQuantity[material] >= 250 && material == "shards")
                        {
                            Console.WriteLine("Shadowmourne obtained!");
                            materialsQuantity[material] -= 250;
                            foreach (var item in materialsQuantity.OrderByDescending(x =>x.Value).ThenBy(x=>x.Key))
                            {
                                Console.WriteLine($"{item.Key}: {item.Value}");
                            }
                            foreach (var item in junk.OrderBy(x => x.Key))
                            {
                                Console.WriteLine($"{item.Key}: {item.Value}");
                            }
                            return;
                        }

                        else if (materialsQuantity[material] >= 250 && material == "fragments")
                        {
                            Console.WriteLine("Valanyr obtained!");
                            materialsQuantity[material] -= 250;
                            foreach (var item in materialsQuantity.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                            {
                                Console.WriteLine($"{item.Key}: {item.Value}");
                            }
                            foreach (var item in junk.OrderBy(x => x.Key))
                            {
                                Console.WriteLine($"{item.Key}: {item.Value}");
                            }
                            return;
                        }

                        else if (materialsQuantity[material] >= 250 && material == "motes")
                        {
                            Console.WriteLine("Dragonwrath obtained!");
                            materialsQuantity[material] -= 250;
                            foreach (var item in materialsQuantity.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                            {
                                Console.WriteLine($"{item.Key}: {item.Value}");
                            }
                            foreach (var item in junk.OrderBy(x =>x.Key))
                            {
                                Console.WriteLine($"{item.Key}: {item.Value}");
                            }
                            return;
                        }
                    }
                    else
                    {
                        if (!junk.ContainsKey(material))
                        {
                            junk.Add(material, 0);
                        }
                        junk[material] += quantity;
                    }
                }
                input = Console.ReadLine();
            }
        }
    }
}