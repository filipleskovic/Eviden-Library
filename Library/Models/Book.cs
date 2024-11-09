namespace Library.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? BookName { get;set; }
        public DateTime EntryDate { get; set; }
        public int BookAuthorId { get; set; }
        public BookAuthor? BookAuthor { get; set; }
        public int GenreId { get; set; }
        public Genre? Genre { get; set; }

    }
}
