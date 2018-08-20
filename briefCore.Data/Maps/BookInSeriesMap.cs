namespace briefCore.Data.Maps
{
    using Library.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class BookInSeriesMap
    {
        public BookInSeriesMap(EntityTypeBuilder<BookInSeries> builder)
        {
            builder.ToTable("books_in_series");
            
            builder.HasKey(bs => new { bs.SeriesId, bs.BookId });

            builder.HasOne(bs => bs.Book)
                .WithMany(b => b.BookInSerieses)
                .HasForeignKey(bs => bs.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(bs => bs.Series)
                .WithMany(b => b.BooksInSeries)
                .HasForeignKey(bs => bs.SeriesId)
                .OnDelete(DeleteBehavior.Cascade);
        }    
    }
}