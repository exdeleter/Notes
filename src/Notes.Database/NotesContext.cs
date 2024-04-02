using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Notes.Models.Entities;

namespace Notes.Database;

/// <summary> Контекст. </summary>
public class NotesContext : DbContext
{
    /// <inheritdoc />
    public NotesContext(DbContextOptions<NotesContext> options) : base(options) { }

    /// <summary> Заметки. </summary>
    public DbSet<Note> Notes { get; set; }

    /// <summary> Напоминания. </summary>
    public DbSet<Reminder> Reminders { get; set; }

    /// <summary> Тэги. </summary>
    public DbSet<Tag> Tags { get; set; }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}