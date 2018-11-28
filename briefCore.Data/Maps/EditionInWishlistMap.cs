namespace briefCore.Data.Maps
{
    using Library.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class EditionInWishlistMap
    {
        public EditionInWishlistMap(EntityTypeBuilder<EditionInWishlist> builder)
        {
            builder.ToTable("edition_in_wishlist");

            builder.HasKey(ew => new { ew.EditionId, ew.WishlistId });

            builder.HasOne(ew => ew.Edition)
                .WithMany(e => e.EditionInWhishlists)
                .HasForeignKey(ew => ew.EditionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ew => ew.Wishlist)
                .WithMany(w => w.EditionInWishlists)
                .HasForeignKey(ew => ew.WishlistId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.Property(ew => ew.Reason)
                .HasMaxLength(4000);
        }
    }
}