using MediatR;
using Notes.Models.Dtos;

namespace Notes.Infrastructure.Queries.Note;

/// <summary> Квери для получения <see cref="Note"/>. </summary>
public record GetNotesQuery : IRequest<List<NoteDto>>;