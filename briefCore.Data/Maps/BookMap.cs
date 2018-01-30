namespace briefCore.Data.Maps
{
    using brief.Library.Entities;
    using Library.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class BookMap
    {
        public BookMap(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("books");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(b => b.Description)
                .HasMaxLength(300);

            builder.HasMany<Series>(b => b.Serieses)
                .WithMany(s => s.BooksInSeries)
                .Map(cs =>
                {
                    cs.MapLeftKey("BookId");
                    cs.MapRightKey("SeriesId");
                    cs.ToTable("books_in_series");
                });

            builder.HasMany<Author>(b => b.Authors)
                .WithMany(a => a.BooksByAuthor)
                .Map(ba =>
                { 
                    ba.MapLeftKey("BookId");
                    ba.MapRightKey("AuthorId");
                    ba.ToTable("books_by_author");
                });
        }
    }
}
