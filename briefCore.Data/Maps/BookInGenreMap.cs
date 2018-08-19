namespace briefCore.Data.Maps
{
    using Library.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BookInGenreMap
    {
        public BookInGenreMap(EntityTypeBuilder<BookInGenre> builder)
        {
            builder.ToTable("book_in_genre");
        }
    }
}