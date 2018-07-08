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
        }    
    }
}