namespace briefCore.Library.Entities
{
    using System;

    public class BookInGenre
    {
        public Guid BookId { get; set; }
        public Book Book { get; set; }

        public Guid GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}