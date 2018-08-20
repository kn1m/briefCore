namespace briefCore.Data.Maps
{
    using Library.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class BookByAuthorMap
    {
        public BookByAuthorMap(EntityTypeBuilder<BookByAuthor> builder)
        {
            builder.ToTable("books_by_author");
            
            builder.HasKey(ba => new { ba.AuthorId, ba.BookId });

            builder.HasOne(ba => ba.Book)
                .WithMany(b => b.BookByAuthors)
                .HasForeignKey(ba => ba.BookId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasOne(ba => ba.Author)
                .WithMany(b => b.BooksByAuthor)
                .HasForeignKey(ba => ba.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}