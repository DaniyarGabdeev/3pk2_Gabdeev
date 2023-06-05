using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;

namespace Tekst
{
    public partial class CImage : Window
    {
        public CImage()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

            FileStream saveNote = File.Open($"{tb1.Text}.gif", FileMode.OpenOrCreate);
            inkCanvas.Strokes.Save(saveNote);
            saveNote.Close();
            MessageBox.Show("Рисунок сохранен!");
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            FileStream fs = File.Open($"{tb1.Text}.gif", FileMode.Open);
            StrokeCollection myStrk = new StrokeCollection(fs);
            inkCanvas.Strokes = myStrk;
            fs.Close();
        }
    }
}
