namespace briefCore.Data.Maps
{
    using Library.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class BookInGenreMap
    {
        public BookInGenreMap(EntityTypeBuilder<BookInGenre> builder)
        {
            builder.ToTable("book_in_genre");

            builder.HasKey(bg => new { bg.BookId, bg.GenreId });
            
            builder.HasOne(bg => bg.Book)
                .WithMany(b => b.BookInGenres)
                .HasForeignKey(bg => bg.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(bg => bg.Genre)
                .WithMany(g => g.BookInGenres)
                .HasForeignKey(bg => bg.GenreId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}