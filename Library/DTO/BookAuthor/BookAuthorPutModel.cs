namespace Library.DTO.BookAuthor
{
    public class BookAuthorPutModel
    {
        public string? AuthorName { get; set; }
        public int YearOfBirth { get; set; }

        public Models.BookAuthor ToBookAuthor()
        {
            return new Models.BookAuthor { AuthorName = AuthorName, YearOfBirth = YearOfBirth };
        }
    }
}
