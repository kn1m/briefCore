namespace briefCore.Data.Maps
{
    using Library.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class AuthorMap
    {
        public AuthorMap(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("authors");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.FirstName)
                .HasMaxLength(100);

            builder.Property(a => a.SecondName)
                .HasMaxLength(100);

            builder.Property(a => a.LastName)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}