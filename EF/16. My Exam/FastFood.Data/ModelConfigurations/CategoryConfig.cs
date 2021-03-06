﻿namespace FastFood.Data.ModelConfigurations
{
    using FastFood.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> category)
        {
            category.HasKey(c => c.Id);

            category.Property(c => c.Name).IsRequired(true).HasColumnType("nvarchar(30)");
        }
    }
}
