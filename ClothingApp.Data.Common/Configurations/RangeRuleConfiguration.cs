using ClothingApp.Data.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClothingApp.Data.Common.Configurations
{
    public class RangeRuleConfiguration : BaseConfiguration<RangeRule, long>
    {
        protected override void ConfigureCustom(EntityTypeBuilder<RangeRule> builder)
        {
            builder.ToTable("RangeRule");
            builder.HasKey(o => o.Id);
        }
    }
}
