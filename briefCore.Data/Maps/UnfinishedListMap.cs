namespace briefCore.Data.Maps
{
    using Library.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class UnfinishedListMap
    {
        public UnfinishedListMap(EntityTypeBuilder<UnfinishedList> builder)
        {
            builder.ToTable("unfinished_list");

            builder.HasKey(ul => ul.Id);
        }
    }
}