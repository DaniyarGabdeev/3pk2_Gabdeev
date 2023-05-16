namespace LibraryApp.Models
{
    public class Book
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Author { get; set; }

        public Book(string title, string year, string author)
        {
            Title = title;
            Year = year;
            Author = author;
        }
    }
}
