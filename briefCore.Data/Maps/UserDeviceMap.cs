namespace briefCore.Data.Maps
{
    using Library.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class UserDeviceMap
    {
        public UserDeviceMap(EntityTypeBuilder<UserDevice> builder)
        {
            builder.ToTable("user_devices");
        }    
    }
}