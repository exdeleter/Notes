using MediatR;
using Microsoft.Extensions.Logging;
using Notes.Infrastructure.Abstractions;
using Notes.Infrastructure.Queries.Note;
using Notes.Models.Dtos;

namespace Notes.Infrastructure.Handlers.Note;

/// <summary> Обработчик получения <see cref="Note"/> по идентификатору.</summary>
public class GetNoteByIdHandler : IRequestHandler<GetNoteByIdQuery, NoteDto?>
{
    private readonly IRepository<Models.Entities.Note, NoteDto> _repository;
    private readonly ILogger<GetNoteByIdQuery> _logger;

    public GetNoteByIdHandler(IRepository<Models.Entities.Note, NoteDto> repository, ILogger<GetNoteByIdQuery> logger)
    {
        _repository = repository;
        _logger = logger;
    }


    public async Task<NoteDto?> Handle(GetNoteByIdQuery request, CancellationToken cancellationToken)
    {
        var note = await _repository.GetAsync(request.Id, cancellationToken);

        if (note == null)
        {
            _logger.LogInformation("Entity with {Id} is not found!", request.Id);
            return default;
        }

        var tags = note.Tags
            .Select(x => new TagDto { Id = x.Id, Name = x.Name })
            .ToList();

        return new NoteDto
        {
            Id = note.Id,
            Content = note.Content,
            Header = note.Header,
            Tags = tags,
        };
    }
}