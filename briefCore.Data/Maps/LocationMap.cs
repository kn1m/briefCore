namespace briefCore.Data.Maps
{
    using brief.Library.Entities;
    using Library.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class LocationMap
    {
        public LocationMap(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("locations");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.Address)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(l => l.Stage)
                .IsRequired();

            builder.Property(l => l.Loker)
                .IsRequired();

            builder.Property(l => l.Shelf)
                .IsRequired();

            //builder.HasRequired<Edition>(l => l.Edition)
            //    .WithMany(e => e.Locations)
            //    .HasForeignKey(l => l.EditionId);
        }
    }
}