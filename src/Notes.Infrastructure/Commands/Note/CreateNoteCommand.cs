using MediatR;
using Notes.Models.Dtos;

namespace Notes.Infrastructure.Commands.Note;

/// <summary> Команда для создания <see cref="NoteDto"/>. </summary>
/// <param name="Dto">Дто</param>
public record CreateNoteCommand(NoteDto Dto) : IRequest<Guid>;