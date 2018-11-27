namespace briefCore.Data.Maps
{
    using Library.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TranslatorMap
    {
        public TranslatorMap(EntityTypeBuilder<Translator> builder)
        {
            builder.ToTable("translators");
            
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd();
            
            builder.Property(t => t.FirstName)
                .HasMaxLength(100);

            builder.Property(t => t.SecondName)
                .HasMaxLength(100);

            builder.Property(t => t.LastName)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}