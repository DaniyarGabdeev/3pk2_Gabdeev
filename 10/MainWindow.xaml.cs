using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Threading;

namespace _10
{
    public partial class MainWindow : Window
    {
        private bool _isBold;
        private bool _isItalic;
        private bool _isUnderline;
        private DispatcherTimer _timer;
        private int _undoIndex;
        private string[] _undoList = new string[5];

        public MainWindow()
        {
            InitializeComponent();

            // инициализация размеров шрифта
            for (int i = 8; i <= 72; i += 2)
            {
                FontSizeComboBox.Items.Add(i);
            }
            FontSizeComboBox.SelectedIndex = 2; // размер по умолчанию

            // инициализация сохранителя
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(5);
            _timer.Tick += Timer_Tick;
        }

        // обработчики событий
        private void FontSizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainTextBox.FontSize = (int)FontSizeComboBox.SelectedItem;
        }

        private void BoldButton_Click(object sender, RoutedEventArgs e)
        {
            _isBold = !_isBold;
            BoldButton.IsChecked = _isBold;
            MainTextBox.FontWeight = (_isBold && _isItalic) ? FontWeights.Bold : FontWeights.Normal;
            CreateUndoSnapshot(); // создание снимка для undo
        }

        private void ItalicButton_Click(object sender, RoutedEventArgs e)
        {
            _isItalic = !_isItalic;
            ItalicButton.IsChecked = _isItalic;
            MainTextBox.FontStyle = _isItalic ? FontStyles.Italic : FontStyles.Normal;
            MainTextBox.FontWeight = (_isBold && _isItalic) ? FontWeights.Bold : FontWeights.Normal;
            CreateUndoSnapshot(); // создание снимка для undo
        }

        private void UnderlineButton_Click(object sender, RoutedEventArgs e)
        {
            _isUnderline = !_isUnderline;
            UnderlineButton.IsChecked = _isUnderline;
            MainTextBox.TextDecorations = _isUnderline ? TextDecorations.Underline : null;
            CreateUndoSnapshot(); // создание снимка для undo
        }

        private void MainTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CreateUndoSnapshot(); // создание снимка для undo
        }

        private void UndoButton_Click(object sender, RoutedEventArgs e)
        {
            // загрузка последнего снимка
            if (_undoIndex > 0 && _undoList[_undoIndex - 1] != null)
            {
                _undoIndex--;
                MainTextBox.Text = _undoList[_undoIndex];
                MainTextBox.Select(MainTextBox.Text.Length, 0);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // сохранение в файл
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                File.WriteAllText(dlg.FileName, MainTextBox.Text);
                MessageBox.Show("File saved.");
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // сохранение снимка
            CreateUndoSnapshot();
        }

        // вспомогательные методы
        private void CreateUndoSnapshot()
        {
            // запись текущего состояния в список снимков
            _undoList[_undoIndex] = MainTextBox.Text;
            _undoIndex = (_undoIndex + 1) % _undoList.Length;

            // сброс таймера
            _timer.Stop();
            _timer.Start();
        }
    }
}

