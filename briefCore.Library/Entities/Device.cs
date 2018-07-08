namespace briefCore.Library.Entities
{
    using System;
    using System.Collections.Generic;

    public class Device
    {
        public Guid Id { get; set; }
        public string Product { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public List<UserDevice> UserDevices { get; set; }
    }
}