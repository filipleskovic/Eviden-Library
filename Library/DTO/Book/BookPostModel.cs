namespace Library.DTO.Book
{
    public class BookPostModel
    {
        public string BookName { get; set; }
        public int BookAuthorId { get; set; }
        public int GenreId { get; set; }
        public Models.Book ToBook()
        {
            return new Models.Book { BookName = BookName, EntryDate = DateTime.Now, BookAuthorId = BookAuthorId, GenreId = GenreId };
        }
    }
}
