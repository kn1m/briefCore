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

            builder.Property(a => a.AuthorFirstName)
                .HasMaxLength(100);

            builder.Property(a => a.AuthorSecondName)
                .HasMaxLength(100);

            builder.Property(a => a.AuthorLastName)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}