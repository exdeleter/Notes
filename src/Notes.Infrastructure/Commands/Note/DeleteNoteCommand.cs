using MediatR;
using Notes.Models.Dtos;

namespace Notes.Infrastructure.Commands.Note;

/// <summary> Команда для удаления <see cref="NoteDto"/>. </summary>
/// <param name="Dto">Дто</param>
public record DeleteNoteCommand(NoteDto Dto) : IRequest<Guid>;