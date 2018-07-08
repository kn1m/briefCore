namespace briefCore.Data.Maps
{
    using Library.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class DeviceMap
    {
        public DeviceMap(EntityTypeBuilder<Device> builder)
        {
            builder.ToTable("devices");
            
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Manufacturer)
                .HasMaxLength(300)
                .IsRequired();
            
            builder.Property(d => d.Product)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(d => d.Description)
                .HasMaxLength(300);
        }    
    }
}