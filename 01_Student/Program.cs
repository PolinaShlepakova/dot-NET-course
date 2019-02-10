using System;
using System.Collections.Generic;
using System.Linq;

namespace Student
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Student polina = new Student("Shlepakova", "Polina", "Dmytrivna");
            polina.SetGrade("Databases", 95);
            polina.SetGrade("C++", 100);
            polina.SetGrade("Discrete math", 100);
            polina.SetGrade("Algorithms and Data structures", 99);
            
            Student kyrylo = new Student("Vasylenko", "Kyrylo", "Anatolievich");
            kyrylo.SetGrade("Databases", 67);
            kyrylo.SetGrade("C++", 95);
            kyrylo.SetGrade("Discrete math", 100);
            kyrylo.SetGrade("Algorithms and Data structures", 100);
            
            Student ivan = new Student("Ivanenko", "Ivan", "Ivanovich");
            ivan.SetGrade("Java", 91);
            ivan.SetGrade("C#", 80);

            ivan.SetGrade("Discrete math", 93);
            ivan.SetGrade("Algorithms and Data structures", 93);
            
            Student petro = new Student("Petrenko", "Petro", "Petrovich");
            petro.SetGrade("Databases", 61);
            petro.SetGrade("C++", 63);
            petro.SetGrade("Discrete math", 74);
            petro.SetGrade("Javascript", 91);

            List<Student> students = new List<Student>()
            {
                polina, kyrylo, ivan, petro
            };
            students.Sort((s1, s2) => s2.GetAvgGrade().CompareTo(s1.GetAvgGrade()));

            foreach (var item in students)
            {
                Console.WriteLine(item.GetFullInfo());
            }
            
            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}