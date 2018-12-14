namespace Problem04.AnonymousCache
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Dictionary<string, Dictionary<string, long>> dataSetDataKeyDataSize = new Dictionary<string, Dictionary<string, long>>();

            while (input != "thetinggoesskrra")
            {
                string[] tokens = input.Split().ToArray();

                if (tokens.Length == 1)
                {
                    string dataSet = tokens[0];
                    if (!dataSetDataKeyDataSize.ContainsKey(dataSet))
                    {
                        dataSetDataKeyDataSize.Add(dataSet, new Dictionary<string, long>());
                    }
                }
                else
                {
                    tokens = input.Split(new char[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string dataKey = tokens[0].Trim();
                    string temp = tokens[1];
                    string[] tokens2 = temp.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    long dataSize = long.Parse(tokens2[0].Trim());
                    string dataSet = tokens2[1].Trim();

                    if (!dataSetDataKeyDataSize.ContainsKey(dataSet))
                    {
                        dataSetDataKeyDataSize.Add(dataSet, new Dictionary<string, long>());
                    }
                    if (!dataSetDataKeyDataSize[dataSet].ContainsKey(dataKey))
                    {
                        dataSetDataKeyDataSize[dataSet].Add(dataKey, 0);
                    }
                    dataSetDataKeyDataSize[dataSet][dataKey] += dataSize;
                }

                input = Console.ReadLine();
            }

            //var maxData = dataSetDataKeyDataSize.Keys.Select(x=>x);
            //var maxData = dataSetDataKeyDataSize.Select(x => x.Value.Values.Sum());

            //foreach (var item in maxData)
            //{
            //    Console.WriteLine($"Data Set: {item}");
            //}

            foreach (var item in dataSetDataKeyDataSize.OrderByDescending(x => x.Value.Values.Sum()))
            {
                Console.WriteLine($"Data Set: {item.Key}, Total Size: {item.Value.Values.Sum()}");

                foreach (var data in item.Value)
                {
                    Console.WriteLine($"$.{data.Key}");
                }
                break;
            }
        }
    }
}