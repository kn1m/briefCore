namespace briefCore.Data.Maps
{
    using Library.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class EditionMap 
    {
        public EditionMap(EntityTypeBuilder<Edition> builder)
        {
            builder.ToTable("editions");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Description)
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(e => e.BookId)
                .IsRequired();

            builder.Property(e => e.PublisherId)
                .IsRequired();

            builder.Property(e => e.EditionType)
                .IsRequired();

            builder.Property(e => e.Language)
                .IsRequired();

            builder.Property(e => e.Isbn13)
                .HasMaxLength(13);

            builder.Property(e => e.Isbn10)
                .HasMaxLength(10);

            builder.HasOne(e => e.Publisher)
                .WithMany(p => p.Editions)
                .HasForeignKey(e => e.PublisherId)
                .IsRequired();

            builder.HasOne(e => e.Book)
                .WithMany(b => b.Editions)
                .HasForeignKey(e => e.BookId)
                .IsRequired();
        }
    }
}
