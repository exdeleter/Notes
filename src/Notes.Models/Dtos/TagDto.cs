using Notes.Models.Entities.Base;

namespace Notes.Models.Dtos;

/// <summary> Тэг. </summary>
public class TagDto : BaseEntity
{
    /// <summary> Наименование. </summary>
    public string Name { get; set; }
}