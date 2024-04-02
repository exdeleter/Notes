using MediatR;
using Notes.Models.Dtos;

namespace Notes.Infrastructure.Queries.Note;

/// <summary> Квери для получения всех <see cref="Note"/>. </summary>
public record GetNoteByIdQuery(Guid Id) : IRequest<NoteDto>;