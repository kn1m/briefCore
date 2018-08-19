namespace briefCore.Data.Maps
{
    using Library.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EditionInUnfinishedListMap
    {
        public EditionInUnfinishedListMap(EntityTypeBuilder<EditionInUnfinishedList> builder)
        {
            builder.ToTable("edition_in_unfinishedlist");

            builder.HasKey(eu => new { eu.EditionId, eu.UnfinishedListId });
        }
    }
}