using Library.Models;

namespace Library.Validators
{
    public class BookAuthorValidator
    {
        public BookAuthor? BookAuthor { get; set; }
        public string? Message { get; set; }
        public bool IsPost { get; set; }

        public BookAuthorValidator(bool isPost) 
        { 
            IsPost = isPost;
        }
         public bool IsValid(BookAuthor bookAuthor)
        {
            if(string.IsNullOrEmpty(bookAuthor.AuthorName) && IsPost)
            {
                Message = "Invalid name";
                BookAuthor = null;
                return false;
            }
            if (bookAuthor.YearOfBirth >= 2025 )
            {
                Message = $"Invalid date, date bigger than {DateTime.Now.Year}";
                BookAuthor = null;
                return false;
            }
            return true;           
                
        }
    }
}
