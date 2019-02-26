using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.IO;
using Microsoft.Win32;
using System.Threading;
using System.ComponentModel;

namespace PolylineEditor
{

	public partial class MainWindow : Window
	{
		PointCollection polylinePoints;
		
		public MainWindow()
		{
			InitializeComponent();
			Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
			polylinePoints = new PointCollection();
			polyline.Points = polylinePoints;
		}

		private void savePolylineTo(string filepath)
		{
			string contents = polylinePoints.ToString();
			File.WriteAllText(filepath, contents);
		}

		private void loadPolylineFrom(string filepath)
		{
			string readContents;
			using (StreamReader streamReader = new StreamReader(filepath, Encoding.UTF8))
			{
				readContents = streamReader.ReadToEnd();
			}
			PointCollection points = PointCollection.Parse(readContents);
			polylinePoints = points;
			polyline.Points = polylinePoints;
		}

		private void btnOpenFile_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() == true)
			{
				loadPolylineFrom(openFileDialog.FileName);
			}
		}

		private bool doSave()
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			if (saveFileDialog.ShowDialog() == true)
			{
				savePolylineTo(saveFileDialog.FileName);
				return true;
			}
			return false;
		}

		private void btnSaveFile_Click(object sender, RoutedEventArgs e)
		{
			doSave();
		}

		private void btnClear_Click(object sender, RoutedEventArgs e)
		{
			polylinePoints.Clear();
		}

		private void btnUndo_Click(object sender, RoutedEventArgs e)
		{
			if (polylinePoints.Any())
			{
				polylinePoints.RemoveAt(polylinePoints.Count - 1);
			}
		}

		private void canvas_mouseClick(object sender, RoutedEventArgs e)
		{
			Point p = Mouse.GetPosition(canvas);
			polylinePoints.Add(p);
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			string messageBoxText = "Do you want to save changes to polyline before the application closes?";
			string caption = "Polyline editor";
			MessageBoxButton button = MessageBoxButton.YesNoCancel;
			MessageBoxImage icon = MessageBoxImage.Warning;
			
			MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

			// Process message box results
			switch (result)
			{
				case MessageBoxResult.Yes:
					if (!doSave()) OnClosing(e);
					break;
				case MessageBoxResult.No:
					break;
				case MessageBoxResult.Cancel:
					e.Cancel = true;
					break;
			}
		}
	}
}
