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
            
            builder.HasKey(ud => ud.Id);

            builder.Property(ud => ud.SerialNumber)
                .HasMaxLength(30)
                .IsRequired();
            
            builder.Property(ud => ud.Description)
                .HasMaxLength(300);
            
            builder.Property(ud => ud.DeviceId)
                .IsRequired();
            
            builder.HasOne(ud => ud.Device)
                .WithMany(d => d.UserDevices)
                .HasForeignKey(ud => ud.DeviceId)
                .IsRequired();
        }    
    }
}