using Notes.Models.Entities.Base;

namespace Notes.Models.Entities;

/// <summary> Заметка. </summary>
public class Note : BaseEntity
{
    /// <summary> Заголовок. </summary>
    public string Header { get; set; }

    /// <summary> Текст. </summary>
    public string Content { get; set; }

    /// <summary> Тэги. </summary>
    public ICollection<Tag> Tags { get; set; }
}