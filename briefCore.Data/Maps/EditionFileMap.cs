namespace briefCore.Data.Maps
{
    using brief.Library.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class EditionFileMap
    {
        public EditionFileMap(EntityTypeBuilder<EditionFile> builder)
        {
            builder.ToTable("edition_files");

            builder.HasKey(ef => ef.Id);

            builder.Property(ef => ef.Path)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(ef => ef.IsReaded)
                .IsRequired();

            builder.Property(ef => ef.Type)
                .IsRequired();

            builder.Property(ef => ef.Uploaded)
                .IsRequired();

            builder.HasOne(ef => ef.Edition)
                .WithMany(e => e.Files)
                .HasForeignKey(ef => ef.EditionId)
                .IsRequired();
        }
    }
}
