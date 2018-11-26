namespace briefCore.Data.Maps
{
    using Library.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CategoryMap
    {
        public CategoryMap(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("categories");

            builder.HasKey(c => c.Id);
            
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            
            builder.Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired();
            
            builder.Property(c => c.Description)
                .HasMaxLength(300);
            
            builder.HasOne(c => c.ParentCategory)
                .WithMany()
                .HasForeignKey(m => m.ParentCategoryId);
        }
    }
}