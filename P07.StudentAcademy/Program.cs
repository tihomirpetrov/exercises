namespace P07.StudentAcademy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> studentGrades = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string studentName = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!studentGrades.ContainsKey(studentName))
                {
                    studentGrades.Add(studentName, new List<double>());
                }
                studentGrades[studentName].Add(grade);
            }
            Dictionary<string, double> studentAverageGrade = new Dictionary<string, double>();

            foreach (var student in studentGrades)
            {
                var averageGrade = student.Value.Average();
                if (averageGrade >= 4.50)
                {
                    studentAverageGrade.Add(student.Key, averageGrade);
                }
            }

            foreach (var item in studentAverageGrade.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{item.Key} -> {item.Value:f2}");
            }
        }
    }
}