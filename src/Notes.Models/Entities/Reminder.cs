using Notes.Models.Entities.Base;

namespace Notes.Models.Entities;

/// <summary> Напоминание. </summary>
public class Reminder : BaseEntity
{
    /// <summary> Заголовок. </summary>
    public string Header { get; set; }

    /// <summary> Текст. </summary>
    public string Content { get; set; }

    /// <summary>  Дата напоминания. </summary>
    public DateTime NotifyDate { get; set; }

    /// <summary> Тэги. </summary>
    public ICollection<Tag> Tags { get; set; }
}