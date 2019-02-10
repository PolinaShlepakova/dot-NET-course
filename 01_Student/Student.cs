using System;
using System.Collections.Generic;
using System.Linq;

namespace Student
{
    public class Student
    {
        public static readonly int MIN_GRADE = 0;
        public static readonly int MAX_GRADE = 100;
        
        private string _surname;
        private string _name;
        private string _patronymic;
        private Dictionary<string, int> _grades;

        private int _id;
        private static int LAST_ID = 0;
        
        public Student(string surname, string name, string patronymic, Dictionary<string, int> grades)
        {
            _id = LAST_ID++;
            _surname = surname;
            _name = name;
            _patronymic = patronymic;
            _grades = grades;
        }
        
        public Student(string surname, string name, string patronymic)
        {
            _id = LAST_ID++;
            _surname = surname;
            _name = name;
            _patronymic = patronymic;
            _grades = new Dictionary<string, int>();
        }

        public void SetGrade(string courseName, int grade)
        {
            if (grade < MIN_GRADE || grade > MAX_GRADE) 
            {
                // error, leave everything untouched
                return;
            }
            _grades.Add(courseName, grade);
        }

        public int GetGrade(string courseName)
        {
            if (!_grades.ContainsKey(courseName))
            {
                return -1;
            }

            return _grades[courseName];
        }

        public double GetAvgGrade()
        {
            return _grades.Values.Average();
        }

        public string GetName()
        {
            return _name;
        }

        public void SetName(string name)
        {
            _name = name;
        }
        
        public string GetSurname()
        {
            return _surname;
        }

        public void SetSurname(string surname)
        {
            _surname = surname;
        }
        
        public string GetPatronymic()
        {
            return _patronymic;
        }

        public void SetPatronymic(string patronymic)
        {
            _patronymic = patronymic;
        }

        public string GetFullName()
        {
            string res = "";
            res += GetSurname() + " " + GetName() + " " + GetPatronymic();
            return res;
        }

        public string GetFullID()
        {
            string res = "";
            res += "ID " + _id + " : ";
            res += GetFullName();
            return res;
        }

        public string GetFullInfo()
        {
            string res = "";
            res += GetFullID() + "\n";
            res += "Grades\n";
            res += "Average: " + GetAvgGrade() + "\n";
            foreach (var item in _grades)
            {
                res += item.Key + ": " + item.Value + "\n";
            }
            return res;
        }
    }
}