namespace briefCore.Library.Entities
{
    using System;

    public class UserDevice
    {
        public Guid Id { get; set; }
        public Device Device { get; set; }
        public string SerialNumber { get; set; }
    }
}