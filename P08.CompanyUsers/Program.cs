namespace P08.CompanyUsers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        public static void Main()
        {
            string command = Console.ReadLine();
            Dictionary<string, List<string>> companyEmployee = new Dictionary<string, List<string>>();

            while (command != "End")
            {
                string[] tokens = command.Split(" -> ").ToArray();
                string companyName = tokens[0];
                string employeeId = tokens[1];

                if (!companyEmployee.ContainsKey(companyName))
                {
                    companyEmployee.Add(companyName, new List<string>());
                }
                if (!companyEmployee[companyName].Contains(employeeId))
                {
                    companyEmployee[companyName].Add(employeeId);
                }

                command = Console.ReadLine();
            }

            foreach (var employee in companyEmployee.OrderBy(x=>x.Key))
            {
                Console.WriteLine(employee.Key);
                foreach (var item in employee.Value)
                {
                    Console.WriteLine($"-- {item}");
                }
            }
        }
    }
}