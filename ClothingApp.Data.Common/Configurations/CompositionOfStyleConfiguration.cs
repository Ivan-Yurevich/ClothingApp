using ClothingApp.Data.Common.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClothingApp.Data.Common.Configurations
{
    public class CompositionOfStyleConfiguration : BaseConfiguration<CompositionOfStyle, long>
    {
        protected override void ConfigureCustom(EntityTypeBuilder<CompositionOfStyle> builder)
        {
            builder.HasOne(o => o.ClothingItem)
                .WithMany(o => o.CompositionOfStyles)
                .HasForeignKey(o => o.ClothingItemId);

            builder.HasOne(o => o.Style)
                .WithMany(o => o.CompositionOfStyles)
                .HasForeignKey(o => o.StyleId);
        }
    }
}
