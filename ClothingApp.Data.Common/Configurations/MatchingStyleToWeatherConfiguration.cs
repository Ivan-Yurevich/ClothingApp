using ClothingApp.Data.Common.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClothingApp.Data.Common.Configurations
{
    public class MatchingStyleToWeatherConfiguration : BaseConfiguration<MatchingStyleToWeather, long>
    {
        protected override void ConfigureCustom(EntityTypeBuilder<MatchingStyleToWeather> builder)
        {
            builder.HasOne(o => o.Style)
                .WithMany(o => o.MatchingStyleToWeathers)
                .HasForeignKey(o => o.StyleId);

            builder.HasOne(o => o.WeatherSetting)
                .WithMany(o => o.MatchingStyleToWeathers)
                .HasForeignKey(o => o.WeatherSettingId);
        }
    }
}
