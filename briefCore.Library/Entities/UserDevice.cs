namespace briefCore.Library.Entities
{
    using System;
    using BaseEntities;

    public class UserDevice : BaseEntity
    {
        public Guid DeviceId { get; set; }
        public Device Device { get; set; }
        public string SerialNumber { get; set; }
        public string Description { get; set; }
    }
}