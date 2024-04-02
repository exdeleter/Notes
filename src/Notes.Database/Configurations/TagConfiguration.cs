using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notes.Models.Entities;

namespace Notes.Database.Configurations;

/// <summary> Конфигурация <see cref="Tag"/>. </summary>
internal class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .HasComment("Идентификатор")
            .HasColumnName("id");

        builder
            .Property(x => x.Name)
            .HasComment("Наименование")
            .HasColumnName("header");

        builder.ToTable("tags",
            t => t.HasComment("Тэги"));
    }
}