namespace briefCore.Data.Maps
{
    using brief.Library.Entities;
    using Microsoft.AspNet.OData.Builder;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class SeriesMap : EntityTypeConfiguration<Series>
    {
        public SeriesMap()
        {
            ToTable("serieses");

            HasKey(s => s.Id);

            Property(s => s.Name)
                .HasMaxLength(100)
                .IsRequired();

            Property(s => s.Description)
                .HasMaxLength(300);
        }
    }
}
