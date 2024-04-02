using MediatR;
using Notes.Models.Dtos;

namespace Notes.Infrastructure.Commands.Note;

/// <summary> Команда для обновления <see cref="NoteDto"/>. </summary>
/// <param name="Dto">Дто</param>
public record UpdateNoteCommand(NoteDto Dto) : IRequest<NoteDto>;