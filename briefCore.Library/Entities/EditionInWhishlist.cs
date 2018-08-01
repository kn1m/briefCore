namespace briefCore.Library.Entities
{
    using System;

    public class EditionInWhishlist
    {
        public Guid EditionId { get; set; }
        public Edition Edition { get; set; }

        public Guid WhishlistId { get; set; }
        public Whishlist Whishlist { get; set; }

        public string Reason { get; set; }
        public DateTime Added { get; set; }
    }
}