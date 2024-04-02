using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notes.Models.Entities;

namespace Notes.Database.Configurations;

/// <summary> Конфигурация <see cref="Note"/>. </summary>
internal class NoteConfiguration : IEntityTypeConfiguration<Note>
{
    public void Configure(EntityTypeBuilder<Note> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .HasComment("Идентификатор")
            .HasColumnName("id");

        builder
            .Property(x => x.Header)
            .HasComment("Заголовок")
            .HasColumnName("header");

        builder.Property(x => x.Content)
            .HasComment("Текст")
            .HasColumnName("сontent");

        builder.ToTable("notes",
            t => t.HasComment("Заметки"));

        builder
            .HasMany(x => x.Tags)
            .WithMany(x => x.Notes);
    }
}