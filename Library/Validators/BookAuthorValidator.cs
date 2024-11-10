using Library.Models;

namespace Library.Validators
{
    public class BookAuthorValidator
    {
         public static bool IsValid(BookAuthor bookAuthor)
        {
            if (bookAuthor.YearOfBirth >= 2025)
            {
                return false;

            }
            return true;           
                
        }
    }
}
