namespace briefCore.Library.Entities
{
    using System.Collections.Generic;
    using BaseEntities;

    public class Device  : BaseEntity
    {
        public string Product { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public List<UserDevice> UserDevices { get; set; }
    }
}