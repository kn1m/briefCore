namespace briefCore.Data.Maps
{
    using Library.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class NotesFileMap
    {
        public NotesFileMap(EntityTypeBuilder<NotesFile> builder)
        {
            builder.ToTable("note_file");

            builder.HasKey(nf => nf.Id);

            builder.Property(nf => nf.Checksum)
                .HasMaxLength(4000)
                .IsRequired();
            
            builder.Property(nf => nf.Path)
                .HasMaxLength(4000)
                .IsRequired();

            builder.HasOne(nf => nf.ImportInfo)
                .WithMany(ii => ii.NotesFiles)
                .HasForeignKey(nf => nf.ImportInfoId)
                .IsRequired();
        }
    }
}