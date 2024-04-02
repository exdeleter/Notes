using Notes.Models.Entities.Base;

namespace Notes.Models.Dtos;

/// <summary> Напоминание. </summary>
public class ReminderDto : BaseEntity
{
    /// <summary> Заголовок. </summary>
    public string Header { get; set; }

    /// <summary> Текст. </summary>
    public string Content { get; set; }  
    
    /// <summary> Время напоминания. </summary>
    public DateTime NotifyDate { get; set; }

    /// <summary> Тэги. </summary>
    public ICollection<TagDto> Tags { get; set; }
}