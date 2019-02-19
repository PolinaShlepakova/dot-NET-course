using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Linq
{
	[Serializable]
	public class ContactBook
	{
		private List<Contact> _contacts;

		public ContactBook()
		{
			_contacts = new List<Contact>();
		}

		public void AddContact(Contact contact) 
		{
			_contacts.Add(contact);
		}

		public void Serialize(string filename)
		{
			IFormatter formatter = new BinaryFormatter();
			Stream stream = new FileStream(filename, FileMode.Create, FileAccess.Write);

			formatter.Serialize(stream, this);
			stream.Close();
		}

		public static ContactBook Deserialize(string filename)
		{
			IFormatter formatter = new BinaryFormatter();
			Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read);
			return (ContactBook) formatter.Deserialize(stream);
		}

		public void Print()
		{
			foreach (var item in _contacts)
			{
				item.Print();
			}
		}

		public IEnumerable<Contact> OrderByName()
		{
			return _contacts.OrderBy(contact => contact.Name).ThenBy(contact => contact.Number);
		}

		public IEnumerable<Contact> OrderByNumber()
		{
			return _contacts.OrderBy(contact => contact.Number).ThenBy(contact => contact.Name);
		}

		public IEnumerable<Contact> OrderByNameDescending()
		{
			return _contacts.OrderByDescending(contact => contact.Name).ThenByDescending(contact => contact.Number);
		}

		public IEnumerable<Contact> OrderByNumberDescending()
		{
			return _contacts.OrderByDescending(contact => contact.Number).ThenByDescending(contact => contact.Name);
		}
		
		public IEnumerable<Contact> FindByName(string name)
		{
			return _contacts.Where(contact => contact.Name.Equals(name));
		}
		
		public IEnumerable<Contact> FindByNumber(string number)
		{
			return _contacts.Where(contact => contact.Number.Equals(number));
		}
		
		public IEnumerable<Contact> FindByNameStart(string nameStart)
		{
			return _contacts.Where(contact => contact.Name.StartsWith(nameStart));
		}
		
		public IEnumerable<Contact> FindByNumberStart(string numberStart)
		{
			return _contacts.Where(contact => contact.Number.StartsWith(numberStart));
		}
		
		public IEnumerable<Contact> FindByNameEnd(string nameEnd)
		{
			return _contacts.Where(contact => contact.Name.EndsWith(nameEnd));
		}
		
		public IEnumerable<Contact> FindByNumberEnd(string numberEnd)
		{
			return _contacts.Where(contact => contact.Number.EndsWith(numberEnd));
		}
		
		public IEnumerable<Contact> FindByNameContains(string nameContains)
		{
			return _contacts.Where(contact => contact.Name.Contains(nameContains));
		}
		
		public IEnumerable<Contact> FindByNumberContains(string numberContains)
		{
			return _contacts.Where(contact => contact.Number.Contains(numberContains));
		}
	}
	
}