namespace Library.DTO.Genre
{
    public class GenrePostModel
    {
        public string GenreName { get; set; }   
        public Models.Genre ToGenre()
        {
            return new Models.Genre { GenreName = GenreName };
        }
    }
}
