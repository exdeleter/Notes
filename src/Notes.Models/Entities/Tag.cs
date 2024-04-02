using Notes.Models.Entities.Base;

namespace Notes.Models.Entities;

/// <summary> Тэг. </summary>
public class Tag : BaseEntity
{
    /// <summary> Наименование. </summary>
    public string Name { get; set; }

    /// <summary> Заметки.</summary>
    public ICollection<Note> Notes { get; set; }

    /// <summary> Напоминания.</summary>
    public ICollection<Reminder> Reminders { get; set; }
}