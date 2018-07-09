namespace briefCore.Data.Maps
{
    using Library.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class CoverMap
    {
        public CoverMap(EntityTypeBuilder<Cover> builder)
        {
            builder.ToTable("covers");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.LinkTo)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(c => c.EditionId)
                .IsRequired();

            builder.HasOne(c => c.Edition)
                .WithMany(e => e.Covers)
                .HasForeignKey(c => c.EditionId)
                .IsRequired();
        }
    }
}
