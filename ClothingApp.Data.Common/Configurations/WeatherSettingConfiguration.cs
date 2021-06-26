using ClothingApp.Data.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClothingApp.Data.Common.Configurations
{
    public class WeatherSettingConfiguration : BaseConfiguration<WeatherSetting, int>
    {
        protected override void ConfigureCustom(EntityTypeBuilder<WeatherSetting> builder)
        {
            builder.ToTable("WeatherSetting");

            builder
                .HasOne(p => p.RangeRule)
                .WithMany(p => p.WeatherSettings)
                .HasForeignKey(f => f.RangeRuleId);

            builder
                .HasOne(p => p.BooleanRule)
                .WithMany(p => )

            
        }
    }
}
