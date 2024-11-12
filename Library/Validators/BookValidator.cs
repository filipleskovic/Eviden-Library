using Library.IBookAuthorRepoistory.cs;
using Library.Models;
using Library.Repository.Common;
using Library.Services.Common;
using Microsoft.IdentityModel.Tokens;

namespace Library.Validators
{
    public class BookValidator
    {
        public Book? Book { get; set; }
        public string? Message {  get; set; }
        public bool IsPost { get; set; }
        public BookValidator( bool isPost)
        {
            IsPost = isPost;
        }
        public async Task<bool> IsValidAsync (Book book ,IGenreRepository genreRepository, IBookAuthorRepository bookAuthorRepoistory)
        {
            if (String.IsNullOrEmpty(book.BookName) && IsPost)
            {
                book = null;
                Message = "$Invalid name";
                return false;   
            }
            if( await bookAuthorRepoistory.GetBookAuthorAsync(book.BookAuthorId) == null && (IsPost || book.BookAuthorId != 0))
            {
                Message = $"No book author found on Id: {book.BookAuthorId}";
                book = null;
                return false;
            }
            if (await genreRepository.GetGenreAsync(book.GenreId) == null && (IsPost || book.GenreId != 0))
            {
                Message = $"No genre found on Id: {book.GenreId}";
                book = null;
                return false;
            }
            return true;
        }
    }
}
