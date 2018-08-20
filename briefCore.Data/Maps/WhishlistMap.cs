namespace briefCore.Data.Maps
{
    using Library.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class WhishlistMap
    {
        public WhishlistMap(EntityTypeBuilder<Whishlist> builder)
        {
            builder.ToTable("whishlist");

            builder.HasKey(w => w.Id);
        }
    }
}