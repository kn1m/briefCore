namespace briefCore.Controllers.Models
{
    using System;

    public class DeviceModel
    {
        public Guid Id { get; set; }
        public string Product { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
    }
}