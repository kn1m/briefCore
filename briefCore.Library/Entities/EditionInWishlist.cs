namespace briefCore.Library.Entities
{
    using System;

    public class EditionInWishlist
    {
        public Guid EditionId { get; set; }
        public Edition Edition { get; set; }

        public Guid WishlistId { get; set; }
        public Wishlist Wishlist { get; set; }

        public string Reason { get; set; }
        public DateTime Added { get; set; }
    }
}