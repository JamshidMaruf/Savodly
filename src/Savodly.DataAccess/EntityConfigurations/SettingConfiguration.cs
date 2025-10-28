using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Savodly.Domain.Entities;

namespace Savodly.DataAccess.EntityConfigurations;
public class SettingConfiguration : IEntityTypeConfiguration<Setting>
{
    public void Configure(EntityTypeBuilder<Setting> builder)
    {
        builder.Property(s => s.Key).IsRequired();
        builder.Property(s => s.Value).IsRequired();
        builder.Property(s => s.Category).IsRequired();

        builder.HasIndex(s => s.Key).IsUnique();

        builder.Property(s => s.IsEncrypted).HasDefaultValue(false);

        builder.Property(s => s.IsDeleted).HasDefaultValue(false);

        builder.HasData(new List<Setting>
        {
            new Setting
            {
                Id = 1,
                Key = "JWT.Issuer",
                Value = "https://savodly.uz",
                Category = "JWT",
                IsEncrypted = false,
                IsDeleted = false
            },
            new Setting
            {
                Id = 2,
                Key = "JWT.Audience",
                Value = "https://savodly.uz",
                Category = "JWT",
                IsEncrypted = false,
                IsDeleted = false
            },
            new Setting
            {
                Id = 3,
                Key = "JWT.Key",
                Value = "949eddf8-4560-4cf2-8efe-2f6daea075e9",
                Category = "JWT",
                IsEncrypted = false,
                IsDeleted = false
            },
            new Setting
            {
                Id = 4,
                Key = "JWT.Expires",
                Value = "24",
                Category = "JWT",
                IsEncrypted = false,
                IsDeleted = false
            },
        });
    }
}
