namespace briefCore.Data.Maps
{
    using Library.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class EditionInWhishlistMap
    {
        public EditionInWhishlistMap(EntityTypeBuilder<EditionInWhishlist> builder)
        {
            builder.ToTable("edition_in_whishlist");

            builder.HasKey(ew => new { ew.EditionId, ew.WhishlistId });

            builder.HasOne(ew => ew.Edition)
                .WithMany(e => e.EditionInWhishlists)
                .HasForeignKey(ew => ew.EditionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ew => ew.Whishlist)
                .WithMany(w => w.EditionInWhishlists)
                .HasForeignKey(ew => ew.WhishlistId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.Property(ew => ew.Reason)
                .HasMaxLength(4000);
        }
    }
}