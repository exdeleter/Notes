using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notes.Models.Entities;

namespace Notes.Database.Configurations;

/// <summary> Конфигурация <see cref="Reminder"/>. </summary>
internal class ReminderConfiguration : IEntityTypeConfiguration<Reminder>
{
    public void Configure(EntityTypeBuilder<Reminder> builder)
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

        builder.Property(x => x.NotifyDate)
            .HasComment("Дата и время напоминания")
            .HasColumnName("notify_date");

        builder.ToTable("reminders",
            t => t.HasComment("Напоминания"));

        builder
            .HasMany(x => x.Tags)
            .WithMany(x => x.Reminders);
    }
}