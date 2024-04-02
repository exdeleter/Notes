using Notes.Models.Entities.Base;

namespace Notes.Models.Dtos;

/// <summary> Заметка. </summary>
public class NoteDto : BaseEntity
{
    /// <summary> Заголовок. </summary>
    public string Header { get; set; }

    /// <summary> Текст. </summary>
    public string Content { get; set; }

    /// <summary> Тэги. </summary>
    public ICollection<TagDto> Tags { get; set; }
}