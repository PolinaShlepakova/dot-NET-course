using System;

namespace Linq
{
    [Serializable]
    public class Contact
    {
        private string _name;
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        
        private string _number;
        public string Number
        {
            get => _number;
            set => _number = value;
        }

        public Contact(string name, string number)
        {
            Name = name;
            Number = number;
        }

        public void Print()
        {
            Console.WriteLine(Name + " : " + Number);
        }
        
    }
}