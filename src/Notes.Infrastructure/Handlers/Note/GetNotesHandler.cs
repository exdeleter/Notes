using MediatR;
using Microsoft.Extensions.Logging;
using Notes.Infrastructure.Abstractions;
using Notes.Infrastructure.Queries.Note;
using Notes.Models.Dtos;

namespace Notes.Infrastructure.Handlers.Note;

/// <summary> Обработчик получения <see cref="Note"/>. </summary>
public class GetNotesHandler : IRequestHandler<GetNotesQuery, List<NoteDto>>
{
    private readonly IRepository<Models.Entities.Note, NoteDto> _repository;
    private readonly ILogger<GetNotesQuery> _logger;

    public GetNotesHandler(IRepository<Models.Entities.Note, NoteDto> repository, ILogger<GetNotesQuery> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    /// <inheritdoc />
    public async Task<List<NoteDto>> Handle(GetNotesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);

        var dtos = entities.Select(x => new NoteDto
        {
            Id = x.Id,
            Content = x.Content,
            Header = x.Header,
            Tags = x.Tags
                .Select(y => new TagDto { Id = y.Id, Name = y.Name })
                .ToList()
        }).ToList();

        return dtos;
    }
}