﻿namespace briefCore.Data.Maps
{
    using Library.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class EditionInUnfinishedListMap
    {
        public EditionInUnfinishedListMap(EntityTypeBuilder<EditionInUnfinishedList> builder)
        {
            builder.ToTable("edition_in_unfinishedlist");

            builder.HasKey(eu => new { eu.EditionId, eu.UnfinishedListId });

            builder.HasOne(eu => eu.Edition)
                .WithMany(e => e.EditionInUnfinishedLists)
                .HasForeignKey(eu => eu.EditionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(eu => eu.UnfinishedList)
                .WithMany(ul => ul.EditionInUnfinishedLists)
                .HasForeignKey(eu => eu.UnfinishedListId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(eu => eu.Reason)
                .HasMaxLength(4000);
        }
    }
}