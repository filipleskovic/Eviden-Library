namespace Library.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string BookName { get;set; }
        public DateTime EntryDate { get; set; }
        public int BookAuthorId { get; set; }
        public BookAuhor BookAuhor { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

    }
}
