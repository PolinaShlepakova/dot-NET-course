using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Win32;

namespace WpfApp1
{
	[Serializable]
	public class Book {
		public string Name { get; set; }
		public string Author { get; set; }
		public int Year { get; set; }
		public Book(string name, string author, int year)
		{
			Name = name;
			Author = author;
			Year = year;
		}
	}

	[Serializable]
	public class BooksCollection
	{
		public List<Book> Books;

		public BooksCollection()
		{
			Books = new List<Book>();
		}

		public void Serialize(string filename)
		{
			IFormatter formatter = new BinaryFormatter();
			Stream stream = new FileStream(filename, FileMode.Create, FileAccess.Write);
			formatter.Serialize(stream, this);
			stream.Close();
		}

		public static BooksCollection Deserialize(string filename)
		{
			IFormatter formatter = new BinaryFormatter();
			Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read);
			return (BooksCollection) formatter.Deserialize(stream);
		}
	}

	public partial class MainWindow : Window
	{
		//private List<Book> loadData()
		//{
		//	return new List<Book>()
		//	{
		//		new Book("Fahrenheit 451", "Ray Bradbury", 1953),
		//		new Book("Dandelion Wine", "Ray Bradbury", 1957),
		//		new Book("Moby-Dick", "Herman Melville", 1851),
		//		new Book("Pride and Prejudice", "Jane Austen", 1813),
		//		new Book("Pollyanna", "Eleanor H. Porter", 1913)
		//	};
		//}

		public MainWindow()
		{
			InitializeComponent();
			//BooksCollection bc = new BooksCollection();
			//bc.Books = loadData();
			//bc.Serialize(@"D:\Education\CurrEdu\dot-NET\Projects\03_Grid\GridVS\WpfApp1\WpfApp1\Files\output.txt");
		}

		private List<Book> loadDataFrom(string filename)
		{
			return BooksCollection.Deserialize(filename).Books;
		}

		private void loadDataTo(string filename)
		{
			BooksCollection bc = new BooksCollection();
			bc.Books = (List<Book>) BookGrid.ItemsSource;
			bc.Serialize(filename);
		}

		private void btnOpenFile_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() == true) {
				//string filename = openFileDialog.FileName;
				fillGrid(loadDataFrom(openFileDialog.FileName));
			}
		}

		private void btnSaveFile_Click(object sender, RoutedEventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			if (saveFileDialog.ShowDialog() == true)
			{
				loadDataTo(saveFileDialog.FileName);
			}
		}

		private void fillGrid(List<Book> list)
		{
			BookGrid.ItemsSource = list;
		}
	}
}
