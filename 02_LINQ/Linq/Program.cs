using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Linq
{
  internal class Program
  {
    public static void Main(string[] args)
    {
      Contact polina = new Contact("Polina", "+380507193745");
      Contact ann = new Contact("Ann", "+380954553679");
      Contact anna = new Contact("Anna", "+380504553679");
      Contact krystyna = new Contact("Krystyna", "+380955311373");
      Contact dmytro = new Contact("Dmytro", "+380666396679");

      ContactBook book = new ContactBook();
      book.AddContact(polina);
      book.AddContact(ann);
      book.AddContact(anna);
      book.AddContact(krystyna);
      book.AddContact(dmytro);
      Console.WriteLine("Create contacts book: ");
      book.Print();
      Console.WriteLine("----------");
      
      book.Serialize(@"D:\Education\CurrEdu\dot-NET\Projects\02_LINQ\book.txt");
      ContactBook book1 = ContactBook.Deserialize(@"D:\Education\CurrEdu\dot-NET\Projects\02_LINQ\book.txt");
      Console.WriteLine("Serialize and deserialize contacts book: ");
      book1.Print();
      Console.WriteLine("----------");

      Console.WriteLine("Order contacts book by name: ");
      IEnumerable<Contact> res = book.OrderByName();
      foreach (var item in res)
      {
        item.Print();
      }
      Console.WriteLine("----------");

      Console.WriteLine("Order contacts book by number: ");
      res = book.OrderByNumber();
      foreach (var item in res)
      {
        item.Print();
      }
      Console.WriteLine("----------");

      Console.WriteLine("Order contacts book by name descending: ");
      res = book.OrderByNameDescending();
      foreach (var item in res)
      {
        item.Print();
      }
      Console.WriteLine("----------");

      Console.WriteLine("Order contacts book by number descending: ");
      res = book.OrderByNumberDescending();
      foreach (var item in res)
      {
        item.Print();
      }
      Console.WriteLine("----------");

      string name = "Polina";
      Console.WriteLine("Find by name " + name + ": ");
      res = book.FindByName(name);
      foreach (var item in res)
      {
        item.Print();
      }
      Console.WriteLine("----------");

      string number = "+380507193745";
      Console.WriteLine("Find by number " + number + ": ");
      res = book.FindByNumber(number);
      foreach (var item in res)
      {
        item.Print();
      }
      Console.WriteLine("----------");

      name = "A";
      Console.WriteLine("Find by name start " + name + ": ");
      res = book.FindByNameStart(name);
      foreach (var item in res)
      {
        item.Print();
      }
      Console.WriteLine("----------");

      number = "+38050";
      Console.WriteLine("Find by number start " + number + ": ");
      res = book.FindByNumberStart(number);
      foreach (var item in res)
      {
        item.Print();
      }
      Console.WriteLine("----------");

      name = "na";
      Console.WriteLine("Find by name end " + name + ": ");
      res = book.FindByNameEnd(name);
      foreach (var item in res)
      {
        item.Print();
      }
      Console.WriteLine("----------");

      number = "79";
      Console.WriteLine("Find by number end " + number + ": ");
      res = book.FindByNumberEnd(number);
      foreach (var item in res)
      {
        item.Print();
      }
      Console.WriteLine("----------");

      name = "Ann";
      Console.WriteLine("Find by name contains " + name + ": ");
      res = book.FindByNameContains(name);
      foreach (var item in res)
      {
        item.Print();
      }
      Console.WriteLine("----------");

      number = "55";
      Console.WriteLine("Find by number contains " + number + ": ");
      res = book.FindByNumberContains(number);
      foreach (var item in res)
      {
        item.Print();
      }
      Console.WriteLine("----------");

      Console.ReadKey();
    }
  }
}