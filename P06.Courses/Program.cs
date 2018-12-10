namespace P06.Courses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        public static void Main()
        {
            string command = Console.ReadLine();
            Dictionary<string, List<string>> courseStudent = new Dictionary<string, List<string>>();

            while (command != "end")
            {
                string[] tokens = command.Split(" : ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string courseName = tokens[0];
                string student = tokens[1];

                if (!courseStudent.ContainsKey(courseName))
                {
                    courseStudent.Add(courseName, new List<string>());
                }
                courseStudent[courseName].Add(student);

                command = Console.ReadLine();
            }

            foreach (var course in courseStudent.OrderByDescending(x =>x.Value.Count))
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");
                var kvp = course.Value;
                foreach (var student in kvp.OrderBy(x =>x))
                {
                    Console.WriteLine($"-- {student}");                    
                }
            }
        }
    }
}