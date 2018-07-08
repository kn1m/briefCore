namespace briefCore.Controllers.Models
{
    using System;

    public class UserDeviceModel
    {
        public Guid? Id { get; set; }
        public DeviceModel Device { get; set; }
        public string SerialNumber { get; set; }
        public string Description { get; set; }
    }
}