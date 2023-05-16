using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using LibraryApp.Models;
using LibraryApp.Commands;

namespace LibraryApp.ViewModels
{
    public class LibraryViewModel : INotifyPropertyChanged
    {
        private string _title;
        private string _year;
        private string _author;
        private Book _selectedBook;

        public ObservableCollection<Book> Books { get; set; }
        public RelayCommand AddBookCommand { get; set; }

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        public string Year
        {
            get { return _year; }
            set
            {
                _year = value;
                OnPropertyChanged();
            }
        }

        public string Author
        {
            get { return _author; }
            set
            {
                _author = value;
                OnPropertyChanged();
            }
        }

        public Book SelectedBook
        {
            get { return _selectedBook; }
            set
            {
                _selectedBook = value;
                OnPropertyChanged();
            }
        }

        public LibraryViewModel()
        {
            Books = new ObservableCollection<Book>();
            AddBookCommand = new RelayCommand(AddBook);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void AddBook()
        {
            Book book = new Book(Title, Year, Author);
            Books.Add(book);
        }
    }
}
