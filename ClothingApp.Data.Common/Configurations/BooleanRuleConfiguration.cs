using ClothingApp.Data.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClothingApp.Data.Common.Configurations
{
    public class BooleanRuleConfiguration : BaseConfiguration<BooleanRule, long>
    {
        protected override void ConfigureCustom(EntityTypeBuilder<BooleanRule> builder)
        {
            builder.ToTable("BooleanRules");
        }
    }
}
