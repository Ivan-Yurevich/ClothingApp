using ClothingApp.Data.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClothingApp.Data.Common.Configurations
{
    public class StyleConfiguration : BaseConfiguration<Style, long>
    {
        protected override void ConfigureCustom(EntityTypeBuilder<Style> builder)
        {
            builder.ToTable("Styles");
        }
    }
}
