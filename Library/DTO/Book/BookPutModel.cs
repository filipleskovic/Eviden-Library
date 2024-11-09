namespace Library.DTO.Book
{
    public class BookPutModel
    {
        public int Id { get; set; }
        public string? BookName { get; set; }
        public int BookAuthorId { get; set; }
        public int GenreId { get; set; }
        public Models.Book ToBook()
        {
            return new Models.Book { Id=Id,BookName=BookName,BookAuthorId=BookAuthorId, GenreId=GenreId };
        }
    }
}
